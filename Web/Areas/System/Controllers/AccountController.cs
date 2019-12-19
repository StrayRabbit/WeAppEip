using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using WeAppEip.Web.Extensions;
using WeAppEip.Web.ViewModels;
using Web.Extensions;

namespace Web.Areas.System.Controllers
{
    [Area("System")]
    public class AccountController : Controller
    {
        private readonly IUserRepository _userRepository;

        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="account"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<JsonResult> Login(string account, string pwd)
        {
            var json = new JsonModel { Msg = "登录成功!", Code = 200 };

            try
            {
                if (string.IsNullOrEmpty(account) || string.IsNullOrEmpty(pwd))
                {
                    json.Msg = "账号或密码不能为空!";
                    json.Code = 400;
                    return Json(json);
                }

                string password = pwd.Md5Encrypt();
                var user = await _userRepository.GetUser(account, password);
                if (user != null)
                {
                    HttpContext.Session.SetString("user", JsonSerHelper.ToJson(user));
                    json.Code = 200;
                }
                else
                {
                    json.Msg = "账号或密码错误!";
                    json.Code = 400;
                }
            }
            catch (global::System.Exception e)
            {
                json.Msg = "登录异常!" + e.Message;
                json.Code = 500;
            }

            return Json(json);
        }
    }
}