using System;

namespace Wytn.Sys.Model.Payload
{
    /// <summary>
    /// 日曆Payload
    /// </summary>
    public class CalendarPayload
    {
        /// <summary>
        /// uuid
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime date { get; set; }
        /// <summary>
        /// 日期名稱
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 假日 Y/N
        /// </summary>
        public string isHoliday { get; set; }
        /// <summary>
        /// 節日類型描述
        /// </summary>
        public string category { get; set; }
        /// <summary>
        /// 說明
        /// </summary>
        public string description { get; set; }
    }
}
