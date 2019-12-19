using System.Threading.Tasks;
using WeAppEip.Web.ViewModels;
using Web.ViewModels.User;

namespace Web.Interfaces
{
    public interface IModuleViewModelService
    {
        Task<PaginationViewModel<ModuleViewModel>> GetItemsAsync(string name, int skipCount = 0, int takeCount = 0);
        Task<ModuleViewModel> GetItemAsync(int id);
    }
}