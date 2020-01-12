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

    /// <summary>
    /// 模块是否存在子菜单
    /// </summary>
    public class ModuleFilterChildCountSpecification : BaseSpecification<Module>
    {
        /// <summary>
        /// 模块是否存在子菜单
        /// </summary>
        /// <param name="id"></param>
        public ModuleFilterChildCountSpecification(int id) : base(item => item.ParentId == id)
        {
        }
    }


    /// <summary>
    /// 过滤 根据父ID查询子菜单
    /// </summary>
    public class ModuleFilterChildsSpecification : BaseSpecification<Module>
    {
        public ModuleFilterChildsSpecification(int id) : base(item => item.ParentId == id)
        {
        }
    }
}