using System.ComponentModel.DataAnnotations.Schema;

namespace Wytn.Sys.Model.Entity
{
    /// <summary>
    /// 連結Token Entity
    /// </summary>
    [Table("LINK_TOKEN")]
    public class LinkToken : BaseEntity
    {
        /// <summary>
        /// 人員Id
        /// </summary>
        [Column("USER_ID")]
        public string userId { get; set; }
        /// <summary>
        /// Token 狀態
        /// 1:IIS AD驗證產生、2:IIS AD驗證通過
        /// 3:忘記密碼產生、4:忘記密碼驗證通過
        /// </summary>
        [Column("FLAG")]
        public int flag { get; set; }
    }
}
