using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities.UserAggregate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeAppEip.Web.Extensions;
using WeAppEip.Web.ViewModels;

namespace Web.Areas.System.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// 获取当前用户对象
        /// </summary>
        public Account Current
        {
            get
            {
                var userJson = HttpContext.Session.GetString("user");
                if (!string.IsNullOrWhiteSpace(userJson))
                {
                    var user = JsonSerHelper.ToObject<User>(userJson);

                    return new Account()
                    {
                        Id = user.Id,
                        Name = user.Name,
                        RoleId = user.Roleid,
                        UserName = user.Account,
                    };
                }

                return null;
            }
        }
    }
}