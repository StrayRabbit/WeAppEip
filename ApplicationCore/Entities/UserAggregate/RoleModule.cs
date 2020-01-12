using System.ComponentModel.DataAnnotations.Schema;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities.UserAggregate
{
    /// <summary>
    /// 模块角色映射
    /// </summary>
    [Table("sys_rolemodules")]
    public class RoleModule : BaseEntity<int>, IAggregateRoot
    {
        [Column("roleid")]
        public int RoleId { get; set; }

        [Column("moduleid")]
        public int ModuleId { get; set; }
    }
}