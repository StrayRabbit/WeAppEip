using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.ViewModels.Customer;

namespace Web.Interfaces
{
    public interface ICustomerViewModelService
    {
        Task CreateOrModifyAsync(CustomerViewModel customer);
    }
}
