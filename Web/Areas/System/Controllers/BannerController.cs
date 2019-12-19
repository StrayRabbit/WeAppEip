using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities.NewsAggregate;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WeAppEip.Web.ViewModels;
using WeAppEip.Web.ViewModels.Banner;
using Web.Interfaces;

namespace Web.Areas.System.Controllers
{
    public class BannerController : BaseController
    {
        private readonly IBannerRepository _bannerRepository;
        private readonly IBannerService _bannerService;
        private readonly IBannerViewModelService _bannerViewModelService;

        public BannerController(IBannerRepository bannerRepository, IBannerService bannerService, IBannerViewModelService bannerViewModelService)
        {
            _bannerRepository = bannerRepository;
            _bannerService = bannerService;
            _bannerViewModelService = bannerViewModelService;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region 详情
        public async Task<IActionResult> Detail(int? id)
        {
            var banner = new BannerViewModel();

            if (id > 0)
            {
                var entity = await _bannerRepository.GetBannerByIdAsync(int.Parse(id.ToString()));
                if (entity != null)
                {
                    banner.Description = entity.Description;
                    banner.Id = entity.Id;
                    banner.ImageUrl = entity.ImageUrl;
                    banner.Order = entity.Order ?? 99;
                }
            }

            return View(banner);
        }
        #endregion

        #region 保存
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Save([FromForm]BannerViewModel entity)
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
                    await _bannerService.CreateBannerAsync(new Banner()
                    {
                        Description = entity.Description,
                        ImageUrl = entity.ImageUrl,
                        CreateDate = DateTime.Now,
                        CreateUserId = Current.Id,
                        Order = entity.Order,
                    });
                }
                else
                {
                    var model = await _bannerRepository.GetBannerByIdAsync(entity.Id);

                    model.Description = entity.Description;
                    model.ImageUrl = entity.ImageUrl;
                    model.UpdateDate = DateTime.Now;
                    model.UpdateUserId = Current.Id;
                    model.Order = entity.Order;

                    await _bannerService.UpdateBannerAsync(model);
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
                await _bannerService.DeleteBannerByIdAsync(id);
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
        public async Task<JsonResult> GetList(string keyword, int skipCount, int takeCount)
        {
            var list = await _bannerViewModelService.GetBannerItemsAsync(keyword, skipCount, takeCount);
            return Json(list);
        }
        #endregion
    }
}