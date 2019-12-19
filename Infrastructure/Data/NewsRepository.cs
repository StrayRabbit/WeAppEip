using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities.NewsAggregate;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace WeAppEip.Infrastructure.Data
{
    public class NewsRepository : EfRepository<News>, INewsRepository
    {
        public NewsRepository(EipContext dbContext) : base(dbContext)
        {
        }

        public async Task<News> GetNewsByIdAsync(int id)
        {
            return await _dbContext.News.FirstOrDefaultAsync(item => item.Id == id);
        }
    }
}
