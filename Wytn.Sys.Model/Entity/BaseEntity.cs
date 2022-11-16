using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using RepoDb.Attributes;

namespace Wytn.Sys.Model.Entity
{
    /// <summary>
    /// 基礎Entity，含共用欄位 ID、CRE_USER、CRE_DATE、UPD_USER、UPD_DATE
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// uuid
        /// </summary>
        [Primary, Column("ID")]
        public Guid id { get; set; }
        /// <summary>
        /// 建立者
        /// </summary>
        [Column("CRE_USER"), JsonIgnore]
        public string creUser { get; set; }
        /// <summary>
        /// 建立日期
        /// </summary>
        [Column("CRE_DATE"), JsonIgnore]
        public DateTime? creDate { get; set; }
        /// <summary>
        /// 修改者
        /// </summary>
        [Column("UPD_USER"), JsonIgnore]
        public string updUser { get; set; }
        /// <summary>
        /// 修改日期
        /// </summary>
        [Column("UPD_DATE"), JsonIgnore]
        public DateTime? updDate { get; set; }
    }
}
