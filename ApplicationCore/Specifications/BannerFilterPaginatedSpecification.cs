using ApplicationCore.Entities.NewsAggregate;

namespace ApplicationCore.Specifications
{
    public class BannerFilterPaginatedSpecification : BaseSpecification<Banner>
    {
        public BannerFilterPaginatedSpecification(string description, int skip, int take)
            : base(b => description != null ? b.Description.Contains(description) : true)
        {
            ApplyPaging(skip, take);
        }
    }
}
