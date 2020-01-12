using System;
using System.ComponentModel.DataAnnotations.Schema;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities.SystemAggregate
{
    /// <summary>
    /// 模块
    /// </summary>
    [Table("sys_modules")]
    public class Module : BaseEntity<int>, IAggregateRoot
    {
        #region 属性

        /// <summary>
        /// 父级节点id
        /// </summary>
        [Column("parentid")]
        public int ParentId { get; set; }

        /// <summary>
        /// 模块名称
        /// </summary>
        [Column("name")]
        public string Name { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        [Column("icon")]
        public string Icon { get; set; }

        /// <summary>
        /// 模块路径
        /// </summary>
        [Column("modulepath")]
        public string ModulePath { get; set; }

        /// <summary>
        /// 是否显示
        /// </summary>
        [Column("isshow", TypeName = "BIT")]
        public bool IsShow { get; set; }

        /// <summary>
        /// 级别
        /// </summary>
        [Column("levels")]
        public int Levels { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [Column("order")]
        public int Order { get; set; }

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

        #region 导航属性
        //public virtual Module ParentModule { get; set; }
        #endregion
    }

    //public class ModuleMap : EntityTypeConfiguration<Module>
    //{

    //}
}
