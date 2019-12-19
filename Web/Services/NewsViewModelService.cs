using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using Microsoft.AspNetCore.Mvc.Rendering;
using WeAppEip.Web.ViewModels;
using WeAppEip.Web.ViewModels.News;
using Web.Interfaces;

namespace WeAppEip.Web.Services
{
    public class NewsViewModelService : INewsViewModelService
    {
        private readonly INewsRepository _newsRepository;

        public NewsViewModelService(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public async Task<PaginationViewModel<NewsViewModel>> GetItemsAsync(string title, int type = -1, int skipCount = 0, int takeCount = 0)
        {
            var filterPaginatedSpecification = new NewsFilterPaginatedSpecification(title, type, skipCount, takeCount);

            var result = new PaginationViewModel<NewsViewModel>()
            {
                rows = (await _newsRepository.ListAsync(filterPaginatedSpecification)).Select(item => new NewsViewModel()
                {
                    Content = item.Content,
                    CreateDate = item.CreateDate,
                    Id = item.Id,
                    ImageUrl = item.ImageUrl,
                    Introduction = item.Introduction,
                    Order = item.Order,
                    Title = item.Title,
                    Type = item.Type,
                }).ToList(),
                total = await _newsRepository.CountAsync(filterPaginatedSpecification)
            };

            return result;
        }

        public async Task<NewsViewModel> GetItemAsync(int id)
        {
            var entity = await _newsRepository.GetByIdAsync(id);

            return new NewsViewModel()
            {
                Content = entity.Content,
                CreateDate = entity.CreateDate,
                Id = entity.Id,
                ImageUrl = entity.ImageUrl,
                Introduction = entity.Introduction,
                Order = entity.Order,
                Title = entity.Title,
                Type = entity.Type,
            };
        }

        public async Task<List<SelectListItem>> GetNewsTypeAsync()
        {
            return await Task.Run(() => new List<SelectListItem>()
            {
                new SelectListItem("新闻","1"),
                new SelectListItem("活动","2")
            });
        }
    }
}