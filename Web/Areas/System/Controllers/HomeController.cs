using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Logging;
using WeAppEip.Web.Extensions;
using WeAppEip.Web.ViewModels;

namespace Web.Areas.System.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            try
            {
                Account user = Current;
                if (user == null)
                {
                    return Redirect("/System");
                }

                //List<SysModuleDto> query = _sysModuleService.GetModuleDto(user.Modules);

                ViewData["UserName"] = user.Name;       //显示名称
                ViewData["RoleName"] = user.RoleName;     //角色

                //ViewData["MenuFirst"] = query.Where(t => t.Levels == 1).ToList();
                //ViewData["MenuSecond"] = query.Where(t => t.Levels == 2).ToList();
            }
            catch (Exception ex)
            {
                LogHelper.LogInformation($"加载菜单异常!{ex.ToString()}");
                throw;
            }

            return View();
        }
    }
}