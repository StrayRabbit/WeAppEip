using System.Threading.Tasks;
using ApplicationCore.Entities.UserAggregate;

namespace ApplicationCore.Interfaces
{
    public interface IUserRepository : IAsyncRepository<User>
    {
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="passwrod">密码</param>
        /// <returns></returns>
        Task<User> GetUser(string account, string passwrod);
    }
}