var CONFIG = require('../../utils/config.js')

Page({
  data: {
    count: 5
  },
  onLoad: function () {
    var that = this;
    wx.request({
      url: CONFIG.API_URL.GET_Activities + '?type=2&count=' + this.data.count,
      method: 'GET',
      data: {},
      header: {
        'Accept': 'application/json'
      },
      success: function (res) {
        // console.log(res);

        if (res.data.code == 200) {
          var data = res.data.data;
          var activities = [];

          // console.log(data);
          for (var i = 0; i < data.total; i++) {
            var obj = {
              id: data.rows[i].id,
              imageUrl: CONFIG.API_URL.API_BASE + data.rows[i].imageUrl,
              title: data.rows[i].title,
              introduction: data.rows[i].introduction,
            }

            activities.push(obj);
          }
          that.setData({ activities: activities });
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
  go: function (event) {
    wx.navigateTo({
      url: '/pages/news/news-details?id=' + event.currentTarget.dataset.type
    })
  },
  /**
   * 页面上拉触底事件的处理函数
   */
  onReachBottom: function () {
    var that = this;
    // console.log('onReachBottom');
    this.data.count += this.data.count;

    wx.request({
      url: CONFIG.API_URL.GET_Activities + '?type=2&count=' + this.data.count,
      method: 'GET',
      data: {},
      header: {
        'Accept': 'application/json'
      },
      success: function (res) {
        // console.log(res);

        if (res.data.code == 200) {
          var data = res.data.data;
          var activities = [];

          // console.log(data);
          for (var i = 0; i < data.total; i++) {
            var obj = {
              id: data.rows[i].id,
              imageUrl: CONFIG.API_URL.API_BASE + data.rows[i].imageUrl,
              title: data.rows[i].title,
              introduction: data.rows[i].introduction,
            }

            activities.push(obj);
          }
          that.setData({ activities: activities });
        } else {

        }
      }
    })
  },
})
