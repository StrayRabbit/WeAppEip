using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ApplicationCore.Entities.UserAggregate
{
    /// <summary>
    /// 用户信息表
    /// </summary>
    [Table("sys_users")]
    public class User : BaseEntity<int>, IAggregateRoot
    {
        #region 属性
        /// <summary>
        /// 姓名
        /// </summary>
        [Column("name")]
        public string Name { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        [Column("account")]
        public string Account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Column("password")]
        public string Password { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary>
        [Column("roleid")]
        public int Roleid { get; set; }

        /// <summary>
        /// 创建人ID
        /// </summary>
        [Column("createuserid")]
        public int CreateUserId { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        [Column("createdate")]
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 修改人Id
        /// </summary>
        [Column("updateuserid")]
        public int? UpdateUserId { get; set; }

        /// <summary>
        /// 修改日期
        /// </summary>
        [Column("updatedate")]
        public DateTime? UpdateDate { get; set; }
        #endregion
    }
}
