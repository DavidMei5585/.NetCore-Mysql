using System;

namespace Wytn.Sys.Model.Dto
{
    /// <summary>
    /// 驗證碼
    /// </summary>
    public class ImageCode
    {
        /// <summary>
        /// 驗證碼圖檔base64
        /// </summary>
        public string image { get; set; }
        /// <summary>
        /// 驗證碼
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// 到期時間
        /// </summary>
        public DateTime expireTime { get; set; }
    }
}
