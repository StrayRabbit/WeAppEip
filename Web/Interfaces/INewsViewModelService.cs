using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using WeAppEip.Web.ViewModels;
using WeAppEip.Web.ViewModels.News;
using System.Collections.Generic;

namespace Web.Interfaces
{
    public interface INewsViewModelService
    {
        Task<PaginationViewModel<NewsViewModel>> GetItemsAsync(string title, int type = -1, int skipCount = 0, int takeCount = 0);

        Task<NewsViewModel> GetItemAsync(int id);

        Task<List<SelectListItem>> GetNewsTypeAsync();
    }
}