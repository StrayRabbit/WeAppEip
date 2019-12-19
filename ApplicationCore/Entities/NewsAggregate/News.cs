using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities.NewsAggregate
{
    /// <summary>
    /// 新闻
    /// </summary>
    [Table("news")]
    public class News : BaseEntity<int>, IAggregateRoot
    {
        #region 属性

        /// <summary>
        /// 类型 1新闻 2活动
        /// </summary>
        [Column("type")]
        public int Type { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        [Column("title")]
        public string Title { get; set; }

        /// <summary>
        /// 封面图片
        /// </summary>
        [Column("image_url")]
        public string ImageUrl { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        [Column("introduction")]
        public string Introduction { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        [Column("content")]
        public string Content { get; set; }

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
