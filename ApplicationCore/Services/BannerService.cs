using System.Threading.Tasks;
using ApplicationCore.Entities.NewsAggregate;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Services
{
    /// <summary>
    /// Banner
    /// </summary>
    public class BannerService : IBannerService
    {
        private readonly IAsyncRepository<Banner> _banneRepository;

        public BannerService(IAsyncRepository<Banner> banneRepository)
        {
            _banneRepository = banneRepository;
        }

        /// <summary>
        /// 创建banner
        /// </summary>
        /// <param name="banner"></param>
        /// <returns></returns>
        public async Task CreateBannerAsync(Banner banner)
        {
            await _banneRepository.AddAsync(banner);
        }

        /// <summary>
        /// 修改Banner
        /// </summary>
        /// <param name="banner"></param>
        /// <returns></returns>
        public async Task UpdateBannerAsync(Banner banner)
        {
            await _banneRepository.UpdateAsync(banner);
        }

        /// <summary>
        /// 删除Banner
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteBannerByIdAsync(int id)
        {
            var entity = await _banneRepository.GetByIdAsync(id);
            await _banneRepository.DeleteAsync(entity);
        }
    }
}