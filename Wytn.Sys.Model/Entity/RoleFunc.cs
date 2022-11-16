using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wytn.Sys.Model.Entity
{
    /// <summary>
    /// 角色選單Entity
    /// </summary>
    [Table("SYS_ROLE_FUNC")]
    public class RoleFunc : BaseEntity
    {
        /// <summary>
        /// 角色Id
        /// </summary>
        [Column("ROLE_ID")]
        public Guid roleId { get; set; }
        /// <summary>
        /// 選單Id
        /// </summary>
        [Column("FUNC_ID")]
        public Guid funcId { get; set; }
    }
}
