using System.Threading.Tasks;
using ApplicationCore.Entities.CustomersAggregate;
using ApplicationCore.Entities.UserAggregate;

namespace ApplicationCore.Interfaces
{
    public interface ICustomerRepository : IAsyncRepository<Customer>
    {
        Task<Customer> GetItemByOpenIdAsync(string openId);
    }
}