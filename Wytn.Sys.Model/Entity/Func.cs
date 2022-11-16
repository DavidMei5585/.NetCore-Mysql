using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wytn.Sys.Model.Entity
{
    /// <summary>
    /// 選單Entity
    /// </summary>
    [Table("SYS_FUNC")]
    public class Func : BaseEntity
    {
        /// <summary>
        /// 選單中文名稱
        /// </summary>
        [Column("FUNC_CNAME")]
        public string funcCname { get; set; }
        /// <summary>
        /// 選單英文名稱
        /// </summary>
        [Column("FUNC_ENAME")]
        public string funcEname { get; set; }
        /// <summary>
        /// 選單url
        /// </summary>
        [Column("FUNC_URL")]
        public string funcUrl { get; set; }
        /// <summary>
        /// 父選單uuid
        /// </summary>
        [Column("PARENT_ID")]
        public string parentId { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        [Column("SORT")]
        public int sort { get; set; }

    }
}
