using System;
using System.Collections.Generic;
using NEA.Models;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Highsoft.Web.Mvc.Charts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;


namespace NEA
{
    public class DatabaseHelper
    {
        //private readonly IConfiguration _config;
        private readonly string _connString;
        public DatabaseHelper(string connString){
            //_config = config;
            //_connString = _config.GetValue<string>("ConnectionStrings:DefaultConnection");
            _connString = connString;
        }        

        public class UserDTO{
            public string Id {get;set;}
            public string NetUserId {get;set;}
            public int AnswersCorrect {get;set;}
            public int AnswersIncorrect{get;set;}
            public int difficulty{get;set;}
        }

        public void CreateUser(IdentityUser user){
            
            using (var connection = new SqliteConnection(_connString))
            {
                connection.Open();

                var command = connection.CreateCommand();

                command.CommandText =
                @"
                    INSERT INTO Users (AnswersCorrect, AnswersIncorrect, CurrentDifficulty, NetUserID)       
                    VALUES (@AnswersCorrect, @AnswersIncorrect, @CurrentDifficulty, @UserID)    
                ";
                command.Parameters.AddWithValue("AnswersCorrect", 0);
                command.Parameters.AddWithValue("AnswersIncorrect",0);
                command.Parameters.AddWithValue("CurrentDifficulty", 1);
                command.Parameters.AddWithValue("UserID", user.Id);
                command.ExecuteNonQuery();
            }

        }

        public void ChangeDetails(bool correct, string userId){

            UserDTO user = new UserDTO();
            
            using (var connection = new SqliteConnection(_connString)){
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = 
                @"
                SELECT * 
                FROM Users WHERE NetUserId = @UserId   
                ";
                command.Parameters.AddWithValue("UserId", userId);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var Id = reader.GetString(0);
                        var AnswersCorrect = reader.GetInt32(1);
                        var AnswersIncorrect = reader.GetInt32(2);
                        var difficulty = reader.GetInt32(3);
                        
                        user.AnswersCorrect = AnswersCorrect;
                        user.AnswersIncorrect = AnswersIncorrect;
                        user.NetUserId = userId;
                        user.difficulty = difficulty;
                    }
                }
                if (correct == true){
                    user.AnswersCorrect += 1;
                    user.AnswersIncorrect = 0;
                }
                else{
                    user.AnswersIncorrect += 1;
                    user.AnswersCorrect = 0;
                }
                if (user.AnswersCorrect == 3 & user.difficulty != 5){
                    user.difficulty += 1;
                    user.AnswersCorrect = 0;
                    user.AnswersIncorrect = 0;
                }
                else if (user.AnswersIncorrect == 3 & user.difficulty != 1){
                    user.difficulty -= 1;
                    user.AnswersCorrect = 0;
                    user.AnswersIncorrect = 0;
                }
               
                command.CommandText = 
                @"
                UPDATE Users
                SET AnswersCorrect = @AnswersCorrect, AnswersIncorrect = @AnswersIncorrect, CurrentDifficulty = @CurrentDifficulty
                WHERE NetUserId = @NetUserId
                ";
                command.Parameters.AddWithValue("AnswersCorrect", user.AnswersCorrect);
                command.Parameters.AddWithValue("AnswersIncorrect", user.AnswersIncorrect);
                command.Parameters.AddWithValue("CurrentDifficulty", user.difficulty);
                command.Parameters.AddWithValue("NetUserId", user.NetUserId);
                
                command.ExecuteNonQuery();
            }
        }
        
        public string getId(string userName){

            using (var connection = new SqliteConnection(_connString)){
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = 
                @"
                SELECT Id 
                FROM AspNetUsers WHERE Email = @UserName   
                ";
                command.Parameters.AddWithValue("UserName", userName);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string Id = reader.GetString(0);
                        return Id;
                    }
                }
                return null;
            }
        }

       
        public UserModel GetUserData(string UserID){
            
            using (var connection = new SqliteConnection(_connString)){
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = 
                @"
                SELECT *
                FROM Users WHERE NetUserID = @UserID   
                ";
                command.Parameters.AddWithValue("UserID", UserID);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var AnswersCorrect = reader.GetInt16(1);
                        var AnswersIncorrect = reader.GetInt16(2);
                        var CurrentDifficulty = reader.GetInt16(3);
                        UserModel User = new UserModel{
                            UserID = UserID,
                            DifficultyLevel = CurrentDifficulty,
                            QuestionsCorrect = AnswersCorrect,
                            QuestionsIncorrect = AnswersIncorrect
                        };
                        return User;
                    }
                }
                return null;
            }
        }   
        public List<QuestionModel> GetQuestions(int DifficultyLevel)
        {
            List<QuestionModel> Questions = new List<QuestionModel>();

            using (var connection = new SqliteConnection(_connString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = 
                @"
                SELECT *
                FROM Questions WHERE Difficulty = @DifficultyLevel   
                ";
                command.Parameters.AddWithValue("DifficultyLevel", DifficultyLevel);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var Equation = reader.GetString(1);
                        var equationHelper = new EquationHelper();
                        var plottingHelper = new PlottingHelper();
                        List<Decimal> parts = equationHelper.ParseEquationRegex(Equation);
                        List<String> solutions = equationHelper.SolveEquation(parts[0],parts[1],parts[2]);
                        List<List<decimal>> tempCoordinates = plottingHelper.GetPoints(parts[0],parts[1],parts[2],solutions);
                
                        decimal? turningPoint = equationHelper.FindTurningPoint(parts[0],parts[1],parts[2]);
                        if (turningPoint == null){
                            turningPoint = 0;
                        }
                        List<SplineSeriesData> coordinates = new List<SplineSeriesData>(); //List of points
                        for (int i = 0; i < tempCoordinates[0].Count; i++) //lists through each point and adds them to the list
                        {
                            SplineSeriesData seriesData = new SplineSeriesData { X = Convert.ToDouble(tempCoordinates[0][i]), Y = Convert.ToDouble(tempCoordinates[1][i]) };
                            coordinates.Add(seriesData);
                        }

                        
                        String solutionsConcatenated = null;
                        if (solutions.Count == 1){
                            solutionsConcatenated = solutions[0];
                        }
                        else{
                            solutionsConcatenated = "x = " + solutions[0] + " , x = " + solutions[1];
                        }
                    
                        QuestionModel Question = new QuestionModel{
                            Equation = Equation,
                            DifficultyLevel = DifficultyLevel,
                            Solutions = solutions,
                            SolutionsConcatenated = solutionsConcatenated,
                            Coordinates = coordinates
                        };
                        Questions.Add(Question);                       
                    }
                }
                return Questions;
            }
        }  
    }
}