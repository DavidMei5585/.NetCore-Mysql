namespace Wytn.Sys.Model.Payload
{
    /// <summary>
    /// 選單Payload
    /// </summary>
    public class FuncPayload
    {
        /// <summary>
        /// uuid
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 選單中文名稱
        /// </summary>
        public string funcCname { get; set; }
        /// <summary>
        /// 選單英文名稱
        /// </summary>
        public string funcEname { get; set; }
        /// <summary>
        /// 選單url
        /// </summary>
        public string funcUrl { get; set; }
        /// <summary>
        /// 父選單Id
        /// </summary>
        public string parentId { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int sort { get; set; }
    }
}
