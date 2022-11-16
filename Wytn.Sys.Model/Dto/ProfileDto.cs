using System;

namespace Wytn.Sys.Model.Dto
{
    /// <summary>
    /// 個人資料Dto
    /// </summary>
    public class ProfileDto
    {
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
        /// <summary>
        /// 到職日期
        /// </summary>
        public DateTime arriveDate { get; set; }
        /// <summary>
        /// 離職日期
        /// </summary>
        public DateTime leaveDate { get; set; }
        /// <summary>
        /// 最後登入時間
        /// </summary>
        public DateTime lastLoginDate { get; set; }
        /// <summary>
        /// 登入時間
        /// </summary>
        public DateTime loginDate { get; set; }
        /// <summary>
        /// 組織Id
        /// </summary>
        public string orgId { get; set; }
        /// <summary>
        /// 單位Id
        /// </summary>
        public string deptId { get; set; }
        /// <summary>
        /// 職稱Id
        /// </summary>
        public string titleId { get; set; }
    }
}
