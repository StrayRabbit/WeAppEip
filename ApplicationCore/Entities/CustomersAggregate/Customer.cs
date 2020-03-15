using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ApplicationCore.Entities.CustomersAggregate
{
    [Table("customers")]
    public class Customer : BaseEntity<int>, IAggregateRoot
    {
        #region 属性
        /// <summary>
        /// openId
        /// </summary>
        [Column("openid")]
        public string OpenId { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        [Column("nickName")]
        public string NickName { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        [Column("avatarUrl")]
        public string AvatarUrl { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [Column("gender")]
        public int Gender { get; set; }

        /// <summary>
        /// 国家
        /// </summary>
        [Column("country")]
        public string Country { get; set; }

        /// <summary>
        /// 省份
        /// </summary>
        [Column("province")]
        public string Province { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        [Column("city")]
        public string City { get; set; }

        /// <summary>
        /// 最后登录时间
        /// </summary>
        [Column("lastLoginTime")]
        public DateTime LastLoginTime { get; set; }
        #endregion
    }
}
