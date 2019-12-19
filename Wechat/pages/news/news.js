var CONFIG = require('../../utils/config.js')

Page({
  data:{
    count: 5
  },
  onLoad: function () {
    var that = this;
    wx.request({
      url: CONFIG.API_URL.GET_NEWS+'?type=1&count='+this.data.count,
      method: 'GET',
      data: {},
      header: {
        'Accept': 'application/json'
      },
      success: function (res) {
        if (res.data.code == 200) {
          var data = res.data.data;
          var news = [];

          // console.log(data);

          for (var i = 0; i < data.total; i++) {
            if (i < 3) {
              var obj = {
                id: data.rows[i].id,
                title:data.rows[i].title,
                imageUrl: CONFIG.API_URL.API_BASE +data.rows[i].imageUrl,
                introduction: data.rows[i].introduction,
              }
              
              news.push(obj);
              console.log(news);
            }
          }
          that.setData({ news: news });
        }
      }
    })
  },
  onReady:function(){
    // 页面渲染完成
  },
  onShow:function(){
    // 页面显示
  },
  onHide:function(){
    // 页面隐藏
  },
  onUnload:function(){
    // 页面关闭
  },
  go: function(event) {
    wx.navigateTo({
      url: '/pages/news/news-details?id=' + event.currentTarget.dataset.type
    })
  },
  /**
   * 页面上拉触底事件的处理函数
   */
  onReachBottom: function () {
    var that = this;
    this.data.count += this.data.count;
    wx.request({
      url: CONFIG.API_URL.GET_NEWS+'?type=1&count='+this.data.count,
      method: 'GET',
      data: {},
      header: {
        'Accept': 'application/json'
      },
      success: function (res) {
        if (res.data.code == 200) {
          var data = res.data.data;
          var news = [];

          // console.log(data);

          for (var i = 0; i < data.total; i++) {
            if (i < 3) {
              var obj = {
                id: data.rows[i].id,
                title:data.rows[i].title,
                imageUrl: CONFIG.API_URL.API_BASE +data.rows[i].imageUrl,
                introduction: data.rows[i].introduction,
              }
              
              news.push(obj);
              console.log(news);
            }
          }
          that.setData({ news: news });
        }
      }
    })
  },
})
