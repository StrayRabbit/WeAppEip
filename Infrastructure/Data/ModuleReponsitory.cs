using System.Threading.Tasks;
using ApplicationCore.Entities.SystemAggregate;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace WeAppEip.Infrastructure.Data
{
    public class ModuleReponsitory : EfRepository<Module>, IModuleRepository
    {
        public ModuleReponsitory(EipContext dbContext) : base(dbContext)
        {
        }

        public async Task<Module> GetModuleByIdAsync(int id)
        {
            return await _dbContext.Modules.SingleOrDefaultAsync(item => item.Id == id);
        }
    }
}
