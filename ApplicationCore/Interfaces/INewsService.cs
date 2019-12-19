using System.Threading.Tasks;
using ApplicationCore.Entities.NewsAggregate;

namespace ApplicationCore.Interfaces
{
    public interface INewsService
    {
        /// <summary>
        /// 创建
        /// </summary>
        /// <returns></returns>
        Task CreateAsync(News entity);

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        Task UpdateAsync(News entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        Task DeleteByIdAsync(int id);
    }
}