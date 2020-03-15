using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeAppEip.Web.Controllers;
using WeAppEip.Web.ViewModels;
using WeAppEip.Web.ViewModels.Banner;
using Web.Interfaces;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannerController : BaseApiController
    {
        private readonly IBannerViewModelService _bannerViewModelService;

        public BannerController(IBannerViewModelService bannerViewModelService)
        {
            _bannerViewModelService = bannerViewModelService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int count = 5)
        {
            ReturnResult<PaginationViewModel<BannerViewModel>> result = new ReturnResult<PaginationViewModel<BannerViewModel>>()
            {
                Code = ReturnCode.Success,
                Data = await _bannerViewModelService.GetBannerItemsAsync(null, 0, count)
            };

            return Ok(result);
        }
    }
}