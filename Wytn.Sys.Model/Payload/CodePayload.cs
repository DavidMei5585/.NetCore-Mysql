namespace Wytn.Sys.Model.Payload
{
    /// <summary>
    /// 代碼Payload
    /// </summary>
    public class CodePayload
    {
        /// <summary>
        /// uuid
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 父代碼
        /// </summary>
        public string codePno { get; set; }
        /// <summary>
        /// 代碼
        /// </summary>
        public string codeNo { get; set; }
        /// <summary>
        /// 代碼名稱
        /// </summary>
        public string codeName { get; set; }
        /// <summary>
        /// 代碼說明
        /// </summary>
        public string codeDesc { get; set; }
        /// <summary>
        /// 代碼備註
        /// </summary>
        public string codeNote { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int? sort { get; set; }
    }
}
