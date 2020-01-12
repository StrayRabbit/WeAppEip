using System.Threading.Tasks;
using ApplicationCore.Entities.SystemAggregate;
using ApplicationCore.Entities.UserAggregate;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;

namespace ApplicationCore.Services
{
    /// <summary>
    /// 模块服务
    /// </summary>
    public class ModuleService : IModuleService
    {
        private readonly IAsyncRepository<Module> _moduleRepository;
        private readonly IAsyncRepository<RoleModule> _roleModuleRepository;

        public ModuleService(IAsyncRepository<Module> moduleRepository)
        {
            _moduleRepository = moduleRepository;
        }

        public async Task CreateAsync(Module entity)
        {
            await _moduleRepository.AddAsync(entity);
        }

        public async Task UpdateAsync(Module entity)
        {
            await _moduleRepository.UpdateAsync(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var entity = await _moduleRepository.GetByIdAsync(id);
            await _moduleRepository.DeleteAsync(entity);
        }

        public async Task DeleteModulesInRoleModules(int moduleId)
        {
            var query = new ModuleFilterChildsSpecification(moduleId);
            await _moduleRepository.DeleteAsync(query);
        }
    }
}
