using ApplicationCore.Entities.CustomersAggregate;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeAppEip.Web.ViewModels;
using Web.Interfaces;
using Web.ViewModels.Customer;

namespace Web.Services
{
    public class CustomerViewModelService : ICustomerViewModelService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerViewModelService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task CreateOrModifyAsync(CustomerViewModel customer)
        {
            var entity = await _customerRepository.GetItemByOpenIdAsync(customer.OpenId);

            if (entity == null || entity.Id <= 0)
            {
                await _customerRepository.AddAsync(new Customer()
                {
                    AvatarUrl = customer.AvatarUrl,
                    LastLoginTime = DateTime.Now,
                    NickName = customer.NickName,
                    City = customer.City,
                    Country = customer.Country,
                    Gender = customer.Gender,
                    OpenId = customer.OpenId,
                    Province = customer.Province,
                });
            }
            else
            {
                entity.AvatarUrl = customer.AvatarUrl;
                entity.LastLoginTime = DateTime.Now;
                entity.NickName = customer.NickName;
                entity.City = customer.City;
                entity.Country = customer.Country;
                entity.Gender = customer.Gender;
                entity.Province = customer.Province;

                await _customerRepository.UpdateAsync(entity);
            }
        }

        public async Task<PaginationViewModel<CustomerViewModel>> GetItemsAsync(string openId, string name, int skipCount = 0, int takeCount = 0)
        {
            var filterPaginatedSpecification = new CustomerFilterPaginatedSpecification(name, openId, skipCount, takeCount);

            var result = new PaginationViewModel<CustomerViewModel>()
            {
                rows = (await _customerRepository.ListAsync(filterPaginatedSpecification)).Select(item => new CustomerViewModel()
                {
                    OpenId = item.OpenId,
                    NickName = item.NickName,
                    AvatarUrl = item.AvatarUrl,
                    City = item.City,
                    Country = item.Country,
                    Gender = item.Gender,
                    LastLoginTime = item.LastLoginTime,
                    Province = item.Province,
                }).OrderByDescending(item => item.LastLoginTime).ToList(),
                total = await _customerRepository.CountAsync(filterPaginatedSpecification)
            };

            return result;
        }
    }
}
