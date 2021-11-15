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




namespace NEA
{
    public class PlottingHelper
    {
        public List<SplineSeriesData> xAxisPoints( List<decimal> Graph_xValues){
            List<decimal> xValues = new List<decimal>();
            List<decimal> yValues = new List<decimal>();
            

            decimal startingPoint = Convert.ToDecimal(Graph_xValues[0]);
            decimal endPoint = Convert.ToDecimal(Graph_xValues[Graph_xValues.Count-1]);
            decimal step = Math.Abs(endPoint - startingPoint);
            for (decimal i = startingPoint ; i < endPoint+1 ; i=i+(step)){
                    xValues.Add(i);
                    decimal yValue = 0;
                    yValues.Add(yValue);
            }
            List<SplineSeriesData> tempData = new List<SplineSeriesData>();
            for (int i = 0; i < xValues.Count; i++)
            {
                SplineSeriesData seriesData = new SplineSeriesData { X = Convert.ToDouble(xValues[i]), Y = Convert.ToDouble(yValues[i]) };
                tempData.Add(seriesData);
            }
            return tempData;
            

        }
        public decimal? xValue1 = null;
        public decimal? xValue2 = null;
        public List<List<decimal>> GetPoints (decimal A, decimal B,decimal C, List<string> solutions)
        {
            List<decimal> xValues = new List<decimal>();
            List<decimal> yValues = new List<decimal>();
            var equationHelper = new EquationHelper();
            decimal? turningPoint = equationHelper.FindTurningPoint(A,B,C);
            
            //Gets x  values of points where y = 0

            
            
            //sort solutions

            try{
                decimal solution1 = Convert.ToDecimal(solutions[0]);
                decimal solution2 = Convert.ToDecimal(solutions[1]);
                if (solution1 > solution2){
                    solutions[0] = Convert.ToString(solution2);
                    solutions[1] = Convert.ToString(solution1);
                }
                
            }
            catch{
                
            };

            try{
                xValue1 = Convert.ToDecimal(solutions[0]);
                decimal? yValue = A * (xValue1*xValue1) + B *(xValue1) + C;
                // xValues.Add(Math.Round(Convert.ToDecimal(xValue1),2));
                // yValues.Add(0);
                xValue2 = Convert.ToDecimal(solutions[1]);
                yValue = A * (xValue2*xValue2) + B *(xValue2) + C;
            //     xValues.Add(Math.Round(Convert.ToDecimal(xValue2),2));
            //    yValues.Add(0);
             } 
             catch(ArgumentOutOfRangeException){ //if there is only one solution
                xValue1 = Convert.ToDecimal(solutions[0]);
                decimal? yValue = A * (xValue1*xValue1) + B *(xValue1) + C;
                // xValues.Add(Math.Round(xValue1,2));
                // yValues.Add(0);
            }
            catch(FormatException){ //if one or more of the solutions are complex
                
            }   
            catch(OverflowException){ //if the input numbers are too big
                
            }


            if (turningPoint != null){ //checks if the equation is a quadratic
                decimal startingPoint = Convert.ToDecimal(turningPoint-10); //The start point of the spline (far left)
                decimal startingPointRounded = Math.Round(startingPoint,2); 
                decimal endPoint = Convert.ToDecimal(turningPoint+10); //The end point of the spline (far right)
                decimal endPointRounded = Math.Round(endPoint,2);
                if(xValue2 < startingPoint){ //ensures the solutions are plotted on the graph
                    if (xValue1 > endPoint){
                        for (decimal? i = xValue2-5 ; i <= xValue1+5 ; i++){ //Lists through all the x values and adds them to the list of points
                            xValues.Add(Math.Round(Convert.ToDecimal(i),2));
                            decimal? yValue = A * (i*i) + B *(i) + C; 
                            yValues.Add(Math.Round(Convert.ToDecimal(yValue),2));
                        }
                    }
                    else{
                        for (decimal? i = xValue2-5 ; i <= endPointRounded ; i++){  //if the solution on the right is less than 10 from the turning point
                            xValues.Add(Math.Round(Convert.ToDecimal(i),2));
                            decimal? yValue = A * (i*i) + B *(i) + C; 
                            yValues.Add(Math.Round(Convert.ToDecimal(yValue),2));
                        }
                    } 
                }
                else{
                    if (xValue2 > endPoint){ //if the solution on the left is less than 10 from the turning point
                        for (decimal i = startingPointRounded ; i <= xValue2+5 ; i++){
                            xValues.Add(Math.Round(i,2));
                            decimal yValue = A * (i*i) + B *(i) + C; 
                            yValues.Add(Math.Round(yValue,2));
                        }
                    }
                    else{
                        for (decimal i = startingPointRounded ; i <= endPointRounded ; i++){ //If both solutions are within 10 of the turning point
                            xValues.Add(Math.Round(i,2));
                            decimal yValue = A * (i*i) + B *(i) + C; 
                            yValues.Add(Math.Round(yValue,2));
                        }
                    }     
                }     
            }
            else{ //if the equation is linear
                for (decimal i = (Convert.ToDecimal(xValue1) - 10) ; i < (Convert.ToDecimal(xValue1) + 10) ; i++){ //This needs to be 10 either side of the solution
                    xValues.Add(i);
                    decimal yValue = A * (i*i) + B *(i) + C;
                    yValues.Add(yValue);
                }
            } 

            
            

            for (int i = 0; i < xValues.Count; i++ ){
                if (xValues[i] < xValue1){ //the point it is checking is less than the solution
                    
                }
                else if (xValues[i] == xValue1) { //if the solution is already on the graph, leave it
                    break;
                }
                else { //you have gone past the solution which means it is between the current and previous point
                    if (xValue1 != null){
                        List<decimal> xValuesTemp = xValues.GetRange(i,xValues.Count-i);
                        xValues = xValues.GetRange(0,i);
                        xValues.Add(Convert.ToDecimal(xValue1));
                        for (int j = 0; j < xValuesTemp.Count; j++){
                            xValues.Add(xValuesTemp[j]);
                        }
                        List<decimal> yValuesTemp = yValues.GetRange(i,yValues.Count-i);
                        yValues = yValues.GetRange(0,i);
                        yValues.Add(0);
                        for (int j = 0; j < yValuesTemp.Count; j++){
                            yValues.Add(yValuesTemp[j]);
                        }
                    }
                    break; 
                }               
            }
            if (xValue2 != null){
                for (int i = 0; i < xValues.Count; i++ ){
                if (xValues[i] < xValue2){ //the point it is checking is less than the solution
                    
                }
                else if (xValues[i] == xValue2) { //if the solution is already on the graph, leave it
                    break;
                }
                else{ //you have gone past the solution which means it is between the current and previous point
                    List<decimal> xValuesTemp = xValues.GetRange(i,xValues.Count-i);
                    xValues = xValues.GetRange(0,i);
                    xValues.Add(Convert.ToDecimal(xValue2));
                    for (int j = 0; j < xValuesTemp.Count; j++){
                        xValues.Add(xValuesTemp[j]);
                    }
                    List<decimal> yValuesTemp = yValues.GetRange(i,yValues.Count-i);
                    yValues = yValues.GetRange(0,i);
                    yValues.Add(0);
                    for (int j = 0; j < yValuesTemp.Count; j++){
                        yValues.Add(yValuesTemp[j]);
                    }
                    break;
                    
                }
            }

            }

            

            List<List<decimal>> tempData = new List<List<decimal>>();
            tempData.Add(xValues);
            tempData.Add(yValues);

            return tempData;

            
            
            
            
        }
    }

}