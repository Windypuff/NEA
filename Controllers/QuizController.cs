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
using Highsoft.Web.Mvc.Charts;
using Highsoft.Web.Mvc.Charts.Rendering;
using System.Web;

namespace NEA.Controllers
{
    public class QuestionDTO
    {
        public EquationDTO EquationDTO { get; set; }
        public List<QuestionModel> Questions { get; set; }
        public string PreviousAnswerCorrect { get; set; }
        public List<HighchartsRenderer> renders { get; set; }
    }

    public class QuizController : Controller
    {
        private readonly IConfiguration _config;
        private readonly string _connString;
        public QuizController(IConfiguration config)
        {
            _config = config;
            _connString = _config.GetValue<string>("ConnectionStrings:DefaultConnection");
        }

        [HttpGet]
        public IActionResult Index()
        {
            int difficulty;
            var DatabaseHelper = new DatabaseHelper(_connString);
            var plottingHelper = new PlottingHelper();
            try
            {
                var userName = User.Identity.Name;
                var userId = DatabaseHelper.getId(userName);
                difficulty = DatabaseHelper.GetUserData(userId).DifficultyLevel;
            }
            catch
            {
                difficulty = HttpContext.Session.GetInt32("difficulty") ?? 1;

                if (difficulty == 1)
                {
                    HttpContext.Session.SetInt32("difficulty", 1);
                    HttpContext.Session.SetInt32("AnswersCorrect", 0);
                    HttpContext.Session.SetInt32("AnswersIncorrect", 0);
                }
            }

            List<QuestionModel> Questions = new List<QuestionModel>();

            Questions = DatabaseHelper.GetQuestions(difficulty);

            var QuestionDTO = new QuestionDTO();
            QuestionDTO.Questions = Questions;

            var chartOptions1 =
                new Highcharts
                {
                    ID = "chart1",
                    Title = new Title
                    {
                        Text = null
                    },
                    XAxis = new List<XAxis>
                    {
                        new XAxis
                        {
                            PlotLines = new List<XAxisPlotLines>
                            {
                                new XAxisPlotLines
                                {
                                    Value = 0,
                                    Width = 1,
                                    Color = "#808080"
                                }
                            },
                        }
                    },
                    YAxis = new List<YAxis>
                    {
                        new YAxis
                    {
                        Title = new YAxisTitle
                            {
                                Text = null
                            },

                        PlotLines = new List<YAxisPlotLines>
                        {
                                new YAxisPlotLines
                            {
                                Value = 0,
                                Width = 1,
                                Color = "#808080"
                            }
                        },


                    }
                            },
                    Tooltip = new Tooltip
                    {
                        Enabled = false

                    },
                    Legend = new Legend
                    {
                        Enabled = false
                    },
                    Series = new List<Series>
                            {
                    new SplineSeries
                    {
                        Name = null,

                       Data = Questions[0].coordinates as List<SplineSeriesData>
                    },

                            }
                };
            var chartOptions2 =
                                    new Highcharts
                                    {
                                        ID = "chart2",
                                        Title = new Title
                                        {
                                            Text = null
                                        },

                                        XAxis = new List<XAxis>
                                        {

                     new XAxis
                    {

                        PlotLines = new List<XAxisPlotLines>
                        {
                            new XAxisPlotLines
                            {
                                Value = 0,
                                Width = 1,
                                Color = "#808080"
                            }
                        },

                    }

                                        },

                                        YAxis = new List<YAxis>
                                        {

                    new YAxis
                    {
                        Title = new YAxisTitle
                            {
                                Text = null
                            },

                        PlotLines = new List<YAxisPlotLines>
                        {
                                new YAxisPlotLines
                            {
                                Value = 0,
                                Width = 1,
                                Color = "#808080"
                            }
                        },

                    }
                                        },
                                        Tooltip = new Tooltip
                                        {
                                            Enabled = false

                                        },
                                        Legend = new Legend
                                        {
                                            Enabled = false
                                        },
                                        Series = new List<Series>
                                        {
                    new SplineSeries
                    {
                        Name = null,

                       Data = Questions[1].coordinates as List<SplineSeriesData>
                    },

                                        }
                                    };

            var chartOptions3 =
                                    new Highcharts
                                    {
                                        ID = "chart3",
                                        Title = new Title
                                        {
                                            Text = null
                                        },

                                        XAxis = new List<XAxis>
                                        {

                     new XAxis
                    {

                        PlotLines = new List<XAxisPlotLines>
                        {
                            new XAxisPlotLines
                            {
                                Value = 0,
                                Width = 1,
                                Color = "#808080"
                            }
                        },

                    }

                                        },

                                        YAxis = new List<YAxis>
                                        {

                    new YAxis
                    {
                        Title = new YAxisTitle
                            {
                                Text = null
                            },

                        PlotLines = new List<YAxisPlotLines>
                        {
                                new YAxisPlotLines
                            {
                                Value = 0,
                                Width = 1,
                                Color = "#808080"
                            }
                        },

                    }
                                        },
                                        Tooltip = new Tooltip
                                        {
                                            Enabled = false

                                        },
                                        Legend = new Legend
                                        {
                                            Enabled = false
                                        },
                                        Series = new List<Series>
                                        {
                    new SplineSeries
                    {
                        Name = null,

                       Data = Questions[2].coordinates as List<SplineSeriesData>
                    },

                                        }
                                    };

            var chartOptions4 =
                                    new Highcharts
                                    {
                                        ID = "chart4",
                                        Title = new Title
                                        {
                                            Text = null
                                        },

                                        XAxis = new List<XAxis>
                                        {

                     new XAxis
                    {

                        PlotLines = new List<XAxisPlotLines>
                        {
                            new XAxisPlotLines
                            {
                                Value = 0,
                                Width = 1,
                                Color = "#808080"
                            }
                        },

                    }

                                        },

                                        YAxis = new List<YAxis>
                                        {

                    new YAxis
                    {
                        Title = new YAxisTitle
                            {
                                Text = null
                            },

                        PlotLines = new List<YAxisPlotLines>
                        {
                                new YAxisPlotLines
                            {
                                Value = 0,
                                Width = 1,
                                Color = "#808080"
                            }
                        },

                    }
                                        },
                                        Tooltip = new Tooltip
                                        {
                                            Enabled = false

                                        },
                                        Legend = new Legend
                                        {
                                            Enabled = false
                                        },
                                        Series = new List<Series>
                                        {
                    new SplineSeries
                    {
                        Name = null,

                       Data = Questions[3].coordinates as List<SplineSeriesData>
                    },

                                        }
                                    };



            QuestionDTO.Questions[0].render = new HighchartsRenderer(chartOptions1);
            QuestionDTO.Questions[1].render = new HighchartsRenderer(chartOptions2);
            QuestionDTO.Questions[2].render = new HighchartsRenderer(chartOptions3);
            QuestionDTO.Questions[3].render = new HighchartsRenderer(chartOptions4);

            return View(QuestionDTO);
        }

        public class ResultModel
        {
            public string answer { get; set; }
            public int difficulty { get; set; }
            public string equation { get; set; }
        }

        [HttpPost]
        public IActionResult Index(ResultModel question)
        {
            var DatabaseHelper = new DatabaseHelper(_connString);
            var equationHelper = new EquationHelper();
            List<decimal> parts = equationHelper.ParseEquationRegex(question.equation);
            List<string> solutions = equationHelper.SolveEquation(parts[0], parts[1], parts[2]);
            String solutionsConcatenated = null;
            if (solutions.Count == 1)
            {
                solutionsConcatenated = solutions[0];
            }
            else if (solutions[0].Contains("i"))
            {
                solutionsConcatenated = "x = " + solutions[0] + " , x = " + solutions[1];
            }
            else
            {
                solutionsConcatenated = "x = " + solutions[1] + " , x = " + solutions[0];
            }

            string userName;
            userName = User.Identity.Name;

            if (solutionsConcatenated == question.answer)
            {
                bool correct = true;
                int difficulty;
                int AnswersCorrect;
                int AnswersIncorrect;

                try
                {
                    var userId = DatabaseHelper.getId(userName);
                    DatabaseHelper.ChangeDetails(correct, userId);
                    var user = DatabaseHelper.GetUserData(userId);
                    difficulty = user.DifficultyLevel;

                }
                catch
                {
                    difficulty = HttpContext.Session.GetInt32("difficulty") ?? 1;
                    AnswersCorrect = HttpContext.Session.GetInt32("AnswersCorrect") ?? 0;
                    AnswersIncorrect = HttpContext.Session.GetInt32("AnswersIncorrect") ?? 0;
                    if (difficulty == 1)
                    {
                        HttpContext.Session.SetInt32("difficulty", 1);
                    }
                    AnswersCorrect += 1;
                    AnswersIncorrect = 0;
                    if (AnswersCorrect == 3 & difficulty != 5)
                    {
                        difficulty += 1;
                        HttpContext.Session.SetInt32("difficulty", difficulty);
                        AnswersCorrect = 0;
                        AnswersIncorrect = 0;
                    }
                    HttpContext.Session.SetInt32("AnswersCorrect", AnswersCorrect);
                    HttpContext.Session.SetInt32("AnswersIncorrect", AnswersIncorrect);
                }

                List<QuestionModel> Questions = new List<QuestionModel>();
                Questions = DatabaseHelper.GetQuestions(difficulty);
                var QuestionDTO = new QuestionDTO();
                QuestionDTO.Questions = Questions;
                QuestionDTO.PreviousAnswerCorrect = "y";

                var chartOptions1 =
                        new Highcharts
                        {
                            ID = "chart1",
                            Title = new Title
                            {
                                Text = null
                            },

                            XAxis = new List<XAxis>
                            {

                     new XAxis
                    {

                        PlotLines = new List<XAxisPlotLines>
                        {
                            new XAxisPlotLines
                            {
                                Value = 0,
                                Width = 1,
                                Color = "#808080"
                            }
                        },

                    }

                            },

                            YAxis = new List<YAxis>
                            {

                    new YAxis
                    {
                        Title = new YAxisTitle
                            {
                                Text = null
                            },

                        PlotLines = new List<YAxisPlotLines>
                        {
                                new YAxisPlotLines
                            {
                                Value = 0,
                                Width = 1,
                                Color = "#808080"
                            }
                        },

                    }
                            },
                            Tooltip = new Tooltip
                            {
                                Enabled = false

                            },
                            Legend = new Legend
                            {
                                Enabled = false
                            },
                            Series = new List<Series>
                            {
                    new SplineSeries
                    {
                        Name = null,

                       Data = Questions[0].coordinates as List<SplineSeriesData>
                    },

                            }
                        };
                var chartOptions2 =
                                        new Highcharts
                                        {
                                            ID = "chart2",
                                            Title = new Title
                                            {
                                                Text = null
                                            },

                                            XAxis = new List<XAxis>
                                            {

                     new XAxis
                    {

                        PlotLines = new List<XAxisPlotLines>
                        {
                            new XAxisPlotLines
                            {
                                Value = 0,
                                Width = 1,
                                Color = "#808080"
                            }
                        },

                    }

                                            },

                                            YAxis = new List<YAxis>
                                            {

                    new YAxis
                    {
                        Title = new YAxisTitle
                            {
                                Text = null
                            },

                        PlotLines = new List<YAxisPlotLines>
                        {
                                new YAxisPlotLines
                            {
                                Value = 0,
                                Width = 1,
                                Color = "#808080"
                            }
                        },

                    }
                                            },
                                            Tooltip = new Tooltip
                                            {
                                                Enabled = false

                                            },
                                            Legend = new Legend
                                            {
                                                Enabled = false
                                            },
                                            Series = new List<Series>
                                            {
                    new SplineSeries
                    {
                        Name = null,

                       Data = Questions[1].coordinates as List<SplineSeriesData>
                    },

                                            }
                                        };

                var chartOptions3 =
                                        new Highcharts
                                        {
                                            ID = "chart3",
                                            Title = new Title
                                            {
                                                Text = null
                                            },

                                            XAxis = new List<XAxis>
                                            {

                     new XAxis
                    {

                        PlotLines = new List<XAxisPlotLines>
                        {
                            new XAxisPlotLines
                            {
                                Value = 0,
                                Width = 1,
                                Color = "#808080"
                            }
                        },

                    }

                                            },

                                            YAxis = new List<YAxis>
                                            {

                    new YAxis
                    {
                        Title = new YAxisTitle
                            {
                                Text = null
                            },

                        PlotLines = new List<YAxisPlotLines>
                        {
                                new YAxisPlotLines
                            {
                                Value = 0,
                                Width = 1,
                                Color = "#808080"
                            }
                        },

                    }
                                            },
                                            Tooltip = new Tooltip
                                            {
                                                Enabled = false

                                            },
                                            Legend = new Legend
                                            {
                                                Enabled = false
                                            },
                                            Series = new List<Series>
                                            {
                    new SplineSeries
                    {
                        Name = null,

                       Data = Questions[2].coordinates as List<SplineSeriesData>
                    },

                                            }
                                        };

                var chartOptions4 =
                                        new Highcharts
                                        {
                                            ID = "chart4",
                                            Title = new Title
                                            {
                                                Text = null
                                            },

                                            XAxis = new List<XAxis>
                                            {

                     new XAxis
                    {

                        PlotLines = new List<XAxisPlotLines>
                        {
                            new XAxisPlotLines
                            {
                                Value = 0,
                                Width = 1,
                                Color = "#808080"
                            }
                        },

                    }

                                            },

                                            YAxis = new List<YAxis>
                                            {

                    new YAxis
                    {
                        Title = new YAxisTitle
                            {
                                Text = null
                            },

                        PlotLines = new List<YAxisPlotLines>
                        {
                                new YAxisPlotLines
                            {
                                Value = 0,
                                Width = 1,
                                Color = "#808080"
                            }
                        },

                    }
                                            },
                                            Tooltip = new Tooltip
                                            {
                                                Enabled = false

                                            },
                                            Legend = new Legend
                                            {
                                                Enabled = false
                                            },
                                            Series = new List<Series>
                                            {
                    new SplineSeries
                    {
                        Name = null,

                       Data = Questions[3].coordinates as List<SplineSeriesData>
                    },

                                            }
                                        };




                QuestionDTO.Questions[0].render = new HighchartsRenderer(chartOptions1);
                QuestionDTO.Questions[1].render = new HighchartsRenderer(chartOptions2);
                QuestionDTO.Questions[2].render = new HighchartsRenderer(chartOptions3);
                QuestionDTO.Questions[3].render = new HighchartsRenderer(chartOptions4);
                //QuestionDTO.Questions[4].render = new HighchartsRenderer(chartOptions5);


                return View(QuestionDTO);
            }
            else
            {
                int difficulty;
                int AnswersCorrect;
                int AnswersIncorrect;
                try
                {
                    var userId = DatabaseHelper.getId(userName);
                    bool correct = false;
                    DatabaseHelper.ChangeDetails(correct, userId);
                    difficulty = DatabaseHelper.GetUserData(userId).DifficultyLevel;

                }
                catch
                {
                    difficulty = HttpContext.Session.GetInt32("difficulty") ?? 1;
                    AnswersCorrect = HttpContext.Session.GetInt32("AnswersCorrect") ?? 0;
                    AnswersIncorrect = HttpContext.Session.GetInt32("AnswersIncorrect") ?? 0;
                    if (difficulty == 1)
                    {
                        HttpContext.Session.SetInt32("difficulty", 1);
                    }
                    AnswersCorrect = 0;
                    AnswersIncorrect += 1;

                    if (AnswersIncorrect == 3 & difficulty != 1)
                    {
                        difficulty -= 1;
                        HttpContext.Session.SetInt32("difficulty", difficulty);
                        AnswersCorrect = 0;
                        AnswersIncorrect = 0;
                    }
                    HttpContext.Session.SetInt32("AnswersCorrect", AnswersCorrect);
                    HttpContext.Session.SetInt32("AnswersIncorrect", AnswersIncorrect);
                }

                List<QuestionModel> Questions = new List<QuestionModel>();
                Questions = DatabaseHelper.GetQuestions(difficulty);
                var QuestionDTO = new QuestionDTO();
                QuestionDTO.Questions = Questions;
                QuestionDTO.PreviousAnswerCorrect = "n";

                var chartOptions1 =
                        new Highcharts
                        {
                            ID = "chart1",
                            Title = new Title
                            {
                                Text = null
                            },

                            XAxis = new List<XAxis>
                            {

                     new XAxis
                    {

                        PlotLines = new List<XAxisPlotLines>
                        {
                            new XAxisPlotLines
                            {
                                Value = 0,
                                Width = 1,
                                Color = "#808080"
                            }
                        },

                    }

                            },

                            YAxis = new List<YAxis>
                            {

                    new YAxis
                    {
                        Title = new YAxisTitle
                            {
                                Text = null
                            },

                        PlotLines = new List<YAxisPlotLines>
                        {
                                new YAxisPlotLines
                            {
                                Value = 0,
                                Width = 1,
                                Color = "#808080"
                            }
                        },

                    }
                            },
                            Tooltip = new Tooltip
                            {
                                Enabled = false

                            },
                            Legend = new Legend
                            {
                                Enabled = false
                            },
                            Series = new List<Series>
                            {
                    new SplineSeries
                    {
                        Name = null,

                       Data = Questions[0].coordinates as List<SplineSeriesData>
                    },

                            }
                        };
                var chartOptions2 =
                                        new Highcharts
                                        {
                                            ID = "chart2",
                                            Title = new Title
                                            {
                                                Text = null
                                            },

                                            XAxis = new List<XAxis>
                                            {

                     new XAxis
                    {

                        PlotLines = new List<XAxisPlotLines>
                        {
                            new XAxisPlotLines
                            {
                                Value = 0,
                                Width = 1,
                                Color = "#808080"
                            }
                        },

                    }

                                            },

                                            YAxis = new List<YAxis>
                                            {

                    new YAxis
                    {
                        Title = new YAxisTitle
                            {
                                Text = null
                            },

                        PlotLines = new List<YAxisPlotLines>
                        {
                                new YAxisPlotLines
                            {
                                Value = 0,
                                Width = 1,
                                Color = "#808080"
                            }
                        },

                    }
                                            },
                                            Tooltip = new Tooltip
                                            {
                                                Enabled = false

                                            },
                                            Legend = new Legend
                                            {
                                                Enabled = false
                                            },
                                            Series = new List<Series>
                                            {
                    new SplineSeries
                    {
                        Name = null,

                       Data = Questions[1].coordinates as List<SplineSeriesData>
                    },

                                            }
                                        };

                var chartOptions3 =
                                        new Highcharts
                                        {
                                            ID = "chart3",
                                            Title = new Title
                                            {
                                                Text = null
                                            },

                                            XAxis = new List<XAxis>
                                            {

                     new XAxis
                    {

                        PlotLines = new List<XAxisPlotLines>
                        {
                            new XAxisPlotLines
                            {
                                Value = 0,
                                Width = 1,
                                Color = "#808080"
                            }
                        },

                    }

                                            },

                                            YAxis = new List<YAxis>
                                            {

                    new YAxis
                    {
                        Title = new YAxisTitle
                            {
                                Text = null
                            },

                        PlotLines = new List<YAxisPlotLines>
                        {
                                new YAxisPlotLines
                            {
                                Value = 0,
                                Width = 1,
                                Color = "#808080"
                            }
                        },

                    }
                                            },
                                            Tooltip = new Tooltip
                                            {
                                                Enabled = false

                                            },
                                            Legend = new Legend
                                            {
                                                Enabled = false
                                            },
                                            Series = new List<Series>
                                            {
                    new SplineSeries
                    {
                        Name = null,

                       Data = Questions[2].coordinates as List<SplineSeriesData>
                    },

                                            }
                                        };

                var chartOptions4 =
                                        new Highcharts
                                        {
                                            ID = "chart4",
                                            Title = new Title
                                            {
                                                Text = null
                                            },

                                            XAxis = new List<XAxis>
                                            {

                     new XAxis
                    {

                        PlotLines = new List<XAxisPlotLines>
                        {
                            new XAxisPlotLines
                            {
                                Value = 0,
                                Width = 1,
                                Color = "#808080"
                            }
                        },

                    }

                                            },

                                            YAxis = new List<YAxis>
                                            {

                    new YAxis
                    {
                        Title = new YAxisTitle
                            {
                                Text = null
                            },

                        PlotLines = new List<YAxisPlotLines>
                        {
                                new YAxisPlotLines
                            {
                                Value = 0,
                                Width = 1,
                                Color = "#808080"
                            }
                        },

                    }
                                            },
                                            Tooltip = new Tooltip
                                            {
                                                Enabled = false

                                            },
                                            Legend = new Legend
                                            {
                                                Enabled = false
                                            },
                                            Series = new List<Series>
                                            {
                    new SplineSeries
                    {
                        Name = null,

                       Data = Questions[3].coordinates as List<SplineSeriesData>
                    },

                                            }
                                        };

                QuestionDTO.Questions[0].render = new HighchartsRenderer(chartOptions1);
                QuestionDTO.Questions[1].render = new HighchartsRenderer(chartOptions2);
                QuestionDTO.Questions[2].render = new HighchartsRenderer(chartOptions3);
                QuestionDTO.Questions[3].render = new HighchartsRenderer(chartOptions4);
                //QuestionDTO.Questions[4].render = new HighchartsRenderer(chartOptions5);
                return View(QuestionDTO);

            }
        }
    }
}