using System;

namespace Wytn.Sys.Model.Payload
{
    /// <summary>
    /// 人員資料Payload
    /// </summary>
    public class ProfilePayload
    {
        /// <summary>
        /// uuid
        /// </summary>
        public Guid id { get; set; }
        /// <summary>
        /// 英文姓名 (AD 帳號)
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 中文姓名
        /// </summary>
        public string cname { get; set; }
        /// <summary>
        /// 人員Id
        /// </summary>
        public string userId { get; set; }
        /// <summary>
        /// 電子郵件
        /// </summary>
        public string email { get; set; }

    }
}
