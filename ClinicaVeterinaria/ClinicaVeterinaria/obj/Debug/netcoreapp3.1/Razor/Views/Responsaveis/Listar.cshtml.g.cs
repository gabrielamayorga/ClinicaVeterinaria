#pragma checksum "D:\Desenvolvimento de Sistemas Microsoft\VeterinariaVlinica\ClinicaVeterinaria\ClinicaVeterinaria\Views\Responsaveis\Listar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fb09788fb1b563db4a9e66d6b11fed5586cf93b4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Responsaveis_Listar), @"mvc.1.0.view", @"/Views/Responsaveis/Listar.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fb09788fb1b563db4a9e66d6b11fed5586cf93b4", @"/Views/Responsaveis/Listar.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c79411871257c70fc05d1652eff23a38f1135bb8", @"/Views/_ViewImports.cshtml")]
    public class Views_Responsaveis_Listar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ClinicaVeterinaria.Models.Responsavel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div style=""margin-top: 20px; padding:20px"">
       <div class=""row"">
            <div class=""col-md-12"" style=""text-align:center"">
                <label style=""font-size:50px; font-family:fantasy"">Responsáveis</label>
            </div>
        </div>
    <table class=""table"">
        <thead>
            <tr>
                <th scope=""col"">ID</th>
                <th scope=""col"">Nome</th>
                <th scope=""col"">CPF</th>
                <th scope=""col""></th>
                <th scope=""col""></th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 19 "D:\Desenvolvimento de Sistemas Microsoft\VeterinariaVlinica\ClinicaVeterinaria\ClinicaVeterinaria\Views\Responsaveis\Listar.cshtml"
              foreach (var responsavel in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <th scope=\"row\">");
#nullable restore
#line 22 "D:\Desenvolvimento de Sistemas Microsoft\VeterinariaVlinica\ClinicaVeterinaria\ClinicaVeterinaria\Views\Responsaveis\Listar.cshtml"
                               Write(responsavel.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                    <td>");
#nullable restore
#line 23 "D:\Desenvolvimento de Sistemas Microsoft\VeterinariaVlinica\ClinicaVeterinaria\ClinicaVeterinaria\Views\Responsaveis\Listar.cshtml"
                   Write(responsavel.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 24 "D:\Desenvolvimento de Sistemas Microsoft\VeterinariaVlinica\ClinicaVeterinaria\ClinicaVeterinaria\Views\Responsaveis\Listar.cshtml"
                   Write(responsavel.CPF);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td><a");
            BeginWriteAttribute("href", " href=\"", 898, "\"", 983, 1);
#nullable restore
#line 25 "D:\Desenvolvimento de Sistemas Microsoft\VeterinariaVlinica\ClinicaVeterinaria\ClinicaVeterinaria\Views\Responsaveis\Listar.cshtml"
WriteAttributeValue("", 905, Url.Action("AlterarResponsavel", "Responsaveis", new { id = responsavel.Id }), 905, 78, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-dark\">Alterar</a></td>\r\n                    <td><a");
            BeginWriteAttribute("href", " href=\"", 1050, "\"", 1124, 1);
#nullable restore
#line 26 "D:\Desenvolvimento de Sistemas Microsoft\VeterinariaVlinica\ClinicaVeterinaria\ClinicaVeterinaria\Views\Responsaveis\Listar.cshtml"
WriteAttributeValue("", 1057, Url.Action("Remover", "Responsaveis", new { id = responsavel.Id }), 1057, 67, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-dark\">Excluir</a></td>\r\n                </tr>\r\n");
#nullable restore
#line 28 "D:\Desenvolvimento de Sistemas Microsoft\VeterinariaVlinica\ClinicaVeterinaria\ClinicaVeterinaria\Views\Responsaveis\Listar.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ClinicaVeterinaria.Models.Responsavel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
