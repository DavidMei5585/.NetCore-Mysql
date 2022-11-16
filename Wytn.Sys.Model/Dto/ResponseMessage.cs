namespace Wytn.Sys.Model.Dto
{
    /// <summary>
    /// API 回應格式
    /// </summary>
    public class ResponseMessage
    {
        /// <summary>
        /// 日期
        /// </summary>
        public long timestamp { get; set; }
        /// <summary>
        /// 狀態
        /// </summary>
        public int status { get; set; }
        /// <summary>
        /// 訊息
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 路徑
        /// </summary>
        public string path { get; set; }
    }
}
