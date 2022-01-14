using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NEA.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;



namespace NEA.Controllers
{
    public class QuestionDTO{
            public List<QuestionModel> Questions {get;set;}
            public string PreviousAnswerCorrect {get;set;}
        }
     
    public class QuizController : Controller
    {         
        private readonly IConfiguration _config; 
        private readonly string _connString;

        public QuizController(IConfiguration config){
            _config = config;
            _connString = _config.GetValue<string>("ConnectionStrings:DefaultConnection");
        }

        [HttpGet]
        public IActionResult Index()
        {
            
            int difficulty;
            var DatabaseHelper = new DatabaseHelper(_connString);
            var plottingHelper = new PlottingHelper();
            try{
                var userName = User.Identity.Name;
                var userId = DatabaseHelper.getId(userName);
                difficulty = DatabaseHelper.GetUserData(userId).DifficultyLevel;
            }
            catch{
                difficulty = HttpContext.Session.GetInt32("difficulty")?? 1;
                // int AnswersCorrect = HttpContext.Session.GetInt32("AnswersCorrect")?? 0;
                // int AnswersIncorrect = HttpContext.Session.GetInt32("AnswersIncorrect")?? 0;
                if (difficulty == 1){
                    HttpContext.Session.SetInt32("difficulty",1);
                    HttpContext.Session.SetInt32("AnswersCorrect",0);
                    HttpContext.Session.SetInt32("AnswersIncorrect",0);
                }
            }
            List<QuestionModel> Questions = new List<QuestionModel>(); 
            Questions = DatabaseHelper.GetQuestions(difficulty); 
            var QuestionDTO = new QuestionDTO();
            QuestionDTO.Questions = Questions;
            return View(QuestionDTO);
        }

        public class ResultModel{
            public string answer{get;set;}
            public int difficulty{get;set;}
            public string equation{get;set;}
        }

        [HttpPost]
        public IActionResult Index(ResultModel question)
        {
            var DatabaseHelper = new DatabaseHelper(_connString);
            var equationHelper =  new EquationHelper();
            List<decimal> parts = equationHelper.ParseEquationRegex(question.equation);
            List<string> solutions = equationHelper.SolveEquation(parts[0],parts[1],parts[2]);
            String solutionsConcatenated = null;
                if (solutions.Count == 1){
                    solutionsConcatenated = solutions[0];
                }
                else if (solutions[0].Contains("i")){
                    solutionsConcatenated = "x = " + solutions[0] + " , x = " + solutions[1];
                }
                else{
                    solutionsConcatenated = "x = " + solutions[1] + " , x = " + solutions[0];
                } 

            string userName;
            userName = User.Identity.Name;

            
            
            if (solutionsConcatenated == question.answer){
                bool correct = true;
                int difficulty;
                int AnswersCorrect;
                int AnswersIncorrect;
                
                
                try{
                    var userId = DatabaseHelper.getId(userName);
                    DatabaseHelper.ChangeDetails(correct, userId);
                    var user = DatabaseHelper.GetUserData(userId);
                    difficulty = user.DifficultyLevel;

                }
                catch{
                    difficulty = HttpContext.Session.GetInt32("difficulty")?? 1;
                    AnswersCorrect = HttpContext.Session.GetInt32("AnswersCorrect")?? 0;
                    AnswersIncorrect = HttpContext.Session.GetInt32("AnswersIncorrect")?? 0;
                    if (difficulty == 1){
                        HttpContext.Session.SetInt32("difficulty",1);
                    }
                    AnswersCorrect += 1;
                    AnswersIncorrect = 0;
                    if (AnswersCorrect == 3 & difficulty != 5){
                        difficulty += 1;
                        HttpContext.Session.SetInt32("difficulty",difficulty);
                        AnswersCorrect = 0;
                        AnswersIncorrect = 0;
                    }
                    HttpContext.Session.SetInt32("AnswersCorrect",AnswersCorrect);
                    HttpContext.Session.SetInt32("AnswersIncorrect",AnswersIncorrect);
                }  
                
                List<QuestionModel> Questions = new List<QuestionModel>(); 
                Questions = DatabaseHelper.GetQuestions(difficulty);
                var QuestionDTO = new QuestionDTO();
                QuestionDTO.Questions = Questions;
                QuestionDTO.PreviousAnswerCorrect = "y"; 
                           
                return View(QuestionDTO);
            }
            else{
                int difficulty;
                int AnswersCorrect;
                int AnswersIncorrect;
                try{
                    var userId = DatabaseHelper.getId(userName);
                    bool correct = false;
                    DatabaseHelper.ChangeDetails(correct, userId);
                    difficulty = DatabaseHelper.GetUserData(userId).DifficultyLevel;

                }
                catch{
                    difficulty = HttpContext.Session.GetInt32("difficulty") ?? 1;
                    AnswersCorrect = HttpContext.Session.GetInt32("AnswersCorrect") ?? 0;
                    AnswersIncorrect = HttpContext.Session.GetInt32("AnswersIncorrect") ?? 0;
                    if (difficulty == 1){
                        HttpContext.Session.SetInt32("difficulty",1);
                    }
                    AnswersCorrect = 0;
                    AnswersIncorrect += 1;
                    
                    if (AnswersIncorrect == 3 & difficulty != 1){
                        difficulty -= 1;
                        HttpContext.Session.SetInt32("difficulty",difficulty);
                        AnswersCorrect = 0;
                        AnswersIncorrect = 0;
                    }
                    HttpContext.Session.SetInt32("AnswersCorrect",AnswersCorrect);
                    HttpContext.Session.SetInt32("AnswersIncorrect",AnswersIncorrect);
                }
                   
                List<QuestionModel> Questions = new List<QuestionModel>(); 
                Questions = DatabaseHelper.GetQuestions(difficulty);   
                var QuestionDTO = new QuestionDTO();
                QuestionDTO.Questions = Questions;
                QuestionDTO.PreviousAnswerCorrect = "n";      
                return View(QuestionDTO);
            }
        }
    }
}