
using System;

using RepoDb.Attributes;

namespace Wytn.Sys.Model.Dto
{
    /// <summary>
    /// 選單Dto
    /// </summary>
    public class FuncDto
    {
        /// <summary>
        /// 選單uuid
        /// </summary>
        [Map("ID")]
        public string id { get; set; }
        /// <summary>
        /// 選單名稱
        /// </summary>
        [Map("FUNC_CNAME")]
        public string funcCname { get; set; }
        /// <summary>
        /// 選單英文名稱
        /// </summary>
        [Map("FUNC_ENAME")]
        public string funcEname { get; set; }
        /// <summary>
        /// 選單網址
        /// </summary>
        [Map("FUNC_URL")]
        public string funcUrl { get; set; }
        /// <summary>
        /// 父選單uuid
        /// </summary>
        [Map("PARENT_ID")]
        public string parentId { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        [Map("SORT")]
        public int sort { get; set; }
        /// <summary>
        /// 選單路徑 (FUNC_VIEW 產生)
        /// </summary>
        //[Map("FUNC_PATH")]
        //public string funcPath { get; set; }
    }
}
