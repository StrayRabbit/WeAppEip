using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities.SystemAggregate;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
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
            };
        }
    }
}