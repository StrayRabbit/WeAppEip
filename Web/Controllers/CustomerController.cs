using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeAppEip.Web.Controllers;
using WeAppEip.Web.ViewModels;
using Web.Interfaces;
using Web.ViewModels.Customer;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : BaseApiController
    {
        private readonly ICustomerViewModelService _customerViewModelService;

        public CustomerController(ICustomerViewModelService customerViewModelService)
        {
            _customerViewModelService = customerViewModelService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CustomerViewModel entity)
        {
            JsonModel result = new JsonModel()
            {
                Code = 200,
                Msg = "添加成功!"
            };

            try
            {
                await _customerViewModelService.CreateOrModifyAsync(entity);
            }
            catch (Exception ex)
            {
                result.Code = 500;
                result.Msg = ex.Message;
            }

            return Ok(result);
        }
    }
}