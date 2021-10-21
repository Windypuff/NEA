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
        public List<SplineSeriesData> GetPoints (double A, double B,double C)
        {
            List<double> xValues = new List<double>();
            List<double> yValues = new List<double>();
            for (double i = -10; i < 10; i++){
                
                xValues.Add(i);
                double yValue = A * (i*i) + B *(i) + C;
                yValues.Add(yValue);
            }
            List<SplineSeriesData> tempData = new List<SplineSeriesData>();
            for (int i = 0; i < xValues.Count; i++)
            {
                SplineSeriesData seriesData = new SplineSeriesData { X = xValues[i], Y = yValues[i] };
                tempData.Add(seriesData);
            }
            return tempData;
        }
    }

}