#pragma checksum "D:\work\etec\ds2021-1\RpgMvc\Views\Armas\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1bbbfdf12f7a8209095502ec17f113594dde28ea"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Armas_Index), @"mvc.1.0.view", @"/Views/Armas/Index.cshtml")]
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
#line 1 "D:\work\etec\ds2021-1\RpgMvc\Views\_ViewImports.cshtml"
using RpgMvc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\work\etec\ds2021-1\RpgMvc\Views\_ViewImports.cshtml"
using RpgMvc.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1bbbfdf12f7a8209095502ec17f113594dde28ea", @"/Views/Armas/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0ea8742186739939b51d95376aeaeffef3697b50", @"/Views/_ViewImports.cshtml")]
    public class Views_Armas_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<RpgMvc.Models.ArmaViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\work\etec\ds2021-1\RpgMvc\Views\Armas\Index.cshtml"
        ViewBag.Title = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 4 "D:\work\etec\ds2021-1\RpgMvc\Views\Armas\Index.cshtml"
 if (@TempData["Mensagem"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-sucess\" role=\"start\">\r\n        ");
#nullable restore
#line 7 "D:\work\etec\ds2021-1\RpgMvc\Views\Armas\Index.cshtml"
   Write(TempData["Mensagem"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
#nullable restore
#line 9 "D:\work\etec\ds2021-1\RpgMvc\Views\Armas\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Relação de Armas</h2>\r\n<p>\r\n    ");
#nullable restore
#line 13 "D:\work\etec\ds2021-1\RpgMvc\Views\Armas\Index.cshtml"
Write(Html.ActionLink("Criar nova Arma", "Create"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <tr>\r\n        <th>\r\n            ");
#nullable restore
#line 18 "D:\work\etec\ds2021-1\RpgMvc\Views\Armas\Index.cshtml"
       Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
#nullable restore
#line 21 "D:\work\etec\ds2021-1\RpgMvc\Views\Armas\Index.cshtml"
       Write(Html.DisplayNameFor(model => model.Nome));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
#nullable restore
#line 24 "D:\work\etec\ds2021-1\RpgMvc\Views\Armas\Index.cshtml"
       Write(Html.DisplayNameFor(model => model.Dano));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </th>\r\n    </tr>\r\n");
#nullable restore
#line 27 "D:\work\etec\ds2021-1\RpgMvc\Views\Armas\Index.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <tr>\r\n        <td>\r\n            ");
#nullable restore
#line 31 "D:\work\etec\ds2021-1\RpgMvc\Views\Armas\Index.cshtml"
       Write(Html.DisplayFor(modelItem => item.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n            ");
#nullable restore
#line 34 "D:\work\etec\ds2021-1\RpgMvc\Views\Armas\Index.cshtml"
       Write(Html.DisplayFor(modelItem => item.Nome));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n            ");
#nullable restore
#line 37 "D:\work\etec\ds2021-1\RpgMvc\Views\Armas\Index.cshtml"
       Write(Html.DisplayFor(modelItem => item.Dano));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n            ");
#nullable restore
#line 40 "D:\work\etec\ds2021-1\RpgMvc\Views\Armas\Index.cshtml"
       Write(Html.ActionLink("Editar", "Edit", new { id = item.Id}));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n            ");
#nullable restore
#line 41 "D:\work\etec\ds2021-1\RpgMvc\Views\Armas\Index.cshtml"
       Write(Html.ActionLink("Detalhes", "Details", new { id = item.Id}));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n            ");
#nullable restore
#line 42 "D:\work\etec\ds2021-1\RpgMvc\Views\Armas\Index.cshtml"
       Write(Html.ActionLink("Deletar", "Delete", new { id = item.Id}
                , new { onclick = "return confirm('Deseja realmente exluir esta arma?');"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </td>\r\n    </tr>\r\n");
#nullable restore
#line 46 "D:\work\etec\ds2021-1\RpgMvc\Views\Armas\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<RpgMvc.Models.ArmaViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591