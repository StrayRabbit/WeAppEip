using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeAppEip.Web.ViewModels
{
    /// <summary>
    /// 账号
    /// </summary>
    public class Account
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 账户
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// 角色Id
        /// </summary>
        public int RoleId { get; set; }

    }
}
