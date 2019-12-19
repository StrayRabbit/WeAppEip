using System.Threading.Tasks;
using ApplicationCore.Entities.NewsAggregate;

namespace ApplicationCore.Interfaces
{
    public interface IBannerService
    {
        /// <summary>
        /// 创建Banner
        /// </summary>
        /// <param name="banner"></param>
        /// <returns></returns>
        Task CreateBannerAsync(Banner banner);

        /// <summary>
        /// 修改Banner
        /// </summary>
        /// <param name="banner"></param>
        /// <returns></returns>
        Task UpdateBannerAsync(Banner banner);

        /// <summary>
        /// 删除banner
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteBannerByIdAsync(int id);
    }
}