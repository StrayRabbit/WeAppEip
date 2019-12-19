using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.System.Controllers
{
    public class ModuleController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}