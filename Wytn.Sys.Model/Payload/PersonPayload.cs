using System;

namespace Wytn.Sys.Model.Payload
{
    /// <summary>
    /// 人員Payload
    /// </summary>
    public class PersonPayload
    {
        /// <summary>
        /// uuid
        /// </summary>
        public string id { get; set; }
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
        public DateTime? arriveDate { get; set; }
        /// <summary>
        /// 離職日期
        /// </summary>
        public DateTime? leaveDate { get; set; }
        /// <summary>
        /// 組織Id
        /// </summary>
        public string orgId { get; set; }
        /// <summary>
        /// 單位Id
        /// </summary>
        public string deptId { get; set; }
        /// <summary>
        /// 角色Id
        /// </summary>
        public string[] roleIds { get; set; }
    }
}
