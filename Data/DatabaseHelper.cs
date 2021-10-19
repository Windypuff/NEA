using System;
using System.Collections.Generic;
using NEA.Models;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;


namespace NEA
{
    public class DatabaseHelper
    {
        private readonly IConfiguration _config; 
        private readonly string _connString;
        public DatabaseHelper(string connString){
            //_config = config;
            //_connString = _config.GetValue<string>("ConnectionStrings:DefaultConnection");
            _connString = connString;
        }        
        public UserModel GetUserData(string UserID){
            
            using (var connection = new SqliteConnection(_connString)){
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = 
                @"
                SELECT *
                FROM Users WHERE UserID = @UserID   
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
                        List<Double> parts = equationHelper.ParseEquationRegex(Equation);
                        List<String> solutions = equationHelper.SolveEquation(parts[0],parts[1],parts[2]);
                        
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
                            SolutionsConcatenated = solutionsConcatenated
                        };
                        Questions.Add(Question);                       
                    }
                }
                return Questions;
            }
        }  
    }
}