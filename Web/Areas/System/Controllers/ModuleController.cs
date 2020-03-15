using System;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WeAppEip.Web.ViewModels;
using Web.Interfaces;

namespace Web.Areas.System.Controllers
{
    public class ModuleController : BaseController
    {
        private readonly IModuleRepository _moduleRepository;
        private readonly IModuleService _moduleService;
        private readonly IModuleViewModelService _moduleViewModelService;

        public ModuleController(IModuleRepository moduleRepository, IModuleService moduleService, IModuleViewModelService moduleViewModelService)
        {
            this._moduleRepository = moduleRepository;
            this._moduleService = moduleService;
            this._moduleViewModelService = moduleViewModelService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SelectIco()
        {
            return View();
        }

        #region 获取数据
        [HttpGet]
        public async Task<JsonResult> GetTreeData()
        {
            dynamic data = await _moduleViewModelService.GetTreeData();
            return Json(data);
        }

        /// <summary>
        /// 根据id获取菜单信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<JsonResult> GetModuleById(int id)
        {
            try
            {
                if (id <= 0) return null;

                var result = await _moduleViewModelService.GetItemAsync(id);

                return Json(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 保存
        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> Save(ApplicationCore.Entities.SystemAggregate.Module entity)
        {
            JsonModel json = new JsonModel { Code = 200, Msg = "保存成功!" };
            try
            {
                //添加
                if (entity.Id <= 0)
                {
                    entity.CreateDate = DateTime.Now;
                    entity.CreateUserId = Current.Id;
                    entity.UpdateDate = DateTime.Now;
                    entity.UpdateUserId = Current.Id;
                    entity.IsShow = true;

                    await _moduleService.CreateAsync(entity);
                }
                //修改
                else
                {
                    entity.UpdateDate = DateTime.Now;
                    entity.UpdateUserId = Current.Id;

                    await _moduleService.UpdateAsync(entity);
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
        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
            JsonModel json = new JsonModel { Code = 200, Msg = "删除成功!" };

            try
            {
                if (id <= 0)
                {
                    json.Msg = "请您选择删除的菜单!";
                    return Json(json);
                }


                if (await _moduleViewModelService.IsHaveChildAsync(id))
                {
                    json.Msg = "请您先删除子菜单!";
                    return Json(json);
                }


                await _moduleService.DeleteByIdAsync(id);

                //根据模块ID删除模块角色数据
                await _moduleService.DeleteModulesInRoleModules(id);
            }
            catch (Exception ex)
            {
                json.Code = 500;
                json.Msg = "删除失败!" + ex.Message;
            }

            return Json(json);
        }
        #endregion
    }
}