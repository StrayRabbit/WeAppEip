using System.Threading.Tasks;
using WeAppEip.Web.ViewModels;
using WeAppEip.Web.ViewModels.Banner;

namespace Web.Interfaces
{
    public interface IBannerViewModelService
    {
        Task<PaginationViewModel<BannerViewModel>> GetBannerItemsAsync(string description, int skipCount = 0, int takeCount = 0);
    }
}