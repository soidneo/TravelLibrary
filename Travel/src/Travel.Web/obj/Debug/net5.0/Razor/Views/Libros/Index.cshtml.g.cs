#pragma checksum "C:\Users\admin\source\repos\Travel\Travel\src\Travel.Web\Views\Libros\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2a8542192b8b9ed8f5811550f056242eef811487"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Libros_Index), @"mvc.1.0.view", @"/Views/Libros/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2a8542192b8b9ed8f5811550f056242eef811487", @"/Views/Libros/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"23ac09be4bcfaa7f9829a01d1a134874eaae1f3b", @"/Views/_ViewImports.cshtml")]
    public class Views_Libros_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Travel.Web.ViewModels.LibrosViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\admin\source\repos\Travel\Travel\src\Travel.Web\Views\Libros\Index.cshtml"
  
    ViewData["Title"] = "Libros Detalles";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h2>Libros (MVC View)</h2>\r\n\r\n");
#nullable restore
#line 7 "C:\Users\admin\source\repos\Travel\Travel\src\Travel.Web\Views\Libros\Index.cshtml"
 foreach (var item in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <hr class=\"my-12\" />\r\n    <h3>ISBN: ");
#nullable restore
#line 10 "C:\Users\admin\source\repos\Travel\Travel\src\Travel.Web\Views\Libros\Index.cshtml"
         Write(item.ISBN);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n    <h3><a");
            BeginWriteAttribute("href", " href=\"", 233, "\"", 258, 2);
            WriteAttributeValue("", 240, "/Libros/", 240, 8, true);
#nullable restore
#line 11 "C:\Users\admin\source\repos\Travel\Travel\src\Travel.Web\Views\Libros\Index.cshtml"
WriteAttributeValue("", 248, item.ISBN, 248, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 11 "C:\Users\admin\source\repos\Travel\Travel\src\Travel.Web\Views\Libros\Index.cshtml"
                                Write(item.Titulo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></h3>\r\n");
#nullable restore
#line 12 "C:\Users\admin\source\repos\Travel\Travel\src\Travel.Web\Views\Libros\Index.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Travel.Web.ViewModels.LibrosViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
