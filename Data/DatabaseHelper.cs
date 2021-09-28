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

        public DatabaseHelper(IConfiguration config){
            _config = config;
            _connString = _config.GetValue<string>("ConnectionStrings:DefaultConnection");
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

        public List<QuestionModel> GetQuestion(int DifficultyLevel)
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
                
        
                        QuestionModel Question = new QuestionModel{
                            Equation = Equation,
                            DifficultyLevel = DifficultyLevel,
                        };
                        Questions.Add(Question);
                        return Questions;
                    }
                }
                return null;
            }

        }  
    }
}