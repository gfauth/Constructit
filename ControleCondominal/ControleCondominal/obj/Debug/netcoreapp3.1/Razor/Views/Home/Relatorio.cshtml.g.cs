#pragma checksum "E:\_Projetos\Construct IT\ControleCondominal\ControleCondominal\Views\Home\Relatorio.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "72d7ccf7a0a93c55b22499d8414eb24b81043e86"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Relatorio), @"mvc.1.0.view", @"/Views/Home/Relatorio.cshtml")]
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
#line 1 "E:\_Projetos\Construct IT\ControleCondominal\ControleCondominal\Views\_ViewImports.cshtml"
using ControleCondominal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\_Projetos\Construct IT\ControleCondominal\ControleCondominal\Views\_ViewImports.cshtml"
using ControleCondominal.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"72d7ccf7a0a93c55b22499d8414eb24b81043e86", @"/Views/Home/Relatorio.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5ec3f43568dc33ffeacde8859686c4c8ba776392", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Relatorio : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ControleCondominal.Models.Relatorio>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\_Projetos\Construct IT\ControleCondominal\ControleCondominal\Views\Home\Relatorio.cshtml"
  
    ViewData["Title"] = "Relatorio";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Relatorio</h1>\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 14 "E:\_Projetos\Construct IT\ControleCondominal\ControleCondominal\Views\Home\Relatorio.cshtml"
           Write(Html.DisplayNameFor(model => model.Bairro));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 17 "E:\_Projetos\Construct IT\ControleCondominal\ControleCondominal\Views\Home\Relatorio.cshtml"
           Write(Html.DisplayNameFor(model => model.QtdPets));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 22 "E:\_Projetos\Construct IT\ControleCondominal\ControleCondominal\Views\Home\Relatorio.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 26 "E:\_Projetos\Construct IT\ControleCondominal\ControleCondominal\Views\Home\Relatorio.cshtml"
               Write(Html.DisplayFor(modelItem => item.Bairro));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 29 "E:\_Projetos\Construct IT\ControleCondominal\ControleCondominal\Views\Home\Relatorio.cshtml"
               Write(Html.DisplayFor(modelItem => item.QtdPets));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 32 "E:\_Projetos\Construct IT\ControleCondominal\ControleCondominal\Views\Home\Relatorio.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ControleCondominal.Models.Relatorio>> Html { get; private set; }
    }
}
#pragma warning restore 1591
