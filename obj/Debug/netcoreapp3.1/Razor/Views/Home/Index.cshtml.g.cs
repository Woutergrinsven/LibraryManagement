#pragma checksum "C:\Projects\Library project\LibraryManagement\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ea4f92a51202105f0fed0f59c13ddd9bc0aac98b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Projects\Library project\LibraryManagement\Views\_ViewImports.cshtml"
using Bibliotheek;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Projects\Library project\LibraryManagement\Views\_ViewImports.cshtml"
using Bibliotheek.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Projects\Library project\LibraryManagement\Views\_ViewImports.cshtml"
using Bibliotheek.Models.ViewModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Projects\Library project\LibraryManagement\Views\_ViewImports.cshtml"
using Bibliotheek.Models.ViewModel.Book;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ea4f92a51202105f0fed0f59c13ddd9bc0aac98b", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ce88d5fc154851a3fdcf40a1c2737df3739777a9", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Projects\Library project\LibraryManagement\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""text-center"">
    <h1 class=""display-4"">Welcome</h1>
    <a class=""nav-link text-dark"" href=""/user/register"">Register user</a>
    <a class=""nav-link text-dark"" href=""/book/create"">Create book</a>
    <a class=""nav-link text-dark"" href=""/user/jwtbearer"">Get jwt</a>
</div>

<script type=""text/javascript"">
    //function createBook() {
    //    fetch(""/book/create"", {
    //        method: 'post',
    //        headers: {
    //            'Accept': 'application/json',
    //            'Content-Type': 'application/json',
    //            'RequestVerificationToken': document.getElementById('RequestVerificationToken').value
    //        },
    //        body: '{""s"": ""abc""}'
    //    })
    //}
</script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
