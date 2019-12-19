using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities.UserAggregate
{
    /// <summary>
    /// 模块角色映射
    /// </summary>
    [Table("sys_rolemodules")]
    public class RoleModule : BaseEntity<int>
    {
        [Column("roleid")]
        public int RoleId { get; set; }

        [Column("moduleid")]
        public int ModuleId { get; set; }
    }
}