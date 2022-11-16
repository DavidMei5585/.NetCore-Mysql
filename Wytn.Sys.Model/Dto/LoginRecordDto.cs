using System;

using RepoDb.Attributes;

namespace Wytn.Sys.Model.Dto
{
    /// <summary>
    /// 登入紀錄Dto
    /// </summary>
    public class LoginRecordDto
    {
        /// <summary>
        /// uuid
        /// </summary>
        [Map("ID")]
        public Guid id { get; set; }
        /// <summary>
        /// 人員Id
        /// </summary>
        [Map("USER_ID")]
        public string userId { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        [Map("CNAME")]
        public string cname { get; set; }
        /// <summary>
        /// 登入日期
        /// </summary>
        [Map("CRE_DATE")]
        public DateTime loginDate { get; set; }
    }
}
