using System.ComponentModel.DataAnnotations.Schema;

namespace Wytn.Sys.Model.Entity
{
    /// <summary>
    /// 登入紀錄Entity
    /// </summary>
    [Table("SYS_LOGIN_RECORD")]
    public class LoginRecord : BaseEntity
    {
        /// <summary>
        /// 人員Id
        /// </summary>
        [Column("USER_ID")]
        public string userId { get; set; }
        /// <summary>
        /// 狀態
        /// 1:登入、2:登出、3:中斷 (失效)
        /// </summary>
        [Column("FLAG")]
        public int flag { get; set; }
    }
}
