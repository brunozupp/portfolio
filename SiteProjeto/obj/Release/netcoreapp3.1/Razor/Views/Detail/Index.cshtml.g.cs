#pragma checksum "C:\Users\bruni\Desktop\Semestre8\Programacao\PrimeiroBimestre\ProvaPrimeiroBimestre\SiteProjeto\Views\Detail\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b643ccad199b7778c5f3152d6410bd12bc72ff21"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Detail_Index), @"mvc.1.0.view", @"/Views/Detail/Index.cshtml")]
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
#line 1 "C:\Users\bruni\Desktop\Semestre8\Programacao\PrimeiroBimestre\ProvaPrimeiroBimestre\SiteProjeto\Views\_ViewImports.cshtml"
using SiteProjeto;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\bruni\Desktop\Semestre8\Programacao\PrimeiroBimestre\ProvaPrimeiroBimestre\SiteProjeto\Views\_ViewImports.cshtml"
using SiteProjeto.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b643ccad199b7778c5f3152d6410bd12bc72ff21", @"/Views/Detail/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ba7c29105b7ed6d6d43a841053c8de764b7791da", @"/Views/_ViewImports.cshtml")]
    public class Views_Detail_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Infrastructure.Models.Detail>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Save", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\bruni\Desktop\Semestre8\Programacao\PrimeiroBimestre\ProvaPrimeiroBimestre\SiteProjeto\Views\Detail\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_PortfolioLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"d-flex row-hl\">\r\n    <h1 class=\"item-hl\">Detalhes do perfil</h1>\r\n\r\n");
#nullable restore
#line 11 "C:\Users\bruni\Desktop\Semestre8\Programacao\PrimeiroBimestre\ProvaPrimeiroBimestre\SiteProjeto\Views\Detail\Index.cshtml"
     if (Model?.ID != null && Model?.ID > 0)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"item-hl ml-auto\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b643ccad199b7778c5f3152d6410bd12bc72ff214637", async() => {
                WriteLiteral("Editar");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n");
#nullable restore
#line 16 "C:\Users\bruni\Desktop\Semestre8\Programacao\PrimeiroBimestre\ProvaPrimeiroBimestre\SiteProjeto\Views\Detail\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n<div>\r\n    <hr />\r\n\r\n");
#nullable restore
#line 22 "C:\Users\bruni\Desktop\Semestre8\Programacao\PrimeiroBimestre\ProvaPrimeiroBimestre\SiteProjeto\Views\Detail\Index.cshtml"
     if (Model == null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h5>Nenhum detalhe foi cadastrado ainda</h5>\r\n        <p>\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b643ccad199b7778c5f3152d6410bd12bc72ff216524", async() => {
                WriteLiteral("Criar ficha técnica");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </p>\r\n");
#nullable restore
#line 28 "C:\Users\bruni\Desktop\Semestre8\Programacao\PrimeiroBimestre\ProvaPrimeiroBimestre\SiteProjeto\Views\Detail\Index.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <dl class=\"row\">\r\n            <dt class=\"col-sm-2\">\r\n                ");
#nullable restore
#line 33 "C:\Users\bruni\Desktop\Semestre8\Programacao\PrimeiroBimestre\ProvaPrimeiroBimestre\SiteProjeto\Views\Detail\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.ID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"col-sm-10\">\r\n                ");
#nullable restore
#line 36 "C:\Users\bruni\Desktop\Semestre8\Programacao\PrimeiroBimestre\ProvaPrimeiroBimestre\SiteProjeto\Views\Detail\Index.cshtml"
           Write(Html.DisplayFor(model => model.ID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n            <dt class=\"col-sm-2\">\r\n                ");
#nullable restore
#line 39 "C:\Users\bruni\Desktop\Semestre8\Programacao\PrimeiroBimestre\ProvaPrimeiroBimestre\SiteProjeto\Views\Detail\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"col-sm-10\">\r\n                ");
#nullable restore
#line 42 "C:\Users\bruni\Desktop\Semestre8\Programacao\PrimeiroBimestre\ProvaPrimeiroBimestre\SiteProjeto\Views\Detail\Index.cshtml"
           Write(Html.DisplayFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n            <dt class=\"col-sm-2\">\r\n                ");
#nullable restore
#line 45 "C:\Users\bruni\Desktop\Semestre8\Programacao\PrimeiroBimestre\ProvaPrimeiroBimestre\SiteProjeto\Views\Detail\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"col-sm-10\">\r\n                ");
#nullable restore
#line 48 "C:\Users\bruni\Desktop\Semestre8\Programacao\PrimeiroBimestre\ProvaPrimeiroBimestre\SiteProjeto\Views\Detail\Index.cshtml"
           Write(Html.DisplayFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n            <dt class=\"col-sm-2\">\r\n                ");
#nullable restore
#line 51 "C:\Users\bruni\Desktop\Semestre8\Programacao\PrimeiroBimestre\ProvaPrimeiroBimestre\SiteProjeto\Views\Detail\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Phone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"col-sm-10\">\r\n                ");
#nullable restore
#line 54 "C:\Users\bruni\Desktop\Semestre8\Programacao\PrimeiroBimestre\ProvaPrimeiroBimestre\SiteProjeto\Views\Detail\Index.cshtml"
           Write(Html.DisplayFor(model => model.Phone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n            <dt class=\"col-sm-2\">\r\n                ");
#nullable restore
#line 57 "C:\Users\bruni\Desktop\Semestre8\Programacao\PrimeiroBimestre\ProvaPrimeiroBimestre\SiteProjeto\Views\Detail\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.BirthDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"col-sm-10\">\r\n                ");
#nullable restore
#line 60 "C:\Users\bruni\Desktop\Semestre8\Programacao\PrimeiroBimestre\ProvaPrimeiroBimestre\SiteProjeto\Views\Detail\Index.cshtml"
           Write(String.Format("{0:dd/MM/yyyy}", Model.BirthDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n            <dt class=\"col-sm-2\">\r\n                ");
#nullable restore
#line 63 "C:\Users\bruni\Desktop\Semestre8\Programacao\PrimeiroBimestre\ProvaPrimeiroBimestre\SiteProjeto\Views\Detail\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Linkedin));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"col-sm-10\">\r\n                ");
#nullable restore
#line 66 "C:\Users\bruni\Desktop\Semestre8\Programacao\PrimeiroBimestre\ProvaPrimeiroBimestre\SiteProjeto\Views\Detail\Index.cshtml"
           Write(Html.DisplayFor(model => model.Linkedin));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n            <dt class=\"col-sm-2\">\r\n                ");
#nullable restore
#line 69 "C:\Users\bruni\Desktop\Semestre8\Programacao\PrimeiroBimestre\ProvaPrimeiroBimestre\SiteProjeto\Views\Detail\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Instagram));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"col-sm-10\">\r\n                ");
#nullable restore
#line 72 "C:\Users\bruni\Desktop\Semestre8\Programacao\PrimeiroBimestre\ProvaPrimeiroBimestre\SiteProjeto\Views\Detail\Index.cshtml"
           Write(Html.DisplayFor(model => model.Instagram));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n            <dt class=\"col-sm-2\">\r\n                ");
#nullable restore
#line 75 "C:\Users\bruni\Desktop\Semestre8\Programacao\PrimeiroBimestre\ProvaPrimeiroBimestre\SiteProjeto\Views\Detail\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Facebook));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"col-sm-10\">\r\n                ");
#nullable restore
#line 78 "C:\Users\bruni\Desktop\Semestre8\Programacao\PrimeiroBimestre\ProvaPrimeiroBimestre\SiteProjeto\Views\Detail\Index.cshtml"
           Write(Html.DisplayFor(model => model.Facebook));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n            <dt class=\"col-sm-2\">\r\n                ");
#nullable restore
#line 81 "C:\Users\bruni\Desktop\Semestre8\Programacao\PrimeiroBimestre\ProvaPrimeiroBimestre\SiteProjeto\Views\Detail\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Nationality));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"col-sm-10\">\r\n                ");
#nullable restore
#line 84 "C:\Users\bruni\Desktop\Semestre8\Programacao\PrimeiroBimestre\ProvaPrimeiroBimestre\SiteProjeto\Views\Detail\Index.cshtml"
           Write(Html.DisplayFor(model => model.Nationality));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n            <dt class=\"col-sm-2\">\r\n                ");
#nullable restore
#line 87 "C:\Users\bruni\Desktop\Semestre8\Programacao\PrimeiroBimestre\ProvaPrimeiroBimestre\SiteProjeto\Views\Detail\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.About));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"col-sm-10\">\r\n                ");
#nullable restore
#line 90 "C:\Users\bruni\Desktop\Semestre8\Programacao\PrimeiroBimestre\ProvaPrimeiroBimestre\SiteProjeto\Views\Detail\Index.cshtml"
           Write(Html.DisplayFor(model => model.About));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n            <dt class=\"col-sm-2\">\r\n                ");
#nullable restore
#line 93 "C:\Users\bruni\Desktop\Semestre8\Programacao\PrimeiroBimestre\ProvaPrimeiroBimestre\SiteProjeto\Views\Detail\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Goals));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"col-sm-10\">\r\n                ");
#nullable restore
#line 96 "C:\Users\bruni\Desktop\Semestre8\Programacao\PrimeiroBimestre\ProvaPrimeiroBimestre\SiteProjeto\Views\Detail\Index.cshtml"
           Write(Html.DisplayFor(model => model.Goals));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n        </dl>\r\n");
#nullable restore
#line 99 "C:\Users\bruni\Desktop\Semestre8\Programacao\PrimeiroBimestre\ProvaPrimeiroBimestre\SiteProjeto\Views\Detail\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Infrastructure.Models.Detail> Html { get; private set; }
    }
}
#pragma warning restore 1591