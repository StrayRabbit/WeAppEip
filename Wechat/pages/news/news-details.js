var CONFIG = require('../../utils/config.js')
var WxParse = require('../../utils/wxParse/wxParse.js');

var app = getApp();
Page({
  data: {
  },
  onLoad: function (options) {
    var that = this;
    wx.request({
      url: CONFIG.API_URL.GET_ARTICLE + options.id,
      method: 'GET',
      data: {},
      header: {
        'Accept': 'application/json'
      },
      success: function (res) {
        console.log(res);

        if (res.statusCode == 200 && res.data.code == 200) {
          var data = res.data;

          that.setData({
            news: data.data,
          })
          WxParse.wxParse('content', 'html', data.data.content, that, 25)
        } else {

        }
      }
    })
  },
  onReady: function () {
    // 页面渲染完成
  },
  onShow: function () {
    // 页面显示
  },
  onHide: function () {
    // 页面隐藏
  },
  onUnload: function () {
    // 页面关闭
  },
  wxParseTagATap: function (e) {
    var href = e.currentTarget.dataset.src;
    if (href.indexOf('upload') > 0) {
      var type = href.substring(href.lastIndexOf('.') + 1, href.length);    //文件类型
      //预览
      wx.downloadFile({
        url: href,      //文件路径
        header: {},
        success: function (res) {
          console.log(res)
          var filePath = res.tempFilePath;
          console.log(filePath);
          wx.openDocument({
            filePath: filePath,
            fileType: type,   //文件类型
            success: function (res) {
              console.log('打开文档成功')
            },
            fail: function (res) {
              console.log(res);
            },
            complete: function (res) {
              console.log(res);
            }
          })
        },
        fail: function (res) {
          console.log('文件下载失败');
        },
        complete: function (res) { },
      })
    }
  }
})
