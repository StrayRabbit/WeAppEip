using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities.NewsAggregate;

namespace ApplicationCore.Interfaces
{
    /// <summary>
    /// 新闻接口
    /// </summary>
    public interface INewsRepository : IAsyncRepository<News>
    {
        Task<News> GetNewsByIdAsync(int id);
    }
}
