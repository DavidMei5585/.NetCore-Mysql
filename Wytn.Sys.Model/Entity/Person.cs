using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wytn.Sys.Model.Entity
{
    /// <summary>
    /// 人員Entity
    /// </summary>
    [Table("SYS_PERSON")]
    public class Person : BaseEntity
    {
        /// <summary>
        /// 英文姓名 (AD 帳號)
        /// </summary>
        [Column("NAME")]
        public string name { get; set; }
        /// <summary>
        /// 中文姓名
        /// </summary>
        [Column("CNAME")]
        public string cname { get; set; }
        /// <summary>
        /// 人員Id
        /// </summary>
        [Column("USER_ID")]
        public string userId { get; set; }
        /// <summary>
        /// 密碼
        /// </summary>
        [Column("PASSWORD")]
        public string password { get; set; }
        /// <summary>
        /// 電子郵件
        /// </summary>
        [Column("EMAIL")]
        public string email { get; set; }
        /// <summary>
        /// 到職日期
        /// </summary>
        [Column("ARRIVE_DATE")]
        public DateTime? arriveDate { get; set; }
        /// <summary>
        /// 離職日期
        /// </summary>
        [Column("LEAVE_DATE")]
        public DateTime? leaveDate { get; set; }
        /// <summary>
        /// 最後登入時間
        /// </summary>
        [Column("LAST_LOGIN_DATE")]
        public DateTime? lastLoginDate { get; set; }
        /// <summary>
        /// 登入時間
        /// </summary>
        [Column("LOGIN_DATE")]
        public DateTime? loginDate { get; set; }
        /// <summary>
        /// 組織Id
        /// </summary>
        [Column("ORG_ID")]
        public string orgId { get; set; }
        /// <summary>
        /// 單位Id
        /// </summary>
        [Column("DEPT_ID")]
        public string deptId { get; set; }
        /// <summary>
        /// 職稱Id
        /// </summary>
        [Column("TITLE_ID")]
        public string titleId { get; set; }
        /// <summary>
        /// 狀態
        /// </summary>
        [Column("FLAG")]
        public int flag { get; set; }
        /// <summary>
        /// 科室Id
        /// </summary>
        [Column("SUBDEPT_ID")]
        public string subdeptId { get; set; }
    }
}
