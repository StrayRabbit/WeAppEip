using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeAppEip.Web.ViewModels;
using Web.ViewModels.Customer;

namespace Web.Interfaces
{
    public interface ICustomerViewModelService
    {
        Task CreateOrModifyAsync(CustomerViewModel customer);

        Task<PaginationViewModel<CustomerViewModel>> GetItemsAsync(string openId, string name, int skipCount = 0, int takeCount = 0);
    }
}
