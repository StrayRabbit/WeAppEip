CKEDITOR.editorConfig = function (config) {
    config.toolbar = "Basic";
    config.toolbar_Basic = [
        ["Source", "-", "NewPage", "DocProps", "Preview", "-"],
        ["Cut", "Copy", "Paste", "PasteText", "PasteFromWord", "-", "Undo", "Redo"],
        ["Find", "Replace", "-", "SelectAll", "-", "SpellChecker"],
        ["Bold", "Italic", "Underline", "Strike", "Subscript", "Superscript", "-", "RemoveFormat"],
        ["NumberedList", "BulletedList", "-", "Outdent", "Indent", "-", "Blockquote", "CreateDiv", "-", "JustifyLeft", "JustifyCenter", "JustifyRight", "JustifyBlock", "-", "BidiLtr", "BidiRtl"],
        ["Link", "Unlink", "Anchor"],
        ["Image", "Flash", "Table", "HorizontalRule", "Smiley"],
        ["Styles", "Format", "Font", "FontSize"],
        ["TextColor", "BGColor"],
        ["Maximize", "ShowBlocks"]
    ];

    // not needed in the Standard(s) toolbar.
    config.removeButtons = "Underline,Subscript,Superscript";

    // Simplify the dialog windows.
    config.removeDialogTabs = "image:advanced;link:advanced";

    //当提交包含有此编辑器的表单时，是否自动更新元素内的数据
    config.autoUpdateElement = true;

    config.filebrowserUploadUrl = "/System/UploadFile/RichTextControlUpload";

    //界面的语言配置 设置为'zh-cn'即可
    config.defaultLanguage = "zh-cn";

    //编辑器的z-index值
    config.baseFloatZIndex = 10000;

    //设置是使用绝对目录还是相对目录，为空为相对目录
    config.baseHref = "";

    //设置编辑内元素的背景色的取值 
    config.colorButton_backStyle =
        {
            element: "span",
            styles: { 'background-color': "#(color)" }
        };

    //设置前景色的取值 
    config.colorButton_colors = "000,800000,8B4513,2F4F4F,008080,000080,4B0082,696969,B22222,A52A2A,DAA520,006400,40E0D0,0000CD,800080,808080,F00,FF8C00,FFD700,008000,0FF,00F,EE82EE,A9A9A9,FFA07A,FFA500,FFFF00,00FF00,AFEEEE,ADD8E6,DDA0DD,D3D3D3,FFF0F5,FAEBD7,FFFFE0,F0FFF0,F0FFFF,F0F8FF,E6E6FA,FFF";

    //是否在选择颜色时显示“其它颜色”选项
    config.colorButton_enableMore = false;

    //区块的前景色默认值设置
    config.colorButton_foreStyle =
        {
            element: "span",
            styles: { 'color': "#(color)" }
        };

    //所需要添加的CSS文件 在此添加 可使用相对路径和网站的绝对路径
    config.contentsCss = "/ckeditor/contents.css";

    //文字方向
    config.contentsLangDirection = "ltr";//从左到右

    //界面编辑框的背景色
    config.dialog_backgroundCoverColor = "rgb(255, 254, 253)"; //可设置参考
    config.dialog_backgroundCoverColor = "white"; //默认

    //背景的不透明度 数值应该在：0.0～1.0 之间
    config.dialog_backgroundCoverOpacity = 0.5;

    //移动或者改变元素时 边框的吸附距离 单位：像素
    config.dialog_magnetDistance = 20;

    //进行表格编辑功能
    config.disableNativeTableHandles = true; //默认为不开启

    //设置宽
    config.width = 600;

    //设置高
    config.height = 200;

    //是否使用HTML实体进行输出
    config.entities = true;

    //使用搜索时的高亮色
    config.find_highlight =
        {
            element: "span",
            styles: { 'background-color': "#ff0", 'color': "#00f" }
        };

    //默认的字体名
    config.font_defaultLabel = "Arial";

    //字体编辑时的字符集 可以添加常用的中文字符
    config.font_names = "宋体;楷体_GB2312;新宋体;黑体;隶书;幼圆;微软雅黑;Arial";

    //文字的默认式样
    config.font_style =
        {
            element: "span",
            styles: { 'font-family': "#(family)" },
            overrides: [{ element: "font", attributes: { 'face': null } }]
        };

    //字体默认大小
    config.fontSize_defaultLabel = "12px";

    //字体编辑时可选的字体大小
    config.fontSize_sizes = "8/8px;9/9px;10/10px;11/11px;12/12px;14/14px;16/16px;18/18px;20/20px;22/22px;24/24px";

    //设置字体大小时 使用的式样
    config.fontSize_style =
        {
            element: "span",
            styles: { 'font-size': "#(size)" },
            overrides: [{ element: "font", attributes: { 'size': null } }]
        };

    //是否强制复制来的内容去除格式
    config.forcePasteAsPlainText = false;

    //是否强制用“&”来代替“&amp;”
    config.forceSimpleAmpersand = false;

    //对address标签进行格式化
    config.format_address = { element: "address", attributes: { "class": "styledAddress" } };

    //对DIV标签自动进行格式化
    config.format_div = { element: "div", attributes: { "class": "normalDiv" } };

    //对H1标签自动进行格式化
    config.format_h1 = { element: "h1", attributes: { "class": "contentTitle1" } };

    //对H2标签自动进行格式化
    config.format_h2 = { element: "h2", attributes: { "class": "contentTitle2" } };

    //对H3标签自动进行格式化
    config.format_h3 = { element: "h3", attributes: { "class": "contentTitle3" } };

    //对H4标签自动进行格式化
    config.format_h4 = { element: "h4", attributes: { "class": "contentTitle4" } };

    //对P标签自动进行格式化
    config.format_p = { element: "p", attributes: { "class": "normalPara" } };

    //对PRE标签自动进行格式化
    config.format_pre = { element: "pre", attributes: { "class": "code" } };

    //用分号分隔的标签名字 在工具栏上显示
    config.format_tags = "p;h1;h2;h3;h4;pre;address;div";

    //是否使用完整的html编辑模式 如使用，其源码将包含：<html><body></body></html>等标签
    config.fullPage = false;

    //是否忽略段落中的空字符 若不忽略 则字符将以“”表示
    config.ignoreEmptyParagraph = true;

    //在清除图片属性框中的链接属性时 是否同时清除两边的<a>标签
    config.image_removeLinkByEmptyURL = true;

    //一组用逗号分隔的标签名称，显示在左下角的层次嵌套中
    config.menu_groups = "clipboard,form,tablecell,tablecellproperties,tablerow,tablecolumn,table,anchor,link,image,flash,checkbox,radio,textfield,hiddenfield,imagebutton,button,select,textarea";

    //显示子菜单时的延迟，单位：ms
    config.menu_subMenuDelay = 400;

    //当执行“新建”命令时，编辑器中的内容
    config.newpage_html = "";

    //当从word里复制文字进来时，是否进行文字的格式化去除
    config.pasteFromWordIgnoreFontFace = true; //默认为忽略格式

    //是否使用<h1><h2>等标签修饰或者代替从word文档中粘贴过来的内容
    config.pasteFromWordKeepsStructure = false;

    //从word中粘贴内容时是否移除格式
    config.pasteFromWordRemoveStyle = false;

    //对应后台语言的类型来对输出的HTML内容进行格式化
    config.protectedSource.push(/(]+>[\s|\S]*?<\/asp:[^\>]+>)|(]+\/>)/gi);

    //清空预览区域显示内容
    config.image_previewText = "";

    //是否允许改变大小
    config.resize_enabled = true;

    //改变大小的最大高度
    config.resize_maxHeight = 400;

    //改变大小的最大宽度
    config.resize_maxWidth = 800;

    //改变大小的最小高度
    config.resize_minHeight = 200;

    //改变大小的最小宽度
    config.resize_minWidth = 600;

    //当输入：shift+Enter是插入的标签
    config.shiftEnterMode = CKEDITOR.ENTER_P; //可选：CKEDITOR.ENTER_BR或CKEDITOR.ENTER_DIV

    //可选的表情替代字符
    config.smiley_descriptions = [
        ":)", ":(", ";)", ":D", ":/", ":P",
        "", "", "", "", "", "",
        "", ";(", "", "", "", "",
        "", ":kiss", ""];

    //对应的表情图片
    config.smiley_images = [
        "regular_smile.gif", "sad_smile.gif", "wink_smile.gif", "teeth_smile.gif", "confused_smile.gif", "tounge_smile.gif",
        "embaressed_smile.gif", "omg_smile.gif", "whatchutalkingabout_smile.gif", "angry_smile.gif", "angel_smile.gif", "shades_smile.gif",
        "devil_smile.gif", "cry_smile.gif", "lightbulb.gif", "thumbs_down.gif", "thumbs_up.gif", "heart.gif",
        "broken_heart.gif", "kiss.gif", "envelope.gif"];

    //表情的地址
    config.smiley_path = "/ckeditor/plugins/smiley/images/";

    //页面载入时，编辑框是否立即获得焦点
    config.startupFocus = false;

    //载入时，以何种方式编辑 源码和所见即所得 "source"和"wysiwyg"
    config.startupMode = "wysiwyg";

    //载入时，是否显示框体的边框
    config.startupOutlineBlocks = false;

    //当用户键入TAB时，编辑器走过的空格数，(&nbsp;) 当值为0时，焦点将移出编辑框
    config.tabSpaces = 4;

    //主题
    config.theme = "bootstrapck";

    //工具栏是否可以被收缩
    config.toolbarCanCollapse = false;

    //工具栏的位置 可选：bottom
    config.toolbarLocation = "top";

    //工具栏默认是否展开
    config.toolbarStartupExpanded = true;

    //撤销的记录步数 
    config.undoStackSize = 20;
};