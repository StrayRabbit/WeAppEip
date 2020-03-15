using System.Collections.Generic;
using System.Threading.Tasks;
using WeAppEip.Web.ViewModels;
using Web.ViewModels.User;

namespace Web.Interfaces
{
    public interface IModuleViewModelService
    {
        Task<PaginationViewModel<ModuleViewModel>> GetItemsAsync(string name, int skipCount = 0, int takeCount = 0);
        Task<List<ModuleViewModel>> ListAllAsync();
        Task<ModuleViewModel> GetItemAsync(int id);
        Task<dynamic> GetTreeData();

        /// <summary>
        /// 判断是否有子菜单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> IsHaveChildAsync(int id);
    }
}