using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities.SystemAggregate;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using WeAppEip.Web.ViewModels;
using Web.Interfaces;
using Web.ViewModels.User;

namespace WeAppEip.Web.Services
{
    public class ModuleViewModelService : IModuleViewModelService
    {
        private readonly IAsyncRepository<Module> _moduleRepository;

        public ModuleViewModelService(IAsyncRepository<Module> moduleRepository)
        {
            _moduleRepository = moduleRepository;
        }

        public async Task<PaginationViewModel<ModuleViewModel>> GetItemsAsync(string name, int skipCount = 0, int takeCount = 0)
        {
            var filterPaginatedSpecification =
                new ModuleFilterPaginatedSpecification(name, skip: skipCount, take: takeCount);

            var itemsOnPage = await _moduleRepository.ListAsync(filterPaginatedSpecification);
            var totalCount = await _moduleRepository.CountAsync(filterPaginatedSpecification);

            var vm = new PaginationViewModel<ModuleViewModel>()
            {
                rows = itemsOnPage.Select(item => new ModuleViewModel()
                {
                    CreateDate = item.CreateDate,
                    CreateUserId = item.CreateUserId,
                    Icon = item.Icon,
                    Id = item.Id,
                    IsShow = item.IsShow,
                    Levels = item.Levels,
                    ModulePath = item.ModulePath,
                    Name = item.Name,
                    Order = item.Order,
                    ParentId = item.ParentId,
                }).ToList(),
                total = totalCount
            };

            return vm;
        }

        public async Task<ModuleViewModel> GetItemAsync(int id)
        {
            var entity = await _moduleRepository.GetByIdAsync(id);
            var parentModule = await _moduleRepository.GetByIdAsync(entity.ParentId);

            return new ModuleViewModel()
            {
                CreateUserId = entity.CreateUserId,
                CreateDate = entity.CreateDate,
                Icon = entity.Icon,
                Id = entity.Id,
                IsShow = entity.IsShow,
                Levels = entity.Levels,
                ModulePath = entity.ModulePath,
                Name = entity.Name,
                Order = entity.Order,
                ParentId = entity.ParentId,
                ParentModule = new ModuleViewModel()
                {
                    Id = parentModule?.Id ?? 1,
                    Name = parentModule?.Name ?? "后台管理系统",
                },
            };
        }

        public async Task<dynamic> GetTreeData()
        {
            var models = await _moduleRepository.ListAllAsync();

            return models.Where(item => item.IsShow)
                .Where(item => item.Levels == 1)
                .OrderByDescending(item => item.Order)
                .ThenBy(item => item.Id)
                .Select(t => new
                {
                    id = t.Id,
                    text = t.Name,
                    leves = t.Levels,
                    parentId = t.ParentId,
                    parentName = models.FirstOrDefault(item => item.Id == t.ParentId)?.Name,
                    nodes = models.Where(s => s.ParentId == t.Id).OrderByDescending(s => s.Order).ThenBy(s => s.Id).Select(s => new
                    {
                        id = s.Id,
                        text = s.Name,
                        leves = s.Levels,
                        parentId = s.ParentId,
                        parentName = models.FirstOrDefault(item => item.Id == s.ParentId)?.Name,
                    })
                });
        }

        /// <summary>
        /// 判断是否有子菜单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> IsHaveChildAsync(int id)
        {
            var filterChildCountSpecification = new ModuleFilterChildCountSpecification(id);

            return await _moduleRepository.CountAsync(filterChildCountSpecification) > 0;
        }

        public async Task<List<ModuleViewModel>> ListAllAsync()
        {
            return (await _moduleRepository.ListAllAsync())
                .Where(item => item.IsShow)
                .OrderByDescending(item => item.Order)
                .ThenBy(item => item.Id).Select(item => new ModuleViewModel()
                {
                    CreateDate = item.CreateDate,
                    CreateUserId = item.CreateUserId,
                    Icon = item.Icon,
                    Id = item.Id,
                    IsShow = item.IsShow,
                    Levels = item.Levels,
                    ModulePath = item.ModulePath,
                    Name = item.Name,
                    Order = item.Order,
                    ParentId = item.ParentId,
                    UpdateDate = item.UpdateDate,
                    UpdateUserId = item.UpdateUserId,
                }).ToList();
        }
    }
}