using System.Threading.Tasks;
using ApplicationCore.Entities.NewsAggregate;

namespace ApplicationCore.Interfaces
{
    public interface IBannerRepository : IAsyncRepository<Banner>
    {
        Task<Banner> GetBannerByIdAsync(int id);
    }
}
