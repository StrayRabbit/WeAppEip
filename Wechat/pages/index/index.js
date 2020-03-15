var CONFIG = require('../../utils/config.js')

Page({
  data: {
    indicatorDots: true,
    autoplay: true,
    interval: 5000,
    duration: 1000,
    swipers: [],
    news: [],
    // cat: '17',
    canIUse: wx.canIUse('button.open-type.getUserInfo')
  },

  onLoad: function () {
    var that = this;

    // wx.login({
    //   success (res) {
    //     if (res.code) {
    //       console.log(res);

    //       //发起网络请求
    //       // wx.request({
    //       //   url: 'https://test.com/onLogin',
    //       //   data: {
    //       //     code: res.code
    //       //   }
    //       // })
    //     } else {
    //       console.log('登录失败！' + res.errMsg)
    //     }
    //   }
    // })

    // 查看是否授权
    wx.getSetting({
      success (res){
        if (res.authSetting['scope.userInfo']) {
          // 已经授权，可以直接调用 getUserInfo 获取头像昵称
          wx.getUserInfo({
            success: function(res) {
              // console.log(res.userInfo)
            }
          })
        }
      }
    })


    var user=wx.getStorageSync('user') ;  
    var userInfo=wx.getStorageSync('userInfo'); 

    //添加或者更新用户
    if(user.openid)
    {
      var data={
        'OpenId':user.openid,
        'NickName':userInfo.nickName,
        'AvatarUrl':userInfo.avatarUrl,
        'Gender':userInfo.gender,
        'Country':userInfo.country,
        'Province':userInfo.province,
        'City':userInfo.city,
      };
      console.log(data);
      wx.request({
        url: CONFIG.API_URL.POST_Customer,
        method: 'POST',
        data: data,
        header: {
          'Accept': 'application/json'
        },
        success: function (res) {
          console.log(res);
        },
        error:function(res){
          console.log(res);
        }
      })
    }

    // wx.getUserInfo({
    //   success: function(res) {
    //     var userInfo = res.userInfo
    //     var nickName = userInfo.nickName
    //     var avatarUrl = userInfo.avatarUrl
    //     var gender = userInfo.gender //性别 0：未知、1：男、2：女
    //     var province = userInfo.province
    //     var city = userInfo.city
    //     var country = userInfo.country

    //     // console.log(res);
    //   }
    // })

    //banner
    wx.request({
      url: CONFIG.API_URL.GET_INDEX+'?count=3',
      method: 'GET',
      data: {},
      header: {
        'Accept': 'application/json'
      },
      success: function(res) {
        if (res.data.code == 200) {
          var data = res.data.data;
          var swipers = [];

          // console.log(data);

          for (var i = 0; i < data.total; i++) {
            if (i < 5) {
              var obj={
                id:data.rows[i].id,
                imageUrl: CONFIG.API_URL.API_BASE+data.rows[i].imageUrl
              }

              //  console.log(obj);
              swipers.push(obj);
            }
          }
          that.setData({swipers: swipers});
        }
      }
    })

    //新闻动态
    wx.request({
      url: CONFIG.API_URL.GET_NEWS+'?type=1&count=3',
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
              // console.log(news);
            }
          }
          that.setData({ news: news });
        }
      }
    })
  },
  onShareAppMessage: function () {
   // return custom share data when user share.
  //  console.log('onShareAppMessage')
   return {
      title: '人事培训',
      desc: '小程序',
      path: '/pages/index/index'
    }
  },
  bindGetUserInfo (e) {
    console.log(e.detail.userInfo)
  }
});
