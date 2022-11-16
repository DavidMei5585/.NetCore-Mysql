using System.ComponentModel.DataAnnotations;

namespace Wytn.Sys.Model.Payload
{
    public class LoginPayload
    {
        /// <summary>
        /// 帳號
        /// </summary>
        [Required]
        public string userId { get; set; }
        /// <summary>
        /// 密碼
        /// </summary>
        [Required]
        public string password { get; set; }
        /// <summary>
        /// 驗證碼(系統產生)
        /// </summary>
        [Required]
        public string code { get; set; }
        /// <summary>
        /// 驗證碼(人員輸入)
        /// </summary>
        [Required]
        public string verifyCode { get; set; }
    }
}
