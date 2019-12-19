using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities.SystemAggregate
{
    /// <summary>
    /// 角色
    /// </summary>
    [Table("sys_roles")]
    public class Role : BaseEntity<int>, IAggregateRoot
    {
        #region 属性

        /// <summary>
        /// 角色名称
        /// </summary>
        [Column("name")]
        public string Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [Column("description")]
        public string Description { get; set; }

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
        public int UpdateUserId { get; set; }

        /// <summary>
        /// 修改日期
        /// </summary>
        [Column("updatedate")]
        public DateTime UpdateDate { get; set; }
        #endregion
    }
}
