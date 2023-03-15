using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Net_Core_Common_Model.Entity.Sys
{
    /// <summary>
    /// 程式執行Log
    /// </summary>
    [Table("Sys_Log_Trajectory")]
    [Comment("程式執行Log")]
    public class CTab_SysLogTrajectory
    {
        /// <summary>
        /// 主鍵
        /// </summary>
        [Key]
        [Column("Pk_LogTra", TypeName = "bigint")]
        [Comment("主鍵")]
        public long Pk_LogTra { get; set; }

        /// <summary>
        /// Route Group
        /// </summary>
        [Column("LogTra_Group", TypeName = "nvarchar(50)")]
        [Comment("Route Group")]
        public string LogTra_Group { get; set; }

        /// <summary>
        /// Route Controller
        /// </summary>
        [Column("LogTra_Controller", TypeName = "nvarchar(50)")]
        [Comment("Route Controller")]
        public string LogTra_Controller { get; set; }

        /// <summary>
        /// Route Action
        /// </summary>
        [Column("LogTra_Action", TypeName = "nvarchar(50)")]
        [Comment("Route Action")]
        public string LogTra_Action { get; set; }

        /// <summary>
        /// Request內容
        /// </summary>
        [Column("LogTra_RequestContent", TypeName = "nvarchar(max)")]
        [Comment("Request內容")]
        public string LogTra_RequestContent { get; set; }

        /// <summary>
        /// Request時間
        /// </summary>
        [Column("LogTra_RequestTime", TypeName = "datetime")]
        [Comment("Request時間")]
        public DateTime LogTra_RequestTime { get; set; }

        /// <summary>
        /// Response內容
        /// </summary>
        [Column("LogTra_ResponseContent", TypeName = "nvarchar(max)")]
        [Comment("Response內容")]
        public string LogTra_ResponseContent { get; set; }

        /// <summary>
        /// Response時間
        /// </summary>
        [Column("LogTra_ResponseTime", TypeName = "datetime")]
        [Comment("Response時間")]
        public DateTime LogTra_ResponseTime { get; set; }

        /// <summary>
        /// IIS HOST
        /// </summary>
        [Column("LogTra_IisHost", TypeName = "nvarchar(50)")]
        [Comment("IIS HOST")]
        public string LogTra_IisHost { get; set; }

        /// <summary>
        /// UserAgent
        /// </summary>
        [Column("LogTra_Agent", TypeName = "nvarchar(200)")]
        [Comment("UserAgent")]
        public string LogTra_Agent { get; set; }

        /// <summary>
        /// 建立者ID
        /// </summary>
        [Column("LogTra_CreateId", TypeName = "nvarchar(50)")]
        [Comment("建立者ID(Log的建立者有可能是訪客，所以型態用String)")]
        public string LogTra_CreateId { get; set; }

        /// <summary>
        /// 建檔日期
        /// </summary>
        [Column("LogTra_CreateDate", TypeName = "datetime")]
        [Comment("建檔日期")]
        public DateTime LogTra_CreateDate { get; set; }

        /// <summary>
        /// 建立者IP
        /// </summary>
        [Column("LogTra_CreateIp", TypeName = "nvarchar(30)")]
        [Comment("建立者IP")]
        public string LogTra_CreateIp { get; set; }
    }
}