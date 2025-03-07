#pragma checksum "C:\Projects\DotNet\DesafioMVC\Views\Home\Lotes.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4fd200cf65339eec738b46a5c8dd9bc2de865478"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Lotes), @"mvc.1.0.view", @"/Views/Home/Lotes.cshtml")]
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
#line 1 "C:\Projects\DotNet\DesafioMVC\Views\_ViewImports.cshtml"
using DesafioMVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Projects\DotNet\DesafioMVC\Views\_ViewImports.cshtml"
using DesafioMVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4fd200cf65339eec738b46a5c8dd9bc2de865478", @"/Views/Home/Lotes.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1a443293351d1bb8ff9cea475559de325c26e078", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Lotes : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<DesafioMVC.Models.LoteVacina>>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Projects\DotNet\DesafioMVC\Views\Home\Lotes.cshtml"
  
  Layout = "_Layout";
  ViewData["Title"] = "Lotes";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4fd200cf65339eec738b46a5c8dd9bc2de8654783224", async() => {
                WriteLiteral(@"
  <script src=""https://code.jquery.com/jquery-3.6.0.min.js""
    integrity=""sha256-/xUj+3OJU5yExlq6GSYGSHk7tPXikynS7ogEvDej/m4="" crossorigin=""anonymous""></script>
  <script src=""https://cdn.datatables.net/1.10.25/js/jquery.dataTables.min.js""></script>
  <script>
    $(document).ready(function () {
      $('#tabela').DataTable({
        ""searching"": false,
        ""language"": {
          ""lengthMenu"": ""Mostrando _MENU_ registros por página"",
          ""zeroRecords"": ""Nenhuma informação encontrada"",
          ""info"": ""Páginas: _PAGE_ / _PAGES_"",
          ""infoEmpty"": ""Páginas: 0 / _PAGES_"",
          ""search"": ""Buscar: "",
          ""paginate"": {
            ""first"": "" Primeiro "",
            ""last"": "" Último "",
            ""next"": "" Próximo "",
            ""previous"": "" Anterior ""
          }
        }
      });

    });
  </script>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
<h2>Lotes de vacina cadastrados</h2>
<hr />



<table id=""tabela"" class=""table table-striped table-bordered"">
  <thead>
    <tr>
      <th>ID</th>
      <th>Nome da vacina</th>
      <th>Identificação do lote</th>
      <th>Quantidade recebida<br>[Un.]</th>
      <th>Quantidade restante<br>[Un.]</th>
      <th>Data de recebimento</th>
      <th>Data de validade</th>
      <th>Status</th>
    </tr>
  </thead>
  <tbody>
");
#nullable restore
#line 52 "C:\Projects\DotNet\DesafioMVC\Views\Home\Lotes.cshtml"
     foreach (var lote in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("      <tr>\r\n        <td>");
#nullable restore
#line 55 "C:\Projects\DotNet\DesafioMVC\Views\Home\Lotes.cshtml"
       Write(lote.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td>");
#nullable restore
#line 56 "C:\Projects\DotNet\DesafioMVC\Views\Home\Lotes.cshtml"
       Write(lote.Vacina.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td>");
#nullable restore
#line 57 "C:\Projects\DotNet\DesafioMVC\Views\Home\Lotes.cshtml"
       Write(lote.Lote);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td>");
#nullable restore
#line 58 "C:\Projects\DotNet\DesafioMVC\Views\Home\Lotes.cshtml"
       Write(lote.QtdRecebida);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td>");
#nullable restore
#line 59 "C:\Projects\DotNet\DesafioMVC\Views\Home\Lotes.cshtml"
       Write(lote.QtdRestante);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td>");
#nullable restore
#line 60 "C:\Projects\DotNet\DesafioMVC\Views\Home\Lotes.cshtml"
       Write(lote.DataRecebimento.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td>");
#nullable restore
#line 61 "C:\Projects\DotNet\DesafioMVC\Views\Home\Lotes.cshtml"
       Write(lote.DataValidade.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td>\r\n");
#nullable restore
#line 63 "C:\Projects\DotNet\DesafioMVC\Views\Home\Lotes.cshtml"
            
            if (lote.Status == false)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("              <span class=\"text-danger\">Inativo</span>\r\n");
#nullable restore
#line 67 "C:\Projects\DotNet\DesafioMVC\Views\Home\Lotes.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("              <span class=\"text-success\">Ativo</span>\r\n");
#nullable restore
#line 71 "C:\Projects\DotNet\DesafioMVC\Views\Home\Lotes.cshtml"
            }
          

#line default
#line hidden
#nullable disable
            WriteLiteral("        </td>\r\n      </tr>\r\n");
#nullable restore
#line 75 "C:\Projects\DotNet\DesafioMVC\Views\Home\Lotes.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("  </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<DesafioMVC.Models.LoteVacina>> Html { get; private set; }
    }
}
#pragma warning restore 1591
