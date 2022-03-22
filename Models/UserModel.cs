using System;
namespace NEA.Models
{
    public class UserModel {
        public string UserID {get;set;}
        public string Username {get;set;}
        public int DifficultyLevel {get;set;}
        public int QuestionsCorrect {get;set;}
        public int QuestionsIncorrect {get;set;}
    }
}