using System;

using RepoDb.Attributes;

namespace Wytn.Sys.Model.Dto
{
    /// <summary>
    /// 人員Dto
    /// </summary>
    public class PersonDto
    {
        /// <summary>
        /// uuid
        /// </summary>
        [Map("ID")]
        public Guid id { get; set; }
        /// <summary>
        /// 英文姓名 (AD 帳號)
        /// </summary>
        [Map("NAME")]
        public string name { get; set; }
        /// <summary>
        /// 中文姓名
        /// </summary>
        [Map("CNAME")]
        public string cname { get; set; }
        /// <summary>
        /// 人員Id
        /// </summary>
        [Map("USER_ID")]
        public string userId { get; set; }
        /// <summary>
        /// 組織Id
        /// </summary>
        [Map("ORG_ID")]
        public string orgId { get; set; }
        /// <summary>
        /// 單位Id
        /// </summary>
        [Map("DEPT_ID")]
        public string deptId { get; set; }
        /// <summary>
        /// 電子郵件
        /// </summary>
        [Map("EMAIL")]
        public string email { get; set; }
        /// <summary>
        /// 到職日期
        /// </summary>
        [Map("ARRIVE_DATE")]
        public DateTime? arriveDate { get; set; }
        /// <summary>
        /// 角色
        /// </summary>
        [Map("ROLE_ID")]
        public Guid roleId { get; set; }
    }
}
