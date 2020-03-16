//app.js
App({
  globalData:{
      appid:'wx9b0aa2040552419be',//appid需自己提供，此处的appid我随机编写
      secret:'28c2d4635a9435eae82ac1772cb540782',//secret需自己提供，此处的secret我随机编写

  },
  onLaunch: function () {
   var that = this
   var user=wx.getStorageSync('user') || {};  
   var userInfo=wx.getStorageSync('userInfo') || {}; 
   if((!user.openid || (user.expires_in || Date.now()) < (Date.now() + 600))&&(!userInfo.nickName)){ 
      wx.login({  
      success: function(res){ 
          if(res.code) {
              wx.getUserInfo({
                  success: function (res) {
                      // var objz={};
                      // objz.avatarUrl=res.userInfo.avatarUrl;
                      // objz.nickName=res.userInfo.nickName;


                      // console.log(objz);
                      wx.setStorageSync('userInfo', res.userInfo);//存储userInfo
                  }
              });
              var d=that.globalData;//这里存储了appid、secret、token串  
              var l='https://api.weixin.qq.com/sns/jscode2session?appid='+d.appid+'&secret='+d.secret+'&js_code='+res.code+'&grant_type=authorization_code';  
              wx.request({  
                  url: l,  
                  data: {},  
                  method: 'GET', // OPTIONS, GET, HEAD, POST, PUT, DELETE, TRACE, CONNECT  
                  // header: {}, // 设置请求的 header  
                  success: function(res){ 
                      var obj={};
                      obj.openid=res.data.openid;  
                      obj.expires_in=Date.now()+res.data.expires_in;  
                      // console.log(obj);
                      wx.setStorageSync('user', obj);//存储openid  
                  }  
              });
          }else {
              console.log('获取用户登录态失败！' + res.errMsg)
          }          
      }  
    }); 
  }
 },
})