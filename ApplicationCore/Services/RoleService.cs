using System.Threading.Tasks;
using ApplicationCore.Entities.SystemAggregate;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Services
{
    /// <summary>
    /// 角色服务
    /// </summary>
    public class RoleService : IRoleService
    {
        private readonly IRoleReponsitory _reponsitory;

        public RoleService(IRoleReponsitory reponsitory)
        {
            _reponsitory = reponsitory;
        }

        public async Task<Role> GetRoleById(int id)
        {
            return await _reponsitory.GetByIdAsync(id);
        }
    }
}