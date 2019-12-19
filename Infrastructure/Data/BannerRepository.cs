using System.Threading.Tasks;
using ApplicationCore.Entities.NewsAggregate;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace WeAppEip.Infrastructure.Data
{
    public class BannerRepository : EfRepository<Banner>, IBannerRepository
    {
        public BannerRepository(EipContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// 根据Id获取Banner详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Banner> GetBannerByIdAsync(int id)
        {
            return await _dbContext.Banners.FirstOrDefaultAsync(item => item.Id == id);
        }
    }
}