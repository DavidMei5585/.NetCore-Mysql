
using RepoDb.Attributes;

namespace Wytn.Sys.Model.Dto
{
    /// <summary>
    /// 代碼Dto
    /// </summary>
    public class CodeDto
    {
        /// <summary>
        /// 父代碼
        /// </summary>
        [Map("CODE_PNO")]
        public string codePno { get; set; }
        /// <summary>
        /// 代碼
        /// </summary>
        [Map("CODE_NO")]
        public string codeNo { get; set; }
        /// <summary>
        /// 代碼名稱
        /// </summary>
        [Map("CODE_NAME")]
        public string codeName { get; set; }
        /// <summary>
        /// 代碼描述
        /// </summary>
        [Map("CODE_DESC")]
        public string codeDesc { get; set; }
        /// <summary>
        /// 代碼說明
        /// </summary>
        [Map("CODE_NOTE")]
        public string codeNote { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        [Map("SORT")]
        public int sort { get; set; }
    }
}
