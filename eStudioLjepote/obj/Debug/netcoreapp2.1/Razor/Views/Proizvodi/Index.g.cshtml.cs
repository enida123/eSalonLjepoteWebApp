#pragma checksum "C:\Users\enida\Desktop\Nova mapa\backup\eStudioLjepote\eStudioLjepote\Views\Proizvodi\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "66807f366e9728de8444a8f64af2b08a25f9e250"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Proizvodi_Index), @"mvc.1.0.view", @"/Views/Proizvodi/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Proizvodi/Index.cshtml", typeof(AspNetCore.Views_Proizvodi_Index))]
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
#line 1 "C:\Users\enida\Desktop\Nova mapa\backup\eStudioLjepote\eStudioLjepote\Views\_ViewImports.cshtml"
using eStudioLjepote;

#line default
#line hidden
#line 2 "C:\Users\enida\Desktop\Nova mapa\backup\eStudioLjepote\eStudioLjepote\Views\_ViewImports.cshtml"
using eStudioLjepote.Models;

#line default
#line hidden
#line 3 "C:\Users\enida\Desktop\Nova mapa\backup\eStudioLjepote\eStudioLjepote\Views\_ViewImports.cshtml"
using eStudioLjepote.ViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"66807f366e9728de8444a8f64af2b08a25f9e250", @"/Views/Proizvodi/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3abc7737fda811408f4a0f9adac80bc358957ca6", @"/Views/_ViewImports.cshtml")]
    public class Views_Proizvodi_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProizvodiListVM>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\enida\Desktop\Nova mapa\backup\eStudioLjepote\eStudioLjepote\Views\Proizvodi\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(65, 19, true);
            WriteLiteral("<div class=\"row\">\r\n");
            EndContext();
#line 6 "C:\Users\enida\Desktop\Nova mapa\backup\eStudioLjepote\eStudioLjepote\Views\Proizvodi\Index.cshtml"
     foreach (var proizvod in Model.Proizvodi)
    {
        

#line default
#line hidden
            BeginContext(148, 42, false);
#line 8 "C:\Users\enida\Desktop\Nova mapa\backup\eStudioLjepote\eStudioLjepote\Views\Proizvodi\Index.cshtml"
   Write(Html.Partial("ProizvodiPartial", proizvod));

#line default
#line hidden
            EndContext();
#line 8 "C:\Users\enida\Desktop\Nova mapa\backup\eStudioLjepote\eStudioLjepote\Views\Proizvodi\Index.cshtml"
                                                   
    }

#line default
#line hidden
            BeginContext(199, 6, true);
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProizvodiListVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
