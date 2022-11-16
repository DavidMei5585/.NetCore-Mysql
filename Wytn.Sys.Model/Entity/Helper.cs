using System.ComponentModel.DataAnnotations.Schema;

namespace Wytn.Sys.Model.Entity
{
    /// <summary>
    /// 使用教學Entity
    /// </summary>
    [Table("HELPER")]
    public class Helper : BaseEntity
    {
        /// <summary>
        /// 名稱 (url)
        /// </summary>
        [Column("NAME")]
        public string name { get; set; }
        /// <summary>
        /// 檔案路徑
        /// </summary>
        [Column("FILE_PATH")]
        public string filePath { get; set; }
        /// <summary>
        /// 檔案名稱
        /// </summary>
        [Column("FILE_NAME")]
        public string fileName { get; set; }
        /// <summary>
        /// 真實檔案名稱
        /// </summary>
        [Column("REAL_NAME")]
        public string realName { get; set; }
    }
}
