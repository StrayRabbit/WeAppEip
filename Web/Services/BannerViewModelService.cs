using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities.NewsAggregate;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using WeAppEip.Web.ViewModels;
using WeAppEip.Web.ViewModels.Banner;
using Web.Interfaces;

namespace WeAppEip.Web.Services
{
    public class BannerViewModelService : IBannerViewModelService
    {
        private readonly IAsyncRepository<Banner> _bannerRepository;

        public BannerViewModelService(IAsyncRepository<Banner> bannerRepository)
        {
            _bannerRepository = bannerRepository;
        }

        public async Task<PaginationViewModel<BannerViewModel>> GetBannerItemsAsync(string description, int pageIndex = 0, int pageSize = 0)
        {
            var filterPagnatedSpecification = new BannerFilterPaginatedSpecification(description, pageIndex * pageSize, pageSize);

            var itemsOnPage = await _bannerRepository.ListAsync(filterPagnatedSpecification);
            var totalItems = await _bannerRepository.CountAsync(filterPagnatedSpecification);

            var vm = new PaginationViewModel<BannerViewModel>()
            {
                rows = itemsOnPage.Select(item => new BannerViewModel()
                {
                    Description = item.Description,
                    Id = item.Id,
                    ImageUrl = item.ImageUrl,
                    Order = item.Order ?? 99,
                }).ToList(),
                total = totalItems,
            };


            return vm;
        }
    }
}
