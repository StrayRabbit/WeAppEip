using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeAppEip.Web.Controllers;
using WeAppEip.Web.ViewModels;
using WeAppEip.Web.ViewModels.Banner;
using WeAppEip.Web.ViewModels.News;
using Web.Interfaces;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : BaseApiController
    {
        private readonly INewsViewModelService _newsViewModelService;

        public NewsController(INewsViewModelService newsViewModelService)
        {
            _newsViewModelService = newsViewModelService;
        }

        [HttpGet]
        [Route("getItems")]
        public async Task<IActionResult> GetItems(int type, int count)
        {
            ReturnResult<PaginationViewModel<NewsViewModel>> result =
                new ReturnResult<PaginationViewModel<NewsViewModel>>()
                {
                    Code = ReturnCode.Success,
                    Data = await _newsViewModelService.GetItemsAsync("", type, 0, count)
                };

            return Ok(result);
        }

        [HttpGet]
        [Route("getItem/{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            var item = await _newsViewModelService.GetItemAsync(id);

            ReturnResult<NewsViewModel> result =
                new ReturnResult<NewsViewModel>()
                {
                    Code = ReturnCode.Success,
                    Data = new NewsViewModel()
                    {
                        Content = item.Content,
                        CreateDate = item.CreateDate,
                        Id = item.Id,
                        ImageUrl = item.ImageUrl,
                        Introduction = item.Introduction,
                        Order = item.Order,
                        Title = item.Title,
                        Type = item.Type
                    }
                };

            return Ok(result);
        }
    }
}
