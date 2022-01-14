using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NEA.Models;

using System.Web;
//using System.Web.Mvc;
using Highsoft.Web.Mvc.Charts;



namespace NEA.Controllers
{
    public class EquationDTO{
        public string equation {get;set;}
        public List<string> solutions {get;set;}
        public List<SplineSeriesData> Coordinates {get;set;}
        public List<SplineSeriesData> xAxis {get;set;}
        public List<SplineSeriesData> yAxis {get;set;}
    }
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var equationDTO = new EquationDTO();
            return View(equationDTO);
        }

        [HttpPost] 
        public IActionResult Index(string equation) //Runs when the submit button is pressed
        {
            var equationDTO = new EquationDTO();  //Used to send data to the front end
            var equationHelper = new EquationHelper();
            var plottingHelper = new PlottingHelper();

            if (equation != null){
                List<decimal> parts = equationHelper.ParseEquationRegex(equation);
                List<string> solutions = equationHelper.SolveEquation(parts[0],parts[1],parts[2]);
                List<List<decimal>> tempCoordinates = plottingHelper.GetPoints(parts[0],parts[1],parts[2],solutions);
                
                decimal? turningPoint = equationHelper.FindTurningPoint(parts[0],parts[1],parts[2]);
                if (turningPoint == null){
                    turningPoint = 0;
                }
                List<SplineSeriesData> xAxis = plottingHelper.xAxisPoints(tempCoordinates[0]);

                List<SplineSeriesData> coordinates = new List<SplineSeriesData>(); //List of points
                for (int i = 0; i < tempCoordinates[0].Count; i++) //lists through each point and adds them to the list
                {
                    SplineSeriesData seriesData = new SplineSeriesData { X = Convert.ToDouble(tempCoordinates[0][i]), Y = Convert.ToDouble(tempCoordinates[1][i]) };
                    coordinates.Add(seriesData);
                }
                //List<SplineSeriesData> yAxis = 
                equationDTO.equation = equation;
                equationDTO.solutions = solutions;
                equationDTO.Coordinates = coordinates;
                equationDTO.xAxis = xAxis;
                //equationDTO.yAxis = YAxis;

                return View(equationDTO); //Sends the solutions to the front end to be displayed
            }
            else{
                return View();
            }
        }

        public IActionResult Quiz()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
