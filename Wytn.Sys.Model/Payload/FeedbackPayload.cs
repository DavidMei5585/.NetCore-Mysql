namespace Wytn.Sys.Model.Payload
{
    /// <summary>
    /// 問題回饋Payload
    /// </summary>
    public class FeedbackPayload
    {
        /// <summary>
        /// 瀏覽器
        /// </summary>
        public object browser { get; set; }
        /// <summary>
        /// 時間
        /// </summary>
        public long timestamp { get; set; }
        /// <summary>
        /// html
        /// </summary>
        public string html { get; set; }
        /// <summary>
        /// 圖檔
        /// </summary>
        public string img { get; set; }
        /// <summary>
        /// 說明
        /// </summary>
        public string note { get; set; }
    }
}
