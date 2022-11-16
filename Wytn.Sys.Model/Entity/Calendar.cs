using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wytn.Sys.Model.Entity
{
    /// <summary>
    /// 日曆Entity
    /// </summary>
    [Table("CALENDAR")]
    public class Calendar : BaseEntity
    {
        /// <summary>
        /// 日期
        /// </summary>
        [Column("DATE")]
        public DateTime date { get; set; }
        /// <summary>
        /// 日期名稱
        /// </summary>
        [Column("NAME")]
        public string name { get; set; }
        /// <summary>
        /// 假日 Y/N
        /// </summary>
        [Column("IS_HOLIDAY")]
        public string isHoliday { get; set; }
        /// <summary>
        /// 節日類型描述
        /// </summary>
        [Column("CATEGORY")]
        public string category { get; set; }
        /// <summary>
        /// 說明
        /// </summary>
        [Column("DESCRIPTION")]
        public string description { get; set; }
    }
}
