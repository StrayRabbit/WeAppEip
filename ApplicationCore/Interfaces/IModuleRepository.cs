using System.Threading.Tasks;
using ApplicationCore.Entities.SystemAggregate;

namespace ApplicationCore.Interfaces
{
    public interface IModuleRepository : IAsyncRepository<Module>
    {
        /// <summary>
        /// 根据Id获取模块信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Module> GetModuleByIdAsync(int id);
    }
}