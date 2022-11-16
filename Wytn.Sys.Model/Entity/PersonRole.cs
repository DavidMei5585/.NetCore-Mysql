using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wytn.Sys.Model.Entity
{
    /// <summary>
    /// 人員角色Entity
    /// </summary>
    [Table("SYS_PERSON_ROLE")]
    public class PersonRole : BaseEntity
    {
        /// <summary>
        /// 組織Id
        /// </summary>
        [Column("ORG_ID")]
        public string orgId { get; set; }
        /// <summary>
        /// 人員Id
        /// </summary>
        [Column("USER_ID")]
        public string userId { get; set; }
        /// <summary>
        /// 角色uuid
        /// </summary>
        [Column("ROLE_ID")]
        public Guid roleId { get; set; }
    }
}
