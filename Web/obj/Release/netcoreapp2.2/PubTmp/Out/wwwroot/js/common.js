$(function () {
    //ios7 复选框
    var elems = Array.prototype.slice.call(document.querySelectorAll(".js-switch"));
    elems.forEach(function (html) {
        var switchery = new Switchery(html, { color: "#64bd63" });
    });

    //返回关闭
    $("#btn-dig-close").click(function () {
        dig.close();
    });
});

//加载提示 
var dig = {
    reload: function () {
        location.reload();
    },
    addPage: function (t, u, w, h, f) {
        top.dialog({
            title: t,
            url: u,
            width: w,
            height: h,
            onremove: function () { },
            onclose: f
        }).showModal();
    },
    addDefaultPage: function (t, u, f) {
        var width = window.screen.width * 0.7;
        var height = window.screen.height * 0.65;

        if (width < 1000) {
            width = 1000;
        }

        if (height < 500) {
            height = 500;
        }

        top.dialog({
            title: t,
            url: u,
            width: width,      //根据分辨率调整宽度
            height: height,     //根据分辨率调整高度
            onremove: function () { },
            onclose: f
        }).showModal();
    },
    remove: function () {
        var n = top.dialog.get(window);
        n.close().remove();
    },
    close: function () {
        var n = top.dialog.get(window);
        n.close();
    },
    success: function (t) {
        swal({
            title: t,
            text: "",
            type: "success",
            confirmButtonColor: "#DD6B55"
        });
    },
    successcallback: function (t, i) {
        swal({
            title: t,
            text: "",
            type: "success",
            showCancelButton: false,
            //closeOnConfirm: false,
            confirmButtonText: "确定",
            confirmButtonColor: "#ec6c62"
        }, function () {
            i && i();
        });
    },
    error: function (t) {
        swal({
            title: t,
            text: "",
            type: "error",
            confirmButtonColor: "#DD6B55"
        });
    },
    confirm: function (t, n, i, c) {
        swal({
            title: t,
            text: n,
            type: "warning",
            showCancelButton: true,
            closeOnConfirm: c,      //点击确定后，是否关闭。false 为不关闭
            confirmButtonText: "是的,我确定",
            confirmButtonColor: "#ec6c62",
            closeOnCancel: false
        }, function (isConfirm) {
            if (isConfirm) { i && i(); } else { swal({ title: "取消操作", text: "您已取消本次操作 :)", type: "error", confirmButtonColor: "#DD6B55" }); }
        });
    },
    msgsuccess: function (n) {
        swal({
            title: n,
            text: "",
            type: "success",
            timer: 2000,
            showConfirmButton: false
        });
    },
    msgerror: function (n) {
        swal({
            title: n,
            text: "",
            type: "error",
            timer: 2000,
            showConfirmButton: false
        });
    },
    msgwarning: function (n) {
        swal({
            title: n,
            text: "",
            type: "warning",
            timer: 2000,
            showConfirmButton: false
        });
    },
    logout: function () {
        swal({
            title: "退出系统",
            text: "您确定退出系统吗？",
            type: "warning",
            showCancelButton: true,
            closeOnConfirm: false,
            confirmButtonText: "是的,我确定",
            confirmButtonColor: "#ec6c62",
            closeOnConfirm: false,
            closeOnCancel: false
        }, function (isConfirm) {
            if (isConfirm) { window.location.href = "/System/Home/Login"; } else { swal({ title: "取消操作", text: "您已取消本次操作 :)", type: "error", confirmButtonColor: "#DD6B55" }); }
        });
    },
    msg: function (t, n) {
        swal(t, n);
    }
};
//增删改提交ajax
var SubAjax = {
    Success: function (result) {
        if (result.code == undefined) {
            document.writeln(result);
        } else if (result.code === 200) {
            var dialog = top.dialog.get(window);
            dig.successcallback(result.msg, function () {
                try {
                    dialog.returnValue = 200;

                    if (dialog !== "undefined" && dialog !== undefined) {
                        dialog.close();
                    } else {
                        try {
                            loadPage($("ul.treeview-menu li.active a").data("url")); //重新加载页面
                        } catch (e) {
                            location.reload();
                        }
                    }
                } catch (e) {
                    loadPage($("ul.treeview-menu li.active a").data("url")); //重新加载页面
                }
            });
        } else {
            dig.error(result.msg);
            SubAjax.Complete();
        }
    },
    SuccessInclude: function (result, data) {
        if (result.Status == undefined) {
            document.writeln(result);
        } else if (result.code === 200) {
            var dialog = top.dialog.get(window);
            dig.successcallback(result.msg, function () {
                try {
                    dialog.returnValue = data;

                    if (dialog !== "undefined" && dialog !== undefined) {
                        dialog.close();
                    } else {
                        try {
                            loadPage($("ul.treeview-menu li.active a").data("url")); //重新加载页面
                        } catch (e) {
                            location.reload();
                        }
                    }
                } catch (e) {
                    loadPage($("ul.treeview-menu li.active a").data("url")); //重新加载页面
                }
            });
        } else {
            dig.error(result.msg);
            SubAjax.Complete();
        }
    },
    SuccessBack: function (result) {
        if (result.code === 200) {
            dig.successcallback(result.msg, function () {
                if (result.ReUrl === "undefined" || result.ReUrl === "" || result.ReUrl == undefined) {
                    history.go(-1);
                }
                else { window.location.href = result.ReUrl; }
            });
        } else {
            dig.error(result.msg);
            SubAjax.Complete();
        }
    },
    Failure: function () {
        dig.error("网络超时,请稍后再试...");
        SubAjax.Complete();
    },
    Complete: function () {
        $(".btn-save").attr("disabled", false).find("span").html("确定保存");
    }
};
//验证按钮权限
function VaildatePermission(v) {
    var permissionlist = v;
    if (permissionlist !== "" && permissionlist != undefined) {
        var permission = "";
        $.each(permissionlist, function (p, t) {
            permission += t.Code + ",";
        });
        permission = permission.toLowerCase();
        console.log($(".container button[action]"));
        $(".container button[action]").each(function () {
            var action = $(this).attr("action");
            if (permission.indexOf(action.toLowerCase() + ",") < 0) {
                $(this).remove();
            }
        });
        console.log($(".container a[listaction]"));
        $(".container a[listaction]").each(function () {
            var listaction = $(this).attr("listaction");
            if (permission.indexOf(listaction.toLowerCase() + ",") < 0) {
                $(this).remove();
            }
        });
    }
}
//格式化时间
function jsonDateFormat(jsonDate) {
    try {
        //json日期格式转换为正常格式
        var jsonDateStr = jsonDate.toString(); //此处用到toString（）是为了让传入的值为字符串类型，目的是为了避免传入的数据类型不支持.replace（）方法

        var k = parseInt(jsonDateStr.replace("/Date(", "").replace(")/", ""), 10);
        if (k < 0)
            return null;

        var date = new Date(parseInt(jsonDateStr.replace("/Date(", "").replace(")/", ""), 10));
        var month = date.getMonth() + 1 < 10 ? "0" + (date.getMonth() + 1) : date.getMonth() + 1;
        var day = date.getDate() < 10 ? "0" + date.getDate() : date.getDate();
        var hours = date.getHours() < 10 ? "0" + date.getHours() : date.getHours();
        var minutes = date.getMinutes() < 10 ? "0" + date.getMinutes() : date.getMinutes();
        var seconds = date.getSeconds() < 10 ? "0" + date.getSeconds() : date.getSeconds();
        return date.getFullYear() + "-" + month + "-" + day + " " + hours + ":" + minutes + ":" + seconds;
    } catch (ex) {
        return "时间格式转换错误";
    }
}

//获取url中的参数
function getUrlParam(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象
    var r = window.location.search.substr(1).match(reg);  //匹配目标参数
    if (r != null) return unescape(r[2]); return null; //返回参数值
}

function getRootPath_web() {
    //获取当前网址，如： http://localhost:8083/uimcardprj/share/meun.jsp
    var curWwwPath = window.document.location.href;
    //获取主机地址之后的目录，如： uimcardprj/share/meun.jsp
    var pathName = window.document.location.pathname;
    var pos = curWwwPath.indexOf(pathName);
    //获取主机地址，如： http://localhost:8083
    var localhostPaht = curWwwPath.substring(0, pos);
    //获取带"/"的项目名，如：/uimcardprj
    //var projectName = pathName.substring(0, pathName.substr(1).indexOf('/') + 1);
    return localhostPaht;
}


/**
 * 上传单个图片
 * @param {} folderName 文件夹名字
 * @param {} picPath  保存图片路径的隐藏域(该控件放到上传控件上面)
 * @param {} isValid 是否给该控件添加验证
 * @param {} formId  控件Id
 * @returns {} 
 */
$.fn.uploadSinglePic = function (folderName, picPath, isValid, formId) {
    var preList = new Array();      //预览图片json数据组  
    var preConfigList = new Array();    //预览图片设置

    if ($("#" + picPath).val()) {
        preList[0] = GetAbsolutePath(picPath);
        preConfigList[0] = {
            caption: "", // 展示的文件名  
            width: 190,
            url: getRootPath_web() + "/System/UploadFile/DelePic", // 删除url  
            key: $("#" + picPath).val(), // 删除是Ajax向后台传递的参数  
            extra: { id: 100 }
        };
    }

    var control = $(this);
    $(this).fileinput({
        language: "zh",
        uploadUrl: "/System/UploadFile/UploadFile", // server upload action
        uploadAsync: true, //同步异步，如果同步上传，须保证后台程序可同步处理文件上传
        maxFileCount: 1,//最大上传数量
        overwriteInitial: true,    //覆盖已存在的图片  
        dropZoneEnabled: false,//是否显示拖拽区域
        showRemove: false, //是否显示删除按钮
        previewFileType: "image", //文件类型限制
        allowedFileTypes: ["image"],
        slugCallback: function (filename) {
            //选择文件时，过滤文件名中的特殊字符
            return filename.replace("(", "_").replace("]", "_");
        },
        browseIcon: '<i class="glyphicon glyphicon-picture"></i>',
        browseClass: "btn btn-success",
        uploadExtraData: function () {   //额外参数的关键点
            return { name: control.attr("name"), folderName: folderName };
        },
        //initialPreview: GetAbsolutePath(picPath),
        initialPreviewConfig: preConfigList,
        initialPreview: preList,
        initialPreviewAsData: true,
        initialPreviewFileType: "image",
        fileActionSettings: {
            showDownload: false,
            showZoom: true
        }
    }).on("fileuploaded", function (event, outData) {
        $("#" + picPath).val(outData.response.data); //图片相对路径
        if (isValid && isValid === 1)
            $("#" + formId).data("bootstrapValidator").updateStatus(picPath, "VALIDATED").validateField(picPath);      //修改隐藏域验证
    }).on("filecleared", function (event, data, msg) {
        $("#" + picPath).val("");     //关闭预览按钮 清空所有图片路径

        if (isValid && isValid === 1)
            $("#" + formId).data("bootstrapValidator").updateStatus(picPath, "NOT_VALIDATED").validateField(picPath);      //修改隐藏域验证
    }).on("filedeleted", function (event, key) {
        $("#" + picPath).val("");     //关闭预览按钮 清空所有图片路径

        if (isValid && isValid === 1)
            $("#" + formId).data("bootstrapValidator").updateStatus(picPath, "NOT_VALIDATED").validateField(picPath);      //修改隐藏域验证
    });
};

//初始化图片路径
function GetAbsolutePath(picPath) {
    var control = $("#" + picPath);
    var pic = control.val();
    if (control.val() != null && control.val() !== "" && control.val().indexOf('http') < 0) {
        pic = getRootPath_web() + "/" + control.val();
    }
    console.log(pic);
    return pic;
}

/**
 * 上传多个图片
 * @param {} actionUrl 文件夹名字
 * @param {} picPath 保存图片路径的隐藏域(该控件放到上传控件上面)
 * @param {} jsonUrl 初始化图片结果集
 * @returns {} 
 */
$.fn.uploadMultiplePic = function (folderName, picPath, jsonUrl) {
    var preConfigList = new Array();    //预览图片设置
    var preList = new Array();      //预览图片json数据组  
    var control = $("#" + picPath);
    var url = "";
    $.each(eval(jsonUrl), function (i, value) {
        preList[i] = getRootPath_web() + "/" + value;
        preConfigList[i] = {
            caption: "", // 展示的文件名  
            width: 190,
            url: getRootPath_web() + "/System/UploadFile/DelePic", // 删除url  
            key: value, // 删除是Ajax向后台传递的参数  
            extra: { id: 100 }
        };
        url += value + ",";
    });
    url = url.substr(0, url.length - 1);
    //给隐藏域赋值
    if (control.val().trim() === "") {
        control.val(url);
    } else {
        control.val(control.val().trim() + "," + url);
    }
    $(this).fileinput({
        language: "zh",
        uploadUrl: "/System/UploadFile/UploadMultipleFile", // server upload action
        uploadAsync: false, //同步异步，如果同步上传，须保证后台程序可同步处理文件上传
        minFileCount: 1, //最小上传数量
        maxFileCount: 3,
        overwriteInitial: false,    //不覆盖已存在的图片  
        dropZoneEnabled: false,//是否显示拖拽区域
        showRemove: false, //是否显示删除按钮
        previewFileType: "image", //文件类型限制
        browseClass: "btn btn-success", //选择按钮样式
        browseLabel: " 选择", //选择按钮文字
        browseIcon: '<i class="glyphicon glyphicon-picture"></i>',
        allowedFileTypes: ["image"],
        initialPreviewConfig: preConfigList,
        initialPreview: preList,
        initialPreviewAsData: true,     //identify if you are sending preview data only and not the raw markup
        initialPreviewFileType: "image", //image is the default and can be overridden in config below
        slugCallback: function (filename) {
            //选择文件时，过滤文件名中的特殊字符
            return filename.replace("(", "_").replace("]", "_");
        },
        uploadExtraData: function (previewId, index) {   //额外参数的关键点
            return { folderName: folderName };
        }
    }).on("fileuploaded", function (event, outData) {
        if (control.val().trim() === "") {
            control.val(outData.response.Message); //图片相对路径
        } else {
            control.val(control.val() + "," + outData.response.Message); //图片相对路径
        }
    }).on("filebatchuploadsuccess", function (event, outData) {
        if (control.val() === "") {
            control.val(outData.response.Message); //图片相对路径
        } else {
            control.val(control.val() + "," + outData.response.Message); //图片相对路径
        }
    }).on("filedeleted", function (event, key) {
        if (control.val().indexOf(key) === 0) {
            if (control.val().trim().length === key.length) {
                control.val("");
            } else {
                control.val(control.val().replace(key + ",", ""));
            }
        } else {
            control.val(control.val().replace("," + key, ""));
        }
    });
}

//加载页面
function loadPage(url, container) {
    if (!container)
        container = "#content";
    $.get(url, null, function (data) {
        $(container).html(data);
    });
}

//刷新右边内容页
function reloadPage() {
    try {
        loadPage($("ul.treeview-menu li.active a").data("url"));        //重新加载页面
    } catch (e) {
        location.reload();
    }
}

//点击选中行，改变选中行的背景颜色
$('table').on('click-row.bs.table', function (e, row, element) {
    //$('table tr').removeAttr('style');
    //$(element).css('background-color', '#08C');

    //bootstrap table支持5中表格的行背景色，分别是'active', 'success', 'info', 'warning', 'danger'这五种
    $("table .info").removeClass("info");
    $(element).addClass('info');
}); 
