using System.Threading.Tasks;
using ApplicationCore.Entities.NewsAggregate;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Services
{
    public class NewsService : INewsService
    {
        private readonly IAsyncRepository<News> _repository;

        public NewsService(IAsyncRepository<News> repository)
        {
            _repository = repository;
        }

        public async Task CreateAsync(News entity)
        {
            await _repository.AddAsync(entity);
        }

        public async Task UpdateAsync(News entity)
        {
            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(entity);
        }
    }
}