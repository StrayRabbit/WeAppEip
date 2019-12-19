using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities.NewsAggregate
{
    /// <summary>
    /// 横幅
    /// </summary>
    [Table("banners")]
    public class Banner : BaseEntity<int>, IAggregateRoot
    {
        #region 属性

        /// <summary>
        /// 描述
        /// </summary>
        [Column("description")]
        public string Description { get; set; }

        /// <summary>
        /// 图片地址
        /// </summary>
        [Column("image_url")]
        public string ImageUrl { get; set; }

        /// <summary>
        /// 连接地址
        /// </summary>
        [Column("href")]
        public string Href { get; set; }

        [Column("order")]
        public int? Order { get; set; }

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
