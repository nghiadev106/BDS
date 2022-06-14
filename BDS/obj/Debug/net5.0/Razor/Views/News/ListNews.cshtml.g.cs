#pragma checksum "D:\DA\BSD\BDS\BDS\Views\News\ListNews.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bd2b128d3a8a17e0a8610bf76f63bf56f31a53d9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_News_ListNews), @"mvc.1.0.view", @"/Views/News/ListNews.cshtml")]
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
#line 1 "D:\DA\BSD\BDS\BDS\Views\_ViewImports.cshtml"
using BDS;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\DA\BSD\BDS\BDS\Views\_ViewImports.cshtml"
using BDS.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bd2b128d3a8a17e0a8610bf76f63bf56f31a53d9", @"/Views/News/ListNews.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7512db585fda6b7f823713d5654fd9710a107654", @"/Views/_ViewImports.cshtml")]
    public class Views_News_ListNews : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BDS.Models.PaginationSet<BDS.Model.News>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\DA\BSD\BDS\BDS\Views\News\ListNews.cshtml"
  
    ViewData["Title"] = "Danh mục tin tức";
    var ListCate = (List<BDS.Model.NewsCategory>)ViewBag.ListCate;
    var ListNews = (List<BDS.Model.News>)ViewBag.ListNews;
    var ListProject = (List<BDS.Model.Project>)ViewBag.ListProject;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div id=""body"" class=""body-container"">
    <div class=""breadcrumb"" style=""        display: list-item;"">
        <div class=""uk-container uk-container-center"">
            <ul class=""uk-breadcrumb"">
                <li>
                    <a href=""/"" title=""Trang chủ"">
                        <i class=""fa fa-home""></i> Trang chủ
                    </a>
                </li>
                <li class=""uk-active"">
                    <a href=""#"" title=""Tin tức"">Tin tức</a>
                </li>
            </ul>
        </div>
    </div>
    <div class=""uk-container uk-container-center"">
        <div class=""uk-grid uk-grid-medium mb20"">
            <div class=""uk-width-large-1-3 mb15 uk-push-2-3"">
                <aside class=""aside"">
");
            WriteLiteral(@"
                    <div class=""video uk-visible-large mb15"">
                        <iframe width=""100%"" height=""100%"" src=""https://www.youtube.com/embed/VswHarlC4gs""
                                frameborder=""0"" allowfullscreen></iframe>
                    </div>
                    <div class=""dv-boxhotline-r uk-visible-large uk-flex-middle uk-flex uk-flex-space-between"">
                        <div class=""dv-hl uk-flex-middle uk-flex uk-flex-left lib-grid-10"">
                            <i class=""ico-sty i-hotline""></i>
                            <label>Hotline</label>
                            <a title=""Hotline trợ giúp trực tiếp""
                               href=""tel: 02466.759.435 -  0948.242.555"">02466.759.435 -  0948.242.555</a>
                        </div>
                        <div class=""dv-sca uk-flex-middle uk-flex uk-flex-right"">
                            <span>
                                <a href=""skype: xiontungbatuoc?chat""
                               ");
            WriteLiteral(@"    title=""Click để chat trực tuyến với bộ phận hỗ trợ"">
                                    <i class=""ico-sty i-yaho""></i>
                                </a>
                            </span>
                            <span>
                                <a rel=""nofollow"" target=""_blank""");
            BeginWriteAttribute("href", " href=\"", 9083, "\"", 9090, 0);
            EndWriteAttribute();
            WriteLiteral(@"
                                   title=""Hãy theo dõi chúng tôi trên Google +"">
                                    <i class=""ico-sty i-google""></i>
                                </a>
                            </span>
                            <span>
                                <a rel=""nofollow"" title=""Hãy theo dõi chúng tôi trên facebook"" target=""_blank""
                                   href=""https://www.facebook.com/Gamuda-Garden-N%C6%A1i-ng%C3%B4i-nh%C3%A0-l%C3%A0-t%E1%BB%95-%E1%BA%A5m-801984929967755/?ref=bookmarks%5C""><i class=""ico-sty i-face""></i></a>
                            </span>
                        </div>
                    </div>


                    <section class=""aside-gallery uk-visible-large mt15"">
                        <section class=""panel-body home-branch"">
                            <section class=""panel-body uk-grid lib-grid-20"">
");
#nullable restore
#line 162 "D:\DA\BSD\BDS\BDS\Views\News\ListNews.cshtml"
                                 if (ListProject.Count() > 0)
                                {
                                    foreach (var item in ListProject)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <div class=\"adversite-item uk-width-1-1 mb5\">\r\n                                            <a");
            BeginWriteAttribute("href", " href=\"", 10338, "\"", 10379, 4);
            WriteAttributeValue("", 10345, "/du-an/chi-tiet/", 10345, 16, true);
#nullable restore
#line 167 "D:\DA\BSD\BDS\BDS\Views\News\ListNews.cshtml"
WriteAttributeValue("", 10361, item.Url, 10361, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 10370, "/", 10370, 1, true);
#nullable restore
#line 167 "D:\DA\BSD\BDS\BDS\Views\News\ListNews.cshtml"
WriteAttributeValue("", 10371, item.Id, 10371, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("title", " title=\"", 10380, "\"", 10398, 1);
#nullable restore
#line 167 "D:\DA\BSD\BDS\BDS\Views\News\ListNews.cshtml"
WriteAttributeValue("", 10388, item.Name, 10388, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"img-cover\">\r\n                                                <img");
            BeginWriteAttribute("src", " src=\"", 10472, "\"", 10489, 1);
#nullable restore
#line 168 "D:\DA\BSD\BDS\BDS\Views\News\ListNews.cshtml"
WriteAttributeValue("", 10478, item.Image, 10478, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 10490, "\"", 10506, 1);
#nullable restore
#line 168 "D:\DA\BSD\BDS\BDS\Views\News\ListNews.cshtml"
WriteAttributeValue("", 10496, item.Name, 10496, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                                            </a>\r\n                                        </div>\r\n");
#nullable restore
#line 171 "D:\DA\BSD\BDS\BDS\Views\News\ListNews.cshtml"

                                    }
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </section>
                        </section>
                    </section>


                </aside>
            </div>
            <div class=""uk-width-large-2-3 mb15 uk-pull-1-3"">
                <section class=""main-content big"">
                    <section class=""project-catalogue"">
                        <header class=""panel-head"">
                            <h1 class=""heading-2 uk-flex uk-flex-middle uk-flex-space-between"">
                                <span>Tin tức</span>
                            </h1>
                        </header>
                        <section class=""panel-body"">
                            <ul class=""uk-grid lib-grid-0 uk-grid-width-1-1 list-projects"">
");
#nullable restore
#line 192 "D:\DA\BSD\BDS\BDS\Views\News\ListNews.cshtml"
                                 if (Model.Items.Count() > 0)
                                {
                                    foreach (var item in Model.Items)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                        <li>
                                            <div class=""projects uk-flex lib-grid-10 Vip2"">
                                                <i class=""i-bds-cc-1""></i>
                                                <div class=""thumb"">
                                                    <a class=""image img-cover""");
            BeginWriteAttribute("href", " href=\"", 12009, "\"", 12052, 4);
            WriteAttributeValue("", 12016, "/tin-tuc/chi-tiet/", 12016, 18, true);
#nullable restore
#line 200 "D:\DA\BSD\BDS\BDS\Views\News\ListNews.cshtml"
WriteAttributeValue("", 12034, item.Url, 12034, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 12043, "/", 12043, 1, true);
#nullable restore
#line 200 "D:\DA\BSD\BDS\BDS\Views\News\ListNews.cshtml"
WriteAttributeValue("", 12044, item.Id, 12044, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("title", " title=\"", 12053, "\"", 12071, 1);
#nullable restore
#line 200 "D:\DA\BSD\BDS\BDS\Views\News\ListNews.cshtml"
WriteAttributeValue("", 12061, item.Name, 12061, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                                        <img");
            BeginWriteAttribute("src", " src=\"", 12135, "\"", 12152, 1);
#nullable restore
#line 201 "D:\DA\BSD\BDS\BDS\Views\News\ListNews.cshtml"
WriteAttributeValue("", 12141, item.Image, 12141, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 12153, "\"", 12169, 1);
#nullable restore
#line 201 "D:\DA\BSD\BDS\BDS\Views\News\ListNews.cshtml"
WriteAttributeValue("", 12159, item.Name, 12159, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" />
                                                    </a>
                                                </div>
                                                <div class=""infor"">
                                                    <h4 class=""title"">
                                                        <img src=""/uploads/new-icon.gif"" alt=""gif"" style=""width: 22px"">
                                                        <a");
            BeginWriteAttribute("href", " href=\"", 12609, "\"", 12652, 4);
            WriteAttributeValue("", 12616, "/tin-tuc/chi-tiet/", 12616, 18, true);
#nullable restore
#line 207 "D:\DA\BSD\BDS\BDS\Views\News\ListNews.cshtml"
WriteAttributeValue("", 12634, item.Url, 12634, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 12643, "/", 12643, 1, true);
#nullable restore
#line 207 "D:\DA\BSD\BDS\BDS\Views\News\ListNews.cshtml"
WriteAttributeValue("", 12644, item.Id, 12644, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("title", " title=\"", 12653, "\"", 12671, 1);
#nullable restore
#line 207 "D:\DA\BSD\BDS\BDS\Views\News\ListNews.cshtml"
WriteAttributeValue("", 12661, item.Name, 12661, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"color: rgb(255, 114, 0) !important;\">\r\n                                                            ");
#nullable restore
#line 208 "D:\DA\BSD\BDS\BDS\Views\News\ListNews.cshtml"
                                                       Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                                        </a>
                                                    </h4>
                                                    <div class=""time_create"">
                                                        ");
#nullable restore
#line 212 "D:\DA\BSD\BDS\BDS\Views\News\ListNews.cshtml"
                                                   Write(item.CreateDate.Value.ToString("MM/dd/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </div>\r\n                                                    <div class=\"projects_desc\">\r\n                                                        ");
#nullable restore
#line 215 "D:\DA\BSD\BDS\BDS\Views\News\ListNews.cshtml"
                                                   Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                        <a");
            BeginWriteAttribute("href", " href=\"", 13368, "\"", 13411, 4);
            WriteAttributeValue("", 13375, "/tin-tuc/chi-tiet/", 13375, 18, true);
#nullable restore
#line 216 "D:\DA\BSD\BDS\BDS\Views\News\ListNews.cshtml"
WriteAttributeValue("", 13393, item.Url, 13393, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 13402, "/", 13402, 1, true);
#nullable restore
#line 216 "D:\DA\BSD\BDS\BDS\Views\News\ListNews.cshtml"
WriteAttributeValue("", 13403, item.Id, 13403, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" title=""Xem tiếp"">Xem tiếp</a>
                                                    </div>
                                                </div>
                                            </div><!-- .product -->
                                        </li>
");
#nullable restore
#line 221 "D:\DA\BSD\BDS\BDS\Views\News\ListNews.cshtml"
                                    }
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                            </ul>\r\n                            <div class=\"pagination\">\r\n");
#nullable restore
#line 227 "D:\DA\BSD\BDS\BDS\Views\News\ListNews.cshtml"
                                 if (Model.TotalPages > 1)
                                {
                                    // Create numeric links
                                    var startPageIndex = Math.Max(1, Model.Page - Model.MaxPage / 2);
                                    var endPageIndex = Math.Min(Model.TotalPages, Model.Page + Model.MaxPage / 2);


#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <nav>\r\n                                        <ul class=\"pagination\">\r\n");
#nullable restore
#line 235 "D:\DA\BSD\BDS\BDS\Views\News\ListNews.cshtml"
                                             if (Model.Page > 1)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                                <li class=""page-item"">
                                                    <a class=""page-link"" href=""?page=1"" aria-label=""First"">
                                                        <i class=""fa fa-angle-double-left""></i>
                                                    </a>
                                                </li>
                                                <li class=""page-item"">
                                                    <a class=""page-link""");
            BeginWriteAttribute("href", " href=\"", 14976, "\"", 15004, 2);
            WriteAttributeValue("", 14983, "?page=", 14983, 6, true);
#nullable restore
#line 243 "D:\DA\BSD\BDS\BDS\Views\News\ListNews.cshtml"
WriteAttributeValue("", 14989, Model.Page-1, 14989, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" aria-label=\"Previous\">\r\n                                                        <i class=\"fa fa-angle-double-left\"></i>\r\n                                                    </a>\r\n                                                </li>\r\n");
#nullable restore
#line 247 "D:\DA\BSD\BDS\BDS\Views\News\ListNews.cshtml"
                                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 248 "D:\DA\BSD\BDS\BDS\Views\News\ListNews.cshtml"
                                             for (int i = startPageIndex; i <= endPageIndex; i++)
                                            {
                                                if (Model.Page == i)
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <li class=\"active page-item\"><a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 15655, "\"", 15670, 2);
            WriteAttributeValue("", 15662, "?page=", 15662, 6, true);
#nullable restore
#line 252 "D:\DA\BSD\BDS\BDS\Views\News\ListNews.cshtml"
WriteAttributeValue("", 15668, i, 15668, 2, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("title", " title=\"", 15671, "\"", 15687, 2);
            WriteAttributeValue("", 15679, "Trang", 15679, 5, true);
#nullable restore
#line 252 "D:\DA\BSD\BDS\BDS\Views\News\ListNews.cshtml"
WriteAttributeValue(" ", 15684, i, 15685, 2, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 252 "D:\DA\BSD\BDS\BDS\Views\News\ListNews.cshtml"
                                                                                                                                  Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 253 "D:\DA\BSD\BDS\BDS\Views\News\ListNews.cshtml"
                                                }
                                                else
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <li class=\"page-item\"><a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 15952, "\"", 15967, 2);
            WriteAttributeValue("", 15959, "?page=", 15959, 6, true);
#nullable restore
#line 256 "D:\DA\BSD\BDS\BDS\Views\News\ListNews.cshtml"
WriteAttributeValue("", 15965, i, 15965, 2, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("title", " title=\"", 15968, "\"", 15984, 2);
            WriteAttributeValue("", 15976, "Trang", 15976, 5, true);
#nullable restore
#line 256 "D:\DA\BSD\BDS\BDS\Views\News\ListNews.cshtml"
WriteAttributeValue(" ", 15981, i, 15982, 2, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 256 "D:\DA\BSD\BDS\BDS\Views\News\ListNews.cshtml"
                                                                                                                           Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 257 "D:\DA\BSD\BDS\BDS\Views\News\ListNews.cshtml"
                                                }
                                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 259 "D:\DA\BSD\BDS\BDS\Views\News\ListNews.cshtml"
                                             if (Model.Page < Model.TotalPages)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <li class=\"page-item\">\r\n                                                    <a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 16369, "\"", 16397, 2);
            WriteAttributeValue("", 16376, "?page=", 16376, 6, true);
#nullable restore
#line 262 "D:\DA\BSD\BDS\BDS\Views\News\ListNews.cshtml"
WriteAttributeValue("", 16382, Model.Page+1, 16382, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" aria-label=""Next"">
                                                        <i class=""fa fa-angle-double-right""></i>
                                                    </a>
                                                </li>
                                                <li class=""page-item"">
                                                    <a class=""page-link""");
            BeginWriteAttribute("href", " href=\"", 16774, "\"", 16804, 2);
            WriteAttributeValue("", 16781, "?page=", 16781, 6, true);
#nullable restore
#line 267 "D:\DA\BSD\BDS\BDS\Views\News\ListNews.cshtml"
WriteAttributeValue("", 16787, Model.TotalPages, 16787, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" aria-label=\"Last\">\r\n                                                        <i class=\"fa fa-angle-double-right\"></i>\r\n                                                    </a>\r\n                                                </li>\r\n");
#nullable restore
#line 271 "D:\DA\BSD\BDS\BDS\Views\News\ListNews.cshtml"
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        </ul>\r\n                                    </nav>\r\n");
#nullable restore
#line 274 "D:\DA\BSD\BDS\BDS\Views\News\ListNews.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            </div>
                        </section><!-- .panel-body -->
                    </section><!-- .project-catalogue -->
                </section><!-- .main-content -->
            </div>
        </div>
    </div><!-- .wrapper -->
</div><!-- .page-body -->
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BDS.Models.PaginationSet<BDS.Model.News>> Html { get; private set; }
    }
}
#pragma warning restore 1591
