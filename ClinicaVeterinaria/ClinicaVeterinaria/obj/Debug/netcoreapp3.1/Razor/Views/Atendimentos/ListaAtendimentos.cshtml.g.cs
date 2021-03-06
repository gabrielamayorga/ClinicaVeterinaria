#pragma checksum "D:\Desenvolvimento de Sistemas Microsoft\VeterinariaVlinica\ClinicaVeterinaria\ClinicaVeterinaria\Views\Atendimentos\ListaAtendimentos.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "db57d97b19df9e7df1d0b53437c06c6f49b92c45"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Atendimentos_ListaAtendimentos), @"mvc.1.0.view", @"/Views/Atendimentos/ListaAtendimentos.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"db57d97b19df9e7df1d0b53437c06c6f49b92c45", @"/Views/Atendimentos/ListaAtendimentos.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c79411871257c70fc05d1652eff23a38f1135bb8", @"/Views/_ViewImports.cshtml")]
    public class Views_Atendimentos_ListaAtendimentos : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ClinicaVeterinaria.Models.Atendimento>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div style=""margin-top: 20px; padding:20px"">
    <div class=""row"">
        <div class=""col-md-12"" style=""text-align:center"">
            <label style=""font-size:50px; font-family:fantasy"">Atendimentos</label>
        </div>
    </div>
    <table class=""table"">
        <thead>
            <tr>
                <th scope=""col"">ID</th>
                <th scope=""col"">Bichinho</th>
                <th scope=""col"">Veterinário</th>
                <th scope=""col"">Data e hora</th>
                <th scope=""col"">Observações</th>
                <th scope=""col""></th>
                <th scope=""col""></th>
            </tr>
        </thead>

        <tbody>
");
#nullable restore
#line 22 "D:\Desenvolvimento de Sistemas Microsoft\VeterinariaVlinica\ClinicaVeterinaria\ClinicaVeterinaria\Views\Atendimentos\ListaAtendimentos.cshtml"
           foreach (var atendimento in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <th scope=\"row\">");
#nullable restore
#line 25 "D:\Desenvolvimento de Sistemas Microsoft\VeterinariaVlinica\ClinicaVeterinaria\ClinicaVeterinaria\Views\Atendimentos\ListaAtendimentos.cshtml"
                               Write(atendimento.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                    <td>");
#nullable restore
#line 26 "D:\Desenvolvimento de Sistemas Microsoft\VeterinariaVlinica\ClinicaVeterinaria\ClinicaVeterinaria\Views\Atendimentos\ListaAtendimentos.cshtml"
                   Write(atendimento.Bichinho.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 27 "D:\Desenvolvimento de Sistemas Microsoft\VeterinariaVlinica\ClinicaVeterinaria\ClinicaVeterinaria\Views\Atendimentos\ListaAtendimentos.cshtml"
                   Write(atendimento.Veterinario.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 28 "D:\Desenvolvimento de Sistemas Microsoft\VeterinariaVlinica\ClinicaVeterinaria\ClinicaVeterinaria\Views\Atendimentos\ListaAtendimentos.cshtml"
                   Write(atendimento.Data);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 29 "D:\Desenvolvimento de Sistemas Microsoft\VeterinariaVlinica\ClinicaVeterinaria\ClinicaVeterinaria\Views\Atendimentos\ListaAtendimentos.cshtml"
                   Write(atendimento.Observacao);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td><a");
            BeginWriteAttribute("href", " href=\"", 1114, "\"", 1199, 1);
#nullable restore
#line 30 "D:\Desenvolvimento de Sistemas Microsoft\VeterinariaVlinica\ClinicaVeterinaria\ClinicaVeterinaria\Views\Atendimentos\ListaAtendimentos.cshtml"
WriteAttributeValue("", 1121, Url.Action("AlterarAtendimento", "Atendimentos", new { id = atendimento.Id }), 1121, 78, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-dark\">Alterar</a></td>\r\n                    <td><a");
            BeginWriteAttribute("href", " href=\"", 1266, "\"", 1340, 1);
#nullable restore
#line 31 "D:\Desenvolvimento de Sistemas Microsoft\VeterinariaVlinica\ClinicaVeterinaria\ClinicaVeterinaria\Views\Atendimentos\ListaAtendimentos.cshtml"
WriteAttributeValue("", 1273, Url.Action("Remover", "Atendimentos", new { id = atendimento.Id }), 1273, 67, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("  class=\"btn btn-dark\">Excluir</a></td>\r\n                </tr>\r\n");
#nullable restore
#line 33 "D:\Desenvolvimento de Sistemas Microsoft\VeterinariaVlinica\ClinicaVeterinaria\ClinicaVeterinaria\Views\Atendimentos\ListaAtendimentos.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ClinicaVeterinaria.Models.Atendimento>> Html { get; private set; }
    }
}
#pragma warning restore 1591
