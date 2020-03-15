using System.Threading.Tasks;
using ApplicationCore.Entities.CustomersAggregate;
using ApplicationCore.Entities.NewsAggregate;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace WeAppEip.Infrastructure.Data
{
    public class CustomerRepository : EfRepository<Customer>, ICustomerRepository
    {


        public CustomerRepository(EipContext dbContext) : base(dbContext)
        {
        }

        public async Task<Customer> GetItemByOpenIdAsync(string openId)
        {
            return await _dbContext.Customers.FirstOrDefaultAsync(item => item.OpenId == openId);
        }
    }
}