#pragma checksum "E:\Work\WeAppEip\Web\Areas\System\Views\Banner\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9f457ca5c6a9619c6c8b3c03f4a8837b7f911ae2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_System_Views_Banner_Detail), @"mvc.1.0.view", @"/Areas/System/Views/Banner/Detail.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/System/Views/Banner/Detail.cshtml", typeof(AspNetCore.Areas_System_Views_Banner_Detail))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9f457ca5c6a9619c6c8b3c03f4a8837b7f911ae2", @"/Areas/System/Views/Banner/Detail.cshtml")]
    public class Areas_System_Views_Banner_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WeAppEip.Web.ViewModels.Banner.BannerViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/fileinput.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/fileinput.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/fileinput_locale_zh.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "E:\Work\WeAppEip\Web\Areas\System\Views\Banner\Detail.cshtml"
  
    Layout = "~/Areas/System/Views/Shared/_LayoutPageDig.cshtml";

#line default
#line hidden
            BeginContext(129, 305, true);
            WriteLiteral(@"
<div class=""container"">
    <div class=""row"">
        <section>
            <div class=""col-md-8 col-md-offset-2"">
                <div class=""page-header"">
                    <h2>Banner详情</h2>
                </div>
                <form class=""form-horizontal"" id=""form"">
                    ");
            EndContext();
            BeginContext(435, 29, false);
#line 14 "E:\Work\WeAppEip\Web\Areas\System\Views\Banner\Detail.cshtml"
               Write(Html.HiddenFor(m => Model.Id));

#line default
#line hidden
            EndContext();
            BeginContext(464, 204, true);
            WriteLiteral("\r\n                    <div class=\"form-group\">\r\n                        <label class=\"col-sm-3 control-label\">Banner图片</label>\r\n                        <div class=\"col-md-6\">\r\n                            ");
            EndContext();
            BeginContext(669, 39, false);
#line 18 "E:\Work\WeAppEip\Web\Areas\System\Views\Banner\Detail.cshtml"
                       Write(Html.Hidden("ImageUrl", Model.ImageUrl));

#line default
#line hidden
            EndContext();
            BeginContext(708, 356, true);
            WriteLiteral(@"
                            <input id=""Upload"" name=""Upload"" type=""file"" class=""file-loading"" />
                        </div>
                    </div>
                    <div class=""form-group"">
                        <label class=""col-sm-3 control-label"">排序</label>
                        <div class=""col-md-6"">
                            ");
            EndContext();
            BeginContext(1065, 85, false);
#line 25 "E:\Work\WeAppEip\Web\Areas\System\Views\Banner\Detail.cshtml"
                       Write(Html.TextBoxFor(p => p.Order, new { @class = "form-control", placeholder = "请输入数字" }));

#line default
#line hidden
            EndContext();
            BeginContext(1150, 258, true);
            WriteLiteral(@"
                        </div>
                    </div>
                    <div class=""form-group"">
                        <label class=""col-sm-3 control-label"">描述</label>
                        <div class=""col-md-6"">
                            ");
            EndContext();
            BeginContext(1409, 119, false);
#line 31 "E:\Work\WeAppEip\Web\Areas\System\Views\Banner\Detail.cshtml"
                       Write(Html.TextAreaFor(p => p.Description, new { @class = "form-control", placeholder = "请输入推荐理由", cols = "20", rows = "5" }));

#line default
#line hidden
            EndContext();
            BeginContext(1528, 505, true);
            WriteLiteral(@"
                        </div>
                    </div>
                    <div class=""text-center"">
                        <button class=""btn btn-primary btn-save"" type=""submit"" id=""submit""><i class=""fa fa-check""></i> <span>确定保存</span></button>
                        <button class=""btn btn-warning"" id=""btn-dig-close"" type=""button""><i class=""fa fa-reply-all""></i> 取消返回</button>
                    </div>
                </form>
            </div>
        </section>
    </div>
</div>
");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(2052, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(2058, 52, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "9f457ca5c6a9619c6c8b3c03f4a8837b7f911ae27834", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2110, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(2116, 41, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9f457ca5c6a9619c6c8b3c03f4a8837b7f911ae29168", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2157, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(2163, 51, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9f457ca5c6a9619c6c8b3c03f4a8837b7f911ae210423", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2214, 2044, true);
                WriteLiteral(@"
    <script>
        $(function () {
            ValidateForm();

            //Banner图片
            $(""#Upload"").uploadSinglePic(""Banner"", ""ImageUrl"", 1, ""form"");

            //提交按钮
            $(""#submit"").on(""click"", function () {
                var data = $(""#form"").data(""bootstrapValidator"");
                if (data) {
                    // 修复记忆的组件不验证
                    data.validate();
                    if (!data.isValid()) {
                        return false;
                    }
                    $.post(""/System/Banner/Save"", $(""#form"").serialize(), function (result) {
                        console.log(result);
                        debugger;
                        SubAjax.Success(result);
                    });
                }
                return false;
            });
        });

        //数据验证
        function ValidateForm() {
            $(""#form"").bootstrapValidator({
                excluded: ["":disabled""],//关键配置，表示只对于禁用域不进行验证，其他的表单元素都要验证
");
                WriteLiteral(@"                message: ""该项不能为空！"",
                feedbackIcons: {
                    valid: ""glyphicon glyphicon-ok"",
                    invalid: ""glyphicon glyphicon-remove"",
                    validating: ""glyphicon glyphicon-refresh""
                },
                fields: {
                    ""ImageUrl"": {
                        validators: {
                            notEmpty: {
                                message: ""请您上传Banner图片!""
                            }
                        }
                    },
                    ""Order"": {
                        validators: {
                            numeric: {
                                message: '只能输入数字'
                            }
                        }
                    },
                }
            });
            // 修复bootstrap validator重复向服务端提交bug
            $(""#form"").on(""success.form.bv"", function (e) {
                e.preventDefault();
            });
        }
    </script>
");
                EndContext();
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WeAppEip.Web.ViewModels.Banner.BannerViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
