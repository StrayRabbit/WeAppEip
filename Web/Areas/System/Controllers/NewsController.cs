using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ApplicationCore.Entities.NewsAggregate;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WeAppEip.Web.ViewModels;
using WeAppEip.Web.ViewModels.News;
using Web.Interfaces;

namespace Web.Areas.System.Controllers
{
    /// <summary>
    /// 新闻管理
    /// </summary>
    public class NewsController : BaseController
    {
        private readonly INewsRepository _newsRepository;
        private readonly INewsService _newsService;
        private readonly INewsViewModelService _newsViewModelService;

        public NewsController(INewsRepository newsRepository, INewsService newsService, INewsViewModelService newsViewModelService)
        {
            _newsRepository = newsRepository;
            _newsService = newsService;
            _newsViewModelService = newsViewModelService;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["NewsType"] = await _newsViewModelService.GetNewsTypeAsync();

            return View();
        }

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Detail(int? id)
        {
            var entity = new NewsViewModel();

            if (id > 0)
            {
                var model = await _newsRepository.GetNewsByIdAsync(int.Parse(id.ToString()));
                if (model != null)
                {
                    entity.Id = model.Id;
                    entity.Order = model.Order;
                    entity.Title = model.Title;
                    entity.Type = model.Type;
                    entity.ImageUrl = model.ImageUrl;
                    entity.Content = WebUtility.HtmlDecode(model.Content);
                    entity.Introduction = model.Introduction;
                }
            }

            return View(entity);
        }

        #region 保存
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Save([FromForm]NewsViewModel entity)
        {
            JsonModel json = new JsonModel() { Code = 200, Msg = "保存成功!" };

            try
            {
                if (entity == null)
                {
                    json.Code = 500;
                    json.Msg = "Banner信息不能为空!";

                    return Json(json);
                }

                if (entity.Id <= 0)
                {
                    await _newsService.CreateAsync(new News()
                    {
                        Type = entity.Type,
                        Title = entity.Title,
                        Introduction = entity.Introduction,
                        ImageUrl = entity.ImageUrl,
                        CreateDate = DateTime.Now,
                        CreateUserId = Current.Id,
                        Order = entity.Order,
                        Content = entity.Content,
                    });
                }
                else
                {
                    var model = await _newsRepository.GetNewsByIdAsync(entity.Id);

                    model.Type = entity.Type;
                    model.Title = entity.Title;
                    model.Introduction = entity.Introduction;
                    model.Content = entity.Content;
                    model.ImageUrl = entity.ImageUrl;
                    model.UpdateDate = DateTime.Now;
                    model.UpdateUserId = Current.Id;
                    model.Order = entity.Order;

                    await _newsService.UpdateAsync(model);
                }
            }
            catch (Exception ex)
            {
                json.Code = 500;
                json.Msg = $"保存异常!{ex.Message}";

                return Json(json);
            }

            return Json(json);
        }
        #endregion

        #region 获取列表
        /// <summary>
        /// 获取列表
        /// </summary>
        [HttpPost]
        public async Task<JsonResult> GetList(string title, int type, int skipCount, int takeCount)
        {
            var list = await _newsViewModelService.GetItemsAsync(title, type, skipCount, takeCount);
            return Json(list);
        }
        #endregion

        #region 删除
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            JsonModel json = new JsonModel() { Code = 200, Msg = "保存成功!" };

            try
            {
                await _newsService.DeleteByIdAsync(id);
            }
            catch (Exception ex)
            {
                json.Code = 500;
                json.Msg = $"保存异常!{ex.Message}";

                return Json(json);
            }

            return Json(json);
        }
        #endregion
    }
}