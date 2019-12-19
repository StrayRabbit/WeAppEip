using System.Threading.Tasks;
using ApplicationCore.Entities.SystemAggregate;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace WeAppEip.Infrastructure.Data
{
    public class RoleReponsitory : EfRepository<Role>, IRoleReponsitory
    {
        public RoleReponsitory(EipContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// 根据Id获取角色信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Role> GetRoleById(int id)
        {
            return await _dbContext.Roles.SingleOrDefaultAsync(item => item.Id == id);
        }
    }
}