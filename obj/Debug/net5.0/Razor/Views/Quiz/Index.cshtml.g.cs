#pragma checksum "C:\Users\bensc\OneDrive\Documents\A Level Computer Science\NEA\Views\Quiz\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f03693cba8dba3b2cf30066a42119bf404a6a336"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Quiz_Index), @"mvc.1.0.view", @"/Views/Quiz/Index.cshtml")]
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
#line 1 "C:\Users\bensc\OneDrive\Documents\A Level Computer Science\NEA\Views\Quiz\Index.cshtml"
using NEA.Controllers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f03693cba8dba3b2cf30066a42119bf404a6a336", @"/Views/Quiz/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f56f3953e80b20791bc6cbfa3923b3dc60acafa8", @"/Views/_ViewImports.cshtml")]
    public class Views_Quiz_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<QuestionDTO>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "POST", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n\r\n");
#nullable restore
#line 6 "C:\Users\bensc\OneDrive\Documents\A Level Computer Science\NEA\Views\Quiz\Index.cshtml"
  
    ViewData["Title"] = "Quiz";
    List<QuestionModel> questions = null;
    string PreviousAnswerCorrect = null;
    if (Model != null){
        questions = Model.Questions;
        if (Model.PreviousAnswerCorrect != null){
            PreviousAnswerCorrect = Model.PreviousAnswerCorrect;
        }
    }
    Random R = new Random();
    int i = R.Next(0,questions.Count); 

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<!DOCTYPE html>
<html>
<style>
/* The container */
.container {
  display: block;
  position: relative;
  padding-left: 35px;
  margin-bottom: 12px;
  cursor: pointer;
  font-size: 22px;
  -webkit-user-select: none;
  -moz-user-select: none;
  -ms-user-select: none;
  user-select: none;
}

/* Hide the browser's default radio button */
.container input {
  position: absolute;
  opacity: 0;
  cursor: pointer;
}

/* Create a custom radio button */
.checkmark {
  position: absolute;
  top: 0;
  left: 0;
  height: 25px;
  width: 25px;
  background-color: #eee;
  border-radius: 50%;
}

/* On mouse-over, add a grey background color */
.container:hover input ~ .checkmark {
  background-color: #ccc;
}

/* When the radio button is checked, add a blue background */
.container input:checked ~ .checkmark {
  background-color: #2196F3;
}

/* Create the indicator (the dot/circle - hidden when not checked) */
.checkmark:after {
  content: """";
  position: absolute;
  displa");
            WriteLiteral(@"y: none;
}

/* Show the indicator (dot/circle) when checked */
.container input:checked ~ .checkmark:after {
  display: block;
}

/* Style the indicator (dot/circle) */
.container .checkmark:after {
 	top: 8.5px;
	left: 8.5px;
	width: 8px;
	height: 8px;
	border-radius: 50%;
	background: white;
}

</style>


");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f03693cba8dba3b2cf30066a42119bf404a6a3365840", async() => {
                WriteLiteral("\r\n\r\n");
#nullable restore
#line 93 "C:\Users\bensc\OneDrive\Documents\A Level Computer Science\NEA\Views\Quiz\Index.cshtml"
 if (PreviousAnswerCorrect == "y"){

#line default
#line hidden
#nullable disable
                WriteLiteral("  <h1 style=\"color:green;\">Correct</h1>\r\n");
#nullable restore
#line 95 "C:\Users\bensc\OneDrive\Documents\A Level Computer Science\NEA\Views\Quiz\Index.cshtml"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 96 "C:\Users\bensc\OneDrive\Documents\A Level Computer Science\NEA\Views\Quiz\Index.cshtml"
 if (PreviousAnswerCorrect == "n"){

#line default
#line hidden
#nullable disable
                WriteLiteral("  <h1 style=\"color:red;\">Incorrect</h1>\r\n");
#nullable restore
#line 98 "C:\Users\bensc\OneDrive\Documents\A Level Computer Science\NEA\Views\Quiz\Index.cshtml"
}

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n<h2>");
#nullable restore
#line 101 "C:\Users\bensc\OneDrive\Documents\A Level Computer Science\NEA\Views\Quiz\Index.cshtml"
Write(questions[i].Equation);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h2>\r\n");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f03693cba8dba3b2cf30066a42119bf404a6a3367305", async() => {
                    WriteLiteral("\r\n  <input type = \"hidden\" name = \"equation\"");
                    BeginWriteAttribute("value", " value =", 2071, "", 2079, 0);
                    EndWriteAttribute();
                    WriteLiteral(" ");
#nullable restore
#line 103 "C:\Users\bensc\OneDrive\Documents\A Level Computer Science\NEA\Views\Quiz\Index.cshtml"
                                              Write(questions[i].Equation);

#line default
#line hidden
#nullable disable
                    WriteLiteral(" />\r\n  <input type = \"hidden\" name = \"difficulty\"");
                    BeginWriteAttribute("value", " value =", 2151, "", 2159, 0);
                    EndWriteAttribute();
                    WriteLiteral(" ");
#nullable restore
#line 104 "C:\Users\bensc\OneDrive\Documents\A Level Computer Science\NEA\Views\Quiz\Index.cshtml"
                                                Write(questions[i].DifficultyLevel);

#line default
#line hidden
#nullable disable
                    WriteLiteral(" />\r\n");
#nullable restore
#line 105 "C:\Users\bensc\OneDrive\Documents\A Level Computer Science\NEA\Views\Quiz\Index.cshtml"
   foreach (var question in questions) 
    {

#line default
#line hidden
#nullable disable
                    WriteLiteral("      <label class=\"container\">");
#nullable restore
#line 107 "C:\Users\bensc\OneDrive\Documents\A Level Computer Science\NEA\Views\Quiz\Index.cshtml"
                          Write(question.SolutionsConcatenated);

#line default
#line hidden
#nullable disable
                    WriteLiteral(" \r\n          <input type=\"radio\" name=\"answer\"");
                    BeginWriteAttribute("value", " value=\"", 2350, "\"", 2389, 1);
#nullable restore
#line 108 "C:\Users\bensc\OneDrive\Documents\A Level Computer Science\NEA\Views\Quiz\Index.cshtml"
WriteAttributeValue("", 2358, question.SolutionsConcatenated, 2358, 31, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(">\r\n          <span class=\"checkmark\"></span>\r\n          \r\n      </label> \r\n");
#nullable restore
#line 112 "C:\Users\bensc\OneDrive\Documents\A Level Computer Science\NEA\Views\Quiz\Index.cshtml"
    }  

#line default
#line hidden
#nullable disable
                    WriteLiteral("   <button id=\"btn-submit\" class=\"btn btn-success\" type=\"submit\"><i class=\"btn btn-primary d-none\"></i> Submit </button>    \r\n");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<QuestionDTO> Html { get; private set; }
    }
}
#pragma warning restore 1591
