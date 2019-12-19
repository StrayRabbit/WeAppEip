using System;
using System.Linq.Expressions;
using ApplicationCore.Entities.SystemAggregate;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Specifications
{
    public class ModuleFilterPaginatedSpecification : BaseSpecification<Module>
    {
        public ModuleFilterPaginatedSpecification(string name, int skip, int take) : base(item => item.Name.Contains(name))
        {
            ApplyPaging(skip, take);
        }
    }
}