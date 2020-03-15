using ApplicationCore.Entities.SystemAggregate;
using System;

namespace Web.ViewModels.User
{
    public class ModuleViewModel
    {
        public int Id { get; set; }

        /// <summary>
        /// 父级节点id
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        /// 模块名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 模块路径
        /// </summary>
        public string ModulePath { get; set; }

        /// <summary>
        /// 是否显示
        /// </summary>
        public bool IsShow { get; set; }

        /// <summary>
        /// 级别
        /// </summary>
        public int Levels { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// 创建人ID
        /// </summary>
        public int CreateUserId { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 修改人Id
        /// </summary>
        public int UpdateUserId { get; set; }

        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime UpdateDate { get; set; }


        public ModuleViewModel ParentModule { get; set; }

        public static implicit operator ModuleViewModel(Module v)
        {
            throw new NotImplementedException();
        }
    }
}
