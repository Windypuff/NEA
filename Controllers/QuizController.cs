using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NEA.Models;
using Microsoft.Extensions.Configuration;



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
            int difficulty = 3;
            var DatabaseHelper = new DatabaseHelper(_connString);
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
            var equationHelper =  new EquationHelper();
            List<double> parts = equationHelper.ParseEquationRegex(question.equation);
            List<string> solutions = equationHelper.SolveEquation(parts[0],parts[1],parts[2]);
            String solutionsConcatenated = null;
                if (solutions.Count == 1){
                    solutionsConcatenated = solutions[0];
                }
                else{
                    solutionsConcatenated = "x = " + solutions[0] + " , x = " + solutions[1];
                } 
            if (solutionsConcatenated == question.answer){
                //Incorrect answers = 0, Increase correct answers by 1
                int difficulty = 3; //get current difficulty from database
                // if (correctAnswers == 3){
                //     difficulty = difficulty + 1;
                // }
                
                var DatabaseHelper = new DatabaseHelper(_connString);
                List<QuestionModel> Questions = new List<QuestionModel>(); 
                Questions = DatabaseHelper.GetQuestions(difficulty);
                var QuestionDTO = new QuestionDTO();
                QuestionDTO.Questions = Questions;
                QuestionDTO.PreviousAnswerCorrect = "y"; //1 means yes
                           
                return View(QuestionDTO);
            }
            else{
                //Correct answers = 0 , increase incorrect answers by 1
                int difficulty = 3; //get current difficulty from database
                // if (incorrectAnswers == 3){
                //     difficulty = difficulty - 1;
                // }
                var DatabaseHelper = new DatabaseHelper(_connString);
                List<QuestionModel> Questions = new List<QuestionModel>(); 
                Questions = DatabaseHelper.GetQuestions(difficulty);   
                var QuestionDTO = new QuestionDTO();
                QuestionDTO.Questions = Questions;
                QuestionDTO.PreviousAnswerCorrect = "n";  //0 means no      
                return View(QuestionDTO);

            }
            
        }
    }
}