using System;
using System.Collections.Generic;
using Highsoft.Web.Mvc.Charts;

namespace NEA.Models
{
    public class QuestionModel {
        public string Equation {get;set;}
        public List<string> Solutions {get;set;}
        public string SolutionsConcatenated{get;set;}
        public int DifficultyLevel {get;set;}
        public List<string> IncorrectSolutions {get;set;}
        public List<SplineSeriesData> Coordinates {get;set;}
        


    }
}