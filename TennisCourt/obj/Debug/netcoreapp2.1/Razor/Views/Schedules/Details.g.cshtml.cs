#pragma checksum "C:\Users\Kavi Patel\source\repos\TennisCourt\TennisCourt\Views\Schedules\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a77a1a8c6e9a3bba2d2aab9dcc39f0544eb78820"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Schedules_Details), @"mvc.1.0.view", @"/Views/Schedules/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Schedules/Details.cshtml", typeof(AspNetCore.Views_Schedules_Details))]
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
#line 1 "C:\Users\Kavi Patel\source\repos\TennisCourt\TennisCourt\Views\_ViewImports.cshtml"
using TennisCourt;

#line default
#line hidden
#line 2 "C:\Users\Kavi Patel\source\repos\TennisCourt\TennisCourt\Views\_ViewImports.cshtml"
using TennisCourt.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a77a1a8c6e9a3bba2d2aab9dcc39f0544eb78820", @"/Views/Schedules/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8779041865d005e8fe6ddd501255b7a36a8f81fb", @"/Views/_ViewImports.cshtml")]
    public class Views_Schedules_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TennisCourt.Models.Schedule>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(36, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Kavi Patel\source\repos\TennisCourt\TennisCourt\Views\Schedules\Details.cshtml"
          
            ViewData["Title"] = "Details";
            Layout = "~/Views/Shared/_Layout.cshtml";
        

#line default
#line hidden
            BeginContext(160, 178, true);
            WriteLiteral("\r\n        <h2>Details</h2>\r\n\r\n        <div>\r\n            <h4>Schedule</h4>\r\n            <hr />\r\n            <dl class=\"dl-horizontal\">\r\n                <dt>\r\n                    ");
            EndContext();
            BeginContext(339, 40, false);
#line 15 "C:\Users\Kavi Patel\source\repos\TennisCourt\TennisCourt\Views\Schedules\Details.cshtml"
               Write(Html.DisplayNameFor(model => model.When));

#line default
#line hidden
            EndContext();
            BeginContext(379, 67, true);
            WriteLiteral("\r\n                </dt>\r\n                <dd>\r\n                    ");
            EndContext();
            BeginContext(447, 36, false);
#line 18 "C:\Users\Kavi Patel\source\repos\TennisCourt\TennisCourt\Views\Schedules\Details.cshtml"
               Write(Html.DisplayFor(model => model.When));

#line default
#line hidden
            EndContext();
            BeginContext(483, 67, true);
            WriteLiteral("\r\n                </dd>\r\n                <dt>\r\n                    ");
            EndContext();
            BeginContext(551, 47, false);
#line 21 "C:\Users\Kavi Patel\source\repos\TennisCourt\TennisCourt\Views\Schedules\Details.cshtml"
               Write(Html.DisplayNameFor(model => model.Description));

#line default
#line hidden
            EndContext();
            BeginContext(598, 67, true);
            WriteLiteral("\r\n                </dt>\r\n                <dd>\r\n                    ");
            EndContext();
            BeginContext(666, 43, false);
#line 24 "C:\Users\Kavi Patel\source\repos\TennisCourt\TennisCourt\Views\Schedules\Details.cshtml"
               Write(Html.DisplayFor(model => model.Description));

#line default
#line hidden
            EndContext();
            BeginContext(709, 67, true);
            WriteLiteral("\r\n                </dd>\r\n                <dt>\r\n                    ");
            EndContext();
            BeginContext(777, 46, false);
#line 27 "C:\Users\Kavi Patel\source\repos\TennisCourt\TennisCourt\Views\Schedules\Details.cshtml"
               Write(Html.DisplayNameFor(model => model.CoachEmail));

#line default
#line hidden
            EndContext();
            BeginContext(823, 67, true);
            WriteLiteral("\r\n                </dt>\r\n                <dd>\r\n                    ");
            EndContext();
            BeginContext(891, 42, false);
#line 30 "C:\Users\Kavi Patel\source\repos\TennisCourt\TennisCourt\Views\Schedules\Details.cshtml"
               Write(Html.DisplayFor(model => model.CoachEmail));

#line default
#line hidden
            EndContext();
            BeginContext(933, 67, true);
            WriteLiteral("\r\n                </dd>\r\n                <dt>\r\n                    ");
            EndContext();
            BeginContext(1001, 44, false);
#line 33 "C:\Users\Kavi Patel\source\repos\TennisCourt\TennisCourt\Views\Schedules\Details.cshtml"
               Write(Html.DisplayNameFor(model => model.Location));

#line default
#line hidden
            EndContext();
            BeginContext(1045, 67, true);
            WriteLiteral("\r\n                </dt>\r\n                <dd>\r\n                    ");
            EndContext();
            BeginContext(1113, 40, false);
#line 36 "C:\Users\Kavi Patel\source\repos\TennisCourt\TennisCourt\Views\Schedules\Details.cshtml"
               Write(Html.DisplayFor(model => model.Location));

#line default
#line hidden
            EndContext();
            BeginContext(1153, 101, true);
            WriteLiteral("\r\n                </dd>\r\n            </dl>\r\n        </div>\r\n        <div>\r\n            \r\n            ");
            EndContext();
            BeginContext(1254, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5128bce191a3494286b9110e668b840f", async() => {
                BeginContext(1276, 12, true);
                WriteLiteral("Back to List");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1292, 27, true);
            WriteLiteral("\r\n        </div>\r\n       \r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TennisCourt.Models.Schedule> Html { get; private set; }
    }
}
#pragma warning restore 1591
