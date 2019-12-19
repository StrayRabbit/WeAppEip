using System.Threading.Tasks;
using ApplicationCore.Entities.SystemAggregate;

namespace ApplicationCore.Interfaces
{
    /// <summary>
    /// 角色仓储
    /// </summary>
    public interface IRoleReponsitory : IAsyncRepository<Role>
    {
        Task<Role> GetRoleById(int id);
    }
}