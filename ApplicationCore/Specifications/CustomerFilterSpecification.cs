using ApplicationCore.Entities.CustomersAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Specifications
{
    public class CustomerFilterPaginatedSpecification : BaseSpecification<Customer>
    {
        public CustomerFilterPaginatedSpecification(string openId, string name, int skip, int take)
            : base(item => item.NickName.Contains(name ?? "") || item.OpenId == openId)
        {
            ApplyPaging(skip * take, take);
        }
    }
}
