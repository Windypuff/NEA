#pragma checksum "C:\Users\bensc\OneDrive\Documents\A Level Computer Science\NEA\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0af7eb1fc6812709f9b09a4dad5fc718fc4646d5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\bensc\OneDrive\Documents\A Level Computer Science\NEA\Views\_ViewImports.cshtml"
using NEA;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\bensc\OneDrive\Documents\A Level Computer Science\NEA\Views\_ViewImports.cshtml"
using NEA.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\bensc\OneDrive\Documents\A Level Computer Science\NEA\Views\Home\Index.cshtml"
using NEA.Controllers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\bensc\OneDrive\Documents\A Level Computer Science\NEA\Views\Home\Index.cshtml"
using Highsoft.Web.Mvc.Charts;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\bensc\OneDrive\Documents\A Level Computer Science\NEA\Views\Home\Index.cshtml"
using Highsoft.Web.Mvc.Charts.Rendering;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0af7eb1fc6812709f9b09a4dad5fc718fc4646d5", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f56f3953e80b20791bc6cbfa3923b3dc60acafa8", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EquationDTO>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "POST", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 6 "C:\Users\bensc\OneDrive\Documents\A Level Computer Science\NEA\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";
    List<string> solutions = null;
    if (Model.solutions != null){
        solutions = Model.solutions;
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"container\">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0af7eb1fc6812709f9b09a4dad5fc718fc4646d54872", async() => {
                WriteLiteral(@"
        <div class=""form-group"">
            <div class=""input-group shadow"">
                
                <input name=""equation"" type=""text"" class=""form-control form-control-lg dummy-file-input"" placeholder=""Input Equation Here"" >
                <button id=""btn-submit"" class=""btn btn-success"" type=""submit""><i class=""fas fa-upload""></i> Submit </button> 
            </div>
             
        </div>
    
    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n\r\n<div class=\"text-center\">\r\n");
#nullable restore
#line 28 "C:\Users\bensc\OneDrive\Documents\A Level Computer Science\NEA\Views\Home\Index.cshtml"
      
        if (solutions != null){
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "C:\Users\bensc\OneDrive\Documents\A Level Computer Science\NEA\Views\Home\Index.cshtml"
             foreach (var solution in solutions)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li class = \"list-group-item\">\r\n                x = ");
#nullable restore
#line 33 "C:\Users\bensc\OneDrive\Documents\A Level Computer Science\NEA\Views\Home\Index.cshtml"
               Write(solution);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </li>\r\n");
#nullable restore
#line 35 "C:\Users\bensc\OneDrive\Documents\A Level Computer Science\NEA\Views\Home\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 35 "C:\Users\bensc\OneDrive\Documents\A Level Computer Science\NEA\Views\Home\Index.cshtml"
             
        }
    

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>

<script src=""https://code.highcharts.com/highcharts.js""></script>
<script src=""https://code.highcharts.com/modules/exporting.js""></script>

<script type=""text/javascript"">

    function formatXLabels() {
        return this.value;
    }
    function formatYLabels() {
        return this.value;
    }
</script>

");
#nullable restore
#line 53 "C:\Users\bensc\OneDrive\Documents\A Level Computer Science\NEA\Views\Home\Index.cshtml"
   var chartOptions =
      new Highcharts
      {
          Chart = new Highsoft.Web.Mvc.Charts.Chart
          {
              Inverted = false,
              Type = ChartType.Spline,
              ZoomType = ChartZoomType.Xy

          },
          Title = new Title
          {
              Text = null
          },

          XAxis = new List<XAxis>
              {
                new XAxis
                {
                    //Reversed = true,
                    Title = new XAxisTitle
                    {
                        Text = null //was x
                    },
                    Labels = new XAxisLabels
                    {
                        Formatter = "formatXLabels"
                    },
                    MaxPadding = 0.05,
                    ShowLastLabel = true
                }
            },
            YAxis = new List<YAxis>
            {
                new YAxis
                {
                    //Reversed = true,
                    Title = new YAxisTitle
                    {
                        Text = null //was y
                    },
                    Labels = new YAxisLabels
                    {
                        Formatter = "formatYLabels"
                    },
                    LineWidth = 2
                }
            },
          Legend = new Legend
          {
              Enabled = false
          },
          Tooltip = new Tooltip
          {
              HeaderFormat = null,
              PointFormat = "({point.x},{point.y})"
          },

          PlotOptions = new PlotOptions
          {
              Spline = new PlotOptionsSpline
              {
                  Marker = new PlotOptionsSplineMarker
                  {
                      Enabled = true
                  }
              }
          },

          Series = new List<Series>
              {
                new SplineSeries
                {
                    Data = Model.Coordinates as List<SplineSeriesData>
                },
                new SplineSeries
                {
                    Data = Model.xAxis as List<SplineSeriesData>
                }
            }
      };

    chartOptions.ID = "chart";
    var renderer = new HighchartsRenderer(chartOptions);
    
    

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 140 "C:\Users\bensc\OneDrive\Documents\A Level Computer Science\NEA\Views\Home\Index.cshtml"
 try{
    if(Model.Coordinates != null){
   
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 143 "C:\Users\bensc\OneDrive\Documents\A Level Computer Science\NEA\Views\Home\Index.cshtml"
Write(Html.Raw(renderer.RenderHtml()));

#line default
#line hidden
#nullable disable
#nullable restore
#line 143 "C:\Users\bensc\OneDrive\Documents\A Level Computer Science\NEA\Views\Home\Index.cshtml"
                                    
}
}
catch{

}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EquationDTO> Html { get; private set; }
    }
}
#pragma warning restore 1591
