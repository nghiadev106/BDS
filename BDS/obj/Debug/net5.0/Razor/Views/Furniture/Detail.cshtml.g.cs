#pragma checksum "D:\nghia\DoAnTotNghiep2022\Trang\BDS\BDS\Views\Furniture\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "73d11b29f577e7d54a4c699f89f06e2dd34af915"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Furniture_Detail), @"mvc.1.0.view", @"/Views/Furniture/Detail.cshtml")]
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
#line 1 "D:\nghia\DoAnTotNghiep2022\Trang\BDS\BDS\Views\_ViewImports.cshtml"
using BDS;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\nghia\DoAnTotNghiep2022\Trang\BDS\BDS\Views\_ViewImports.cshtml"
using BDS.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"73d11b29f577e7d54a4c699f89f06e2dd34af915", @"/Views/Furniture/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7512db585fda6b7f823713d5654fd9710a107654", @"/Views/_ViewImports.cshtml")]
    public class Views_Furniture_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BDS.Model.Furniture>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\nghia\DoAnTotNghiep2022\Trang\BDS\BDS\Views\Furniture\Detail.cshtml"
  
    ViewData["Title"] = "Chi tiết tin";
    var relateds = (List<BDS.Model.Furniture>)ViewBag.relateds;
    var ListProject = (List<BDS.Model.Project>)ViewBag.ListProject;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div id=""body"" class=""body-container"">
    <div class=""breadcrumb"" style=""display: list-item;"">
        <div class=""uk-container uk-container-center"">
            <ul class=""uk-breadcrumb"">
                <li>
                    <a href=""/"" title=""Trang chủ"">
                        <i class=""fa fa-home""></i> Trang chủ
                    </a>
                </li>
                <li class=""uk-active"">
                    <a href=""/noi-ngoai-that"" title=""Nội - Ngoại thất"">Nội - Ngoại thất</a>
                </li>
                <li class=""uk-active"">
                    <a href=""#""");
            BeginWriteAttribute("title", " title=\"", 818, "\"", 837, 1);
#nullable restore
#line 21 "D:\nghia\DoAnTotNghiep2022\Trang\BDS\BDS\Views\Furniture\Detail.cshtml"
WriteAttributeValue("", 826, Model.Name, 826, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 21 "D:\nghia\DoAnTotNghiep2022\Trang\BDS\BDS\Views\Furniture\Detail.cshtml"
                                               Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</a>
                </li>
            </ul>
        </div>
    </div>
    <div class=""uk-container uk-container-center"">
        <div class=""uk-grid uk-grid-medium mb20"">
            <div class=""uk-width-large-1-3 mb15 uk-push-2-3"">

                <aside class=""aside"">
");
            WriteLiteral(@"                    <div class=""video uk-visible-large mb15"">
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
            WriteLiteral(@"  title=""Click để chat trực tuyến với bộ phận hỗ trợ"">
                                    <i class=""ico-sty i-yaho""></i>
                                </a>
                            </span>
                            <span>
                                <a rel=""nofollow"" target=""_blank""");
            BeginWriteAttribute("href", " href=\"", 9535, "\"", 9542, 0);
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
#line 164 "D:\nghia\DoAnTotNghiep2022\Trang\BDS\BDS\Views\Furniture\Detail.cshtml"
                                 if (ListProject.Count() > 0)
                                {
                                    foreach (var item in ListProject)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <div class=\"adversite-item uk-width-1-1 mb5\">\r\n                                            <a");
            BeginWriteAttribute("href", " href=\"", 10790, "\"", 10831, 4);
            WriteAttributeValue("", 10797, "/du-an/chi-tiet/", 10797, 16, true);
#nullable restore
#line 169 "D:\nghia\DoAnTotNghiep2022\Trang\BDS\BDS\Views\Furniture\Detail.cshtml"
WriteAttributeValue("", 10813, item.Url, 10813, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 10822, "/", 10822, 1, true);
#nullable restore
#line 169 "D:\nghia\DoAnTotNghiep2022\Trang\BDS\BDS\Views\Furniture\Detail.cshtml"
WriteAttributeValue("", 10823, item.Id, 10823, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("title", " title=\"", 10832, "\"", 10850, 1);
#nullable restore
#line 169 "D:\nghia\DoAnTotNghiep2022\Trang\BDS\BDS\Views\Furniture\Detail.cshtml"
WriteAttributeValue("", 10840, item.Name, 10840, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"img-cover\">\r\n                                                <img");
            BeginWriteAttribute("src", " src=\"", 10924, "\"", 10941, 1);
#nullable restore
#line 170 "D:\nghia\DoAnTotNghiep2022\Trang\BDS\BDS\Views\Furniture\Detail.cshtml"
WriteAttributeValue("", 10930, item.Image, 10930, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 10942, "\"", 10982, 4);
            WriteAttributeValue("", 10948, "/du-an/chi-tiet/", 10948, 16, true);
#nullable restore
#line 170 "D:\nghia\DoAnTotNghiep2022\Trang\BDS\BDS\Views\Furniture\Detail.cshtml"
WriteAttributeValue("", 10964, item.Url, 10964, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 10973, "/", 10973, 1, true);
#nullable restore
#line 170 "D:\nghia\DoAnTotNghiep2022\Trang\BDS\BDS\Views\Furniture\Detail.cshtml"
WriteAttributeValue("", 10974, item.Id, 10974, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                                            </a>\r\n                                        </div>\r\n");
#nullable restore
#line 173 "D:\nghia\DoAnTotNghiep2022\Trang\BDS\BDS\Views\Furniture\Detail.cshtml"
                                    }
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            </section>
                        </section>
                    </section>


                </aside>
                <script type=""text/javascript"" charset=""utf-8"">
                    $(document).ready(function () {
                        $(""#province"").on(""change"", function () {
                                        var id = $(""#province"").val();
                            $.ajax({
                                        url: ""/get-district"",
                                type: ""GET"",
                                data: { id: id },
                                success: function (result) {
                                    $(""#district"").html($('<option/>', { value: 0, text: '[Chọn Quận/Huyện]' }));
                                    $(""#ward"").html($('<option/>', { value: 0, text: '[Chọn Xã/Phường]' }));
                                    $.each(result, function (i, item) {
                                        $(""#district"").append('<option ");
            WriteLiteral(@"value=""' + item.id + '""> ' + item.name + ' </option>');
                                                });
                                            },
                                error: function (e) {
                                                alert(e);
                                            }
                                        });
                                    });

                        $(""#district"").on(""change"", function () {
                                        var id = $(""#district"").val();
                            $.ajax({
                                        url: ""/get-ward"",
                                type: ""GET"",
                                data: { id: id },
                                success: function (result) {
                                    $(""#ward"").html($('<option/>', { value: 0, text: '[Chọn Xã/Phường]' }));
                                    $.each(result, function (i, item) {
                                       ");
            WriteLiteral(@" $(""#ward"").append('<option value=""' + item.id + '""> ' + item.name + ' </option>');
                                                });
                                            },
                                error: function (e) {
                                                alert(e);
                                            }
                                        });
                                    });
                                });
                </script>
            </div>
            <div class=""uk-width-large-2-3 mb15 uk-pull-1-3"">
                <section class=""estate-detail mb15"">
                    <section class=""panel-body"">
                        <div class=""dv-ct-detail bor_bottom mb10"">
                            <h1 class=""mb0"">");
#nullable restore
#line 226 "D:\nghia\DoAnTotNghiep2022\Trang\BDS\BDS\Views\Furniture\Detail.cshtml"
                                       Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n                        </div>\r\n                        <div class=\"meta_time mb5\">\r\n                            Đăng ngày: ");
#nullable restore
#line 229 "D:\nghia\DoAnTotNghiep2022\Trang\BDS\BDS\Views\Furniture\Detail.cshtml"
                                  Write(Model.CreateDate.Value.ToString("MM/dd/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </div>

                        <div class=""meta"">
                        </div>
                        <div class=""gallerys_excerpt"">
                            <div class=""uk-grid lib-grid-0"">
                                <div class=""uk-width-large-1-2"">
                                    <script>
                                        $(document).ready(function () {
                                            $(""#content-slider"").lightSlider({
                                                loop: true,
                                                keyPress: true
                                            });
                                            $('#image-gallery').lightSlider({
                                                gallery: true,
                                                item: 1,
                                                thumbItem: 6,
                                                slideMargin: 0,
                          ");
            WriteLiteral(@"                      speed: 2500,
                                                auto: false,
                                                loop: true,
                                                onSliderLoad: function () {
                                                    $('#image-gallery').removeClass('cS-hidden');
                                                }
                                            });
                                        });
                                    </script>
                                </div>
                            </div><!-- .uk-grid -->
                        </div><!-- .gallerys_excerpt -->
                        <div class=""content mt15"" style=""display:flex;flex-direction:column"">
");
            WriteLiteral("                            <div style=\"height:100%\">\r\n                                ");
#nullable restore
#line 263 "D:\nghia\DoAnTotNghiep2022\Trang\BDS\BDS\Views\Furniture\Detail.cshtml"
                           Write(Html.Raw(Model.Detail));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </div>
                            <section class=""homepage-projects-small mb15"">
                                <header class=""panel-head"">
                                    <h3 class=""heading"">
                                        <span>Tin liên quan</span>
                                    </h3>
                                </header>
                                <section class=""panel-body box-padding-background"">
                                    <ul class=""uk-grid lib-grid-0 uk-grid-width-1-1 list-projects"">
");
#nullable restore
#line 273 "D:\nghia\DoAnTotNghiep2022\Trang\BDS\BDS\Views\Furniture\Detail.cshtml"
                                         if (relateds.Count() > 0)
                                        {
                                            foreach (var item in relateds)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                                <li>
                                                    <div class=""projects uk-flex lib-grid-10 Vip2"">
                                                        <i class=""i-bds-cc-1""></i>
                                                        <div class=""thumb"">
                                                            <a class=""image img-cover""");
            BeginWriteAttribute("href", " href=\"", 17394, "\"", 17435, 4);
            WriteAttributeValue("", 17401, "/noi-ngoai-that/", 17401, 16, true);
#nullable restore
#line 281 "D:\nghia\DoAnTotNghiep2022\Trang\BDS\BDS\Views\Furniture\Detail.cshtml"
WriteAttributeValue("", 17417, item.Url, 17417, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 17426, "/", 17426, 1, true);
#nullable restore
#line 281 "D:\nghia\DoAnTotNghiep2022\Trang\BDS\BDS\Views\Furniture\Detail.cshtml"
WriteAttributeValue("", 17427, item.Id, 17427, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("title", " title=\"", 17436, "\"", 17454, 1);
#nullable restore
#line 281 "D:\nghia\DoAnTotNghiep2022\Trang\BDS\BDS\Views\Furniture\Detail.cshtml"
WriteAttributeValue("", 17444, item.Name, 17444, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                                                <img");
            BeginWriteAttribute("src", " src=\"", 17526, "\"", 17543, 1);
#nullable restore
#line 282 "D:\nghia\DoAnTotNghiep2022\Trang\BDS\BDS\Views\Furniture\Detail.cshtml"
WriteAttributeValue("", 17532, item.Image, 17532, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 17544, "\"", 17560, 1);
#nullable restore
#line 282 "D:\nghia\DoAnTotNghiep2022\Trang\BDS\BDS\Views\Furniture\Detail.cshtml"
WriteAttributeValue("", 17550, item.Name, 17550, 10, false);

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
            BeginWriteAttribute("href", " href=\"", 18048, "\"", 18089, 4);
            WriteAttributeValue("", 18055, "/noi-ngoai-that/", 18055, 16, true);
#nullable restore
#line 288 "D:\nghia\DoAnTotNghiep2022\Trang\BDS\BDS\Views\Furniture\Detail.cshtml"
WriteAttributeValue("", 18071, item.Url, 18071, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 18080, "/", 18080, 1, true);
#nullable restore
#line 288 "D:\nghia\DoAnTotNghiep2022\Trang\BDS\BDS\Views\Furniture\Detail.cshtml"
WriteAttributeValue("", 18081, item.Id, 18081, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("title", " title=\"", 18090, "\"", 18108, 1);
#nullable restore
#line 288 "D:\nghia\DoAnTotNghiep2022\Trang\BDS\BDS\Views\Furniture\Detail.cshtml"
WriteAttributeValue("", 18098, item.Name, 18098, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"color: rgb(255, 114, 0) !important;\">\r\n                                                                    ");
#nullable restore
#line 289 "D:\nghia\DoAnTotNghiep2022\Trang\BDS\BDS\Views\Furniture\Detail.cshtml"
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
#line 293 "D:\nghia\DoAnTotNghiep2022\Trang\BDS\BDS\Views\Furniture\Detail.cshtml"
                                                           Write(item.CreateDate.Value.ToString("MM/dd/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                            </div>\r\n                                                            <div class=\"projects_desc\">\r\n                                                                ");
#nullable restore
#line 296 "D:\nghia\DoAnTotNghiep2022\Trang\BDS\BDS\Views\Furniture\Detail.cshtml"
                                                           Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                                <a");
            BeginWriteAttribute("href", " href=\"", 18877, "\"", 18918, 4);
            WriteAttributeValue("", 18884, "/noi-ngoai-that/", 18884, 16, true);
#nullable restore
#line 297 "D:\nghia\DoAnTotNghiep2022\Trang\BDS\BDS\Views\Furniture\Detail.cshtml"
WriteAttributeValue("", 18900, item.Url, 18900, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 18909, "/", 18909, 1, true);
#nullable restore
#line 297 "D:\nghia\DoAnTotNghiep2022\Trang\BDS\BDS\Views\Furniture\Detail.cshtml"
WriteAttributeValue("", 18910, item.Id, 18910, 8, false);

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
#line 302 "D:\nghia\DoAnTotNghiep2022\Trang\BDS\BDS\Views\Furniture\Detail.cshtml"
                                            }
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                    </ul>
                                </section><!-- .panel-body -->
                            </section><!-- .top-content -->

                        </div>
                    </section><!-- .panel-body -->
                </section><!-- .estate-detail -->
                <section class=""estate-same"">
                </section><!-- .estate-same -->
            </div>
        </div>
    </div>
</div>


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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BDS.Model.Furniture> Html { get; private set; }
    }
}
#pragma warning restore 1591