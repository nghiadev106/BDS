#pragma checksum "D:\nghia\DoAnTotNghiep2022\Trang\BDS\BDS\Areas\Admin\Views\FengShui\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5c4c490fa7d8da6a80dc521bc797502c2a39923d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_FengShui_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/FengShui/Index.cshtml")]
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
#line 1 "D:\nghia\DoAnTotNghiep2022\Trang\BDS\BDS\Areas\Admin\Views\_ViewImports.cshtml"
using BDS;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\nghia\DoAnTotNghiep2022\Trang\BDS\BDS\Areas\Admin\Views\_ViewImports.cshtml"
using BDS.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c4c490fa7d8da6a80dc521bc797502c2a39923d", @"/Areas/Admin/Views/FengShui/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"827fc576c12b0dfbe1fa7d9c4b4127382c965ad6", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_FengShui_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BDS.Models.FengShuiViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "FengShui", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 2 "D:\nghia\DoAnTotNghiep2022\Trang\BDS\BDS\Areas\Admin\Views\FengShui\Index.cshtml"
  
    Layout = "_LayoutAdmin";
    var lstFengShuis = (List<BDS.Models.FengShuiViewModel>)ViewBag.lstFengShui;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<input type=\"hidden\" id=\"success\"");
            BeginWriteAttribute("value", " value=\"", 190, "\"", 218, 1);
#nullable restore
#line 7 "D:\nghia\DoAnTotNghiep2022\Trang\BDS\BDS\Areas\Admin\Views\FengShui\Index.cshtml"
WriteAttributeValue("", 198, TempData["success"], 198, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n<input type=\"hidden\" id=\"warning\"");
            BeginWriteAttribute("value", " value=\"", 257, "\"", 285, 1);
#nullable restore
#line 8 "D:\nghia\DoAnTotNghiep2022\Trang\BDS\BDS\Areas\Admin\Views\FengShui\Index.cshtml"
WriteAttributeValue("", 265, TempData["warning"], 265, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n<input type=\"hidden\" id=\"error\"");
            BeginWriteAttribute("value", " value=\"", 322, "\"", 348, 1);
#nullable restore
#line 9 "D:\nghia\DoAnTotNghiep2022\Trang\BDS\BDS\Areas\Admin\Views\FengShui\Index.cshtml"
WriteAttributeValue("", 330, TempData["error"], 330, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" />

<div class=""container-fluid"">
    <h1 class=""mt-4"">Danh s??ch b??i vi???t</h1>
    <ol class=""breadcrumb mb-4"">
        <li class=""breadcrumb-item""><a href=""/"">Trang ch???</a></li>
    </ol>
    <div class=""card mb-12"">
        <div class=""card-header"">
            <div class=""row"">
                <div class=""col-md-6 col-xs-12"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5c4c490fa7d8da6a80dc521bc797502c2a39923d6292", async() => {
                WriteLiteral("T???o m???i");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"card-body\">\r\n            <div class=\"table-responsive\">\r\n");
#nullable restore
#line 27 "D:\nghia\DoAnTotNghiep2022\Trang\BDS\BDS\Areas\Admin\Views\FengShui\Index.cshtml"
                 if (lstFengShuis.Count() > 0)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <table class=""table table-bordered"" id=""dataTable"" width=""100%"" cellspacing=""0"">
                        <thead>
                            <tr>
                                <th>STT</th>
                                <th>H??nh ???nh</th>
                                <th>T??n</th>
                                <th>Danh m???c</th>
                                <th>M?? t???</th>
                                <th>Tr???ng th??i</th>
                                <th>#</th>
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 42 "D:\nghia\DoAnTotNghiep2022\Trang\BDS\BDS\Areas\Admin\Views\FengShui\Index.cshtml"
                              
                                var stt = 0;
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 44 "D:\nghia\DoAnTotNghiep2022\Trang\BDS\BDS\Areas\Admin\Views\FengShui\Index.cshtml"
                                 foreach (var item in lstFengShuis)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>");
#nullable restore
#line 47 "D:\nghia\DoAnTotNghiep2022\Trang\BDS\BDS\Areas\Admin\Views\FengShui\Index.cshtml"
                               Write(Html.Raw(stt = stt + 1));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td><img");
            BeginWriteAttribute("src", " src=\"", 1954, "\"", 1971, 1);
#nullable restore
#line 48 "D:\nghia\DoAnTotNghiep2022\Trang\BDS\BDS\Areas\Admin\Views\FengShui\Index.cshtml"
WriteAttributeValue("", 1960, item.Image, 1960, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"width:60px;\" /></td>\r\n                                <td>");
#nullable restore
#line 49 "D:\nghia\DoAnTotNghiep2022\Trang\BDS\BDS\Areas\Admin\Views\FengShui\Index.cshtml"
                               Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 50 "D:\nghia\DoAnTotNghiep2022\Trang\BDS\BDS\Areas\Admin\Views\FengShui\Index.cshtml"
                               Write(item.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 51 "D:\nghia\DoAnTotNghiep2022\Trang\BDS\BDS\Areas\Admin\Views\FengShui\Index.cshtml"
                               Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 52 "D:\nghia\DoAnTotNghiep2022\Trang\BDS\BDS\Areas\Admin\Views\FengShui\Index.cshtml"
                                 if (item.Status == 1)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <td><span class=\"btn-success\">Ho???t ?????ng</span></td>\r\n");
#nullable restore
#line 55 "D:\nghia\DoAnTotNghiep2022\Trang\BDS\BDS\Areas\Admin\Views\FengShui\Index.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <td><span class=\"btn-danger\">Kh??a</span></td>\r\n");
#nullable restore
#line 59 "D:\nghia\DoAnTotNghiep2022\Trang\BDS\BDS\Areas\Admin\Views\FengShui\Index.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td>\r\n                                    <a");
            BeginWriteAttribute("href", " href=\"", 2658, "\"", 2694, 2);
            WriteAttributeValue("", 2665, "/Admin/FengShui/Edit/", 2665, 21, true);
#nullable restore
#line 61 "D:\nghia\DoAnTotNghiep2022\Trang\BDS\BDS\Areas\Admin\Views\FengShui\Index.cshtml"
WriteAttributeValue("", 2686, item.Id, 2686, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary glyphicon glyphicon-pencilt\"><i class=\"fa-solid fa-pencil\"></i></a>\r\n                                    <a class=\"btn btn-danger glyphicon glyphicon-trash\" onclick=\"return confirm(\'B???n c?? mu???n x??a kh??ng?\');\"");
            BeginWriteAttribute("href", " href=\"", 2927, "\"", 2975, 3);
#nullable restore
#line 62 "D:\nghia\DoAnTotNghiep2022\Trang\BDS\BDS\Areas\Admin\Views\FengShui\Index.cshtml"
WriteAttributeValue("", 2934, Url.Action("Delete","FengShui"), 2934, 32, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2966, "/", 2966, 1, true);
#nullable restore
#line 62 "D:\nghia\DoAnTotNghiep2022\Trang\BDS\BDS\Areas\Admin\Views\FengShui\Index.cshtml"
WriteAttributeValue("", 2967, item.Id, 2967, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa-solid fa-trash-can\"></i></a>\r\n                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 65 "D:\nghia\DoAnTotNghiep2022\Trang\BDS\BDS\Areas\Admin\Views\FengShui\Index.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </tbody>\r\n                    </table>\r\n");
#nullable restore
#line 69 "D:\nghia\DoAnTotNghiep2022\Trang\BDS\BDS\Areas\Admin\Views\FengShui\Index.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <span>Kh??ng c?? b??i vi???t n??o</span>\r\n");
#nullable restore
#line 73 "D:\nghia\DoAnTotNghiep2022\Trang\BDS\BDS\Areas\Admin\Views\FengShui\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BDS.Models.FengShuiViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
