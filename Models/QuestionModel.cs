using System;
using System.Collections.Generic;
using Highsoft.Web.Mvc.Charts;
using Highsoft.Web.Mvc.Charts.Rendering;

namespace NEA.Models
{
    public class QuestionModel {
        public string equation {get;set;}
        public List<string> solutions {get;set;}
        public string solutionsConcatenated{get;set;}
        public int difficultyLevel {get;set;}
        public List<string> incorrectSolutions {get;set;}
        public List<SplineSeriesData> coordinates {get;set;}
        public HighchartsRenderer render { get; set; }
        public List<SplineSeriesData> xAxis {get;set;}
    }
}