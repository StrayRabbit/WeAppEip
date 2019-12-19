using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities.UserAggregate;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace WeAppEip.Infrastructure.Data
{
    public class UserRepository : EfRepository<User>, IUserRepository
    {
        public UserRepository(EipContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="passwrod">密码</param>
        /// <returns></returns>
        public async Task<User> GetUser(string account, string passwrod)
        {
            return await _dbContext.Users
                .FirstOrDefaultAsync(item => item.Account == account && item.Password == passwrod);
        }
    }
}
