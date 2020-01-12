using System.Threading.Tasks;
using ApplicationCore.Entities.SystemAggregate;

namespace ApplicationCore.Interfaces
{
    public interface IModuleService
    {
        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task CreateAsync(Module entity);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task UpdateAsync(Module entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteByIdAsync(int id);

        /// <summary>
        /// 删除角色模块里边的模块
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteModulesInRoleModules(int id);

    }
}