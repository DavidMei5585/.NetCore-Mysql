using System.Collections.Generic;

namespace Wytn.Sys.Model.Dto
{
    /// <summary>
    /// 人員資訊
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// 人員token
        /// </summary>
        public string token { get; set; }
        /// <summary>
        /// 英文姓名 (AD帳號)
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
        /// 機關Id
        /// </summary>
        public string orgId { get; set; }
        /// <summary>
        /// 單位Id
        /// </summary>
        public string deptId { get; set; }
        /// <summary>
        /// 科室Id
        /// </summary>
        public string subdeptId { get; set; }
        /// <summary>
        /// 登入時間
        /// </summary>
        public int timestamp { get; set; }
        /// <summary>
        /// 人員選單
        /// </summary>
        public List<FuncDto> funcs { get; set; }
        /// <summary>
        /// 人員角色
        /// </summary>
        public List<string> roles { get; set; }
    }
}
