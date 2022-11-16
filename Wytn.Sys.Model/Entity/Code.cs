using System.ComponentModel.DataAnnotations.Schema;

namespace Wytn.Sys.Model.Entity
{
    /// <summary>
    /// 代碼Entity
    /// </summary>
    [Table("SYS_CODE")]
    public class Code : BaseEntity
    {
        /// <summary>
        /// 父代碼
        /// </summary>
        [Column("CODE_PNO")]
        public string codePno { get; set; }
        /// <summary>
        /// 代碼
        /// </summary>
        [Column("CODE_NO")]
        public string codeNo { get; set; }
        /// <summary>
        /// 代碼名稱
        /// </summary>
        [Column("CODE_NAME")]
        public string codeName { get; set; }
        /// <summary>
        /// 代碼說明
        /// </summary>
        [Column("CODE_DESC")]
        public string codeDesc { get; set; }
        /// <summary>
        /// 代碼備註
        /// </summary>
        [Column("CODE_NOTE")]
        public string codeNote { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        [Column("SORT")]
        public int sort { get; set; }
    }
}
