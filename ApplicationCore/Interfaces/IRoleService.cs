using System.Threading.Tasks;
using ApplicationCore.Entities.SystemAggregate;

namespace ApplicationCore.Interfaces
{
    public interface IRoleService
    {
        Task<Role> GetRoleById(int id);
    }
}