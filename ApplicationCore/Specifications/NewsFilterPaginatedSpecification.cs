using System;
using System.Linq.Expressions;
using ApplicationCore.Entities.NewsAggregate;

namespace ApplicationCore.Specifications
{
    public class NewsFilterPaginatedSpecification : BaseSpecification<News>
    {
        public NewsFilterPaginatedSpecification(string title, int type, int skip, int take)
            : base(item => item.Title.Contains(title ?? "") && (type < 0 || item.Type == type))
        {
            ApplyPaging(skip * take, take);
        }
    }
}