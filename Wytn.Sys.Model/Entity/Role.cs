using System.ComponentModel.DataAnnotations.Schema;

namespace Wytn.Sys.Model.Entity
{
    /// <summary>
    /// 角色Entity
    /// </summary>
    [Table("SYS_ROLE")]
    public class Role : BaseEntity
    {
        /// <summary>
        /// 角色
        /// </summary>
        [Column("ROLE_CODE")]
        public string roleCode { get; set; }
        /// <summary>
        /// 角色名稱
        /// </summary>
        [Column("ROLE_NAME")]
        public string roleName { get; set; }
    }
}
