using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web.Interfaces;

namespace Web.Areas.System.Controllers
{
    public class CustomerController : BaseController
    {
        private readonly ICustomerViewModelService _customerViewModelService;

        public CustomerController(ICustomerViewModelService customerViewModelService)
        {
            _customerViewModelService = customerViewModelService;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region 获取列表
        /// <summary>
        /// 获取列表
        /// </summary>
        [HttpPost]
        public async Task<JsonResult> GetList(string openId, string nickName, int skipCount, int takeCount)
        {
            var list = await _customerViewModelService.GetItemsAsync(openId, nickName, skipCount, takeCount);
            return Json(list);
        }
        #endregion
    }
}