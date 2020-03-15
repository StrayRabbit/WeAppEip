using ApplicationCore.Entities.CustomersAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface ICustomerService
    {
        /// <summary>
        /// 创建
        /// </summary>
        /// <returns></returns>
        Task CreateAsync(Customer customer);

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        Task UpdateAsync(Customer customer);
    }
}
