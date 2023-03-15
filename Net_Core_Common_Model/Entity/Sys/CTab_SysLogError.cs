using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Net_Core_Common_Model.Entity.Sys
{
    /// <summary>
    /// 錯誤Log
    /// </summary>
    [Table("Sys_Log_Error")]
    [Comment("錯誤Log")]
    public class CTab_SysLogError
    {
        /// <summary>
        /// 主鍵
        /// </summary>
        [Key]
        [Column("Pk_LogError", TypeName = "bigint")]
        [Comment("主鍵")]
        public long Pk_LogError { get; set; }

        /// <summary>
        /// Exception Type
        /// </summary>
        [Column("LogError_ExceptionType", TypeName = "nvarchar(200)")]
        [Comment("Exception Type")]
        public string LogError_ExceptionType { get; set; }

        /// <summary>
        /// Exception Source
        /// </summary>
        [Column("LogError_ExceptionSource", TypeName = "nvarchar(200)")]
        [Comment("Exception Source")]
        public string LogError_ExceptionSource { get; set; }

        /// <summary>
        /// Exception StackTrace
        /// </summary>
        [Column("LogError_ExceptionStackTrace", TypeName = "nvarchar(max)")]
        [Comment("Exception StackTrace")]
        public string LogError_ExceptionStackTrace { get; set; }

        /// <summary>
        /// Exception TargetSite
        /// </summary>
        [Column("LogError_ExceptionTargetSite", TypeName = "nvarchar(200)")]
        [Comment("Exception TargetSite")]
        public string LogError_ExceptionTargetSite { get; set; }

        /// <summary>
        /// Exception Message
        /// </summary>
        [Column("LogError_ExceptionMessage", TypeName = "nvarchar(max)")]
        [Comment("Exception Message")]
        public string LogError_ExceptionMessage { get; set; }

        /// <summary>
        /// IIS HOST
        /// </summary>
        [Column("LogError_IisHost", TypeName = "nvarchar(50)")]
        [Comment("IIS HOST")]
        public string LogError_IisHost { get; set; }

        /// <summary>
        /// UserAgent
        /// </summary>
        [Column("LogError_Agent", TypeName = "nvarchar(200)")]
        [Comment("UserAgent")]
        public string LogError_Agent { get; set; }

        /// <summary>
        /// 建立者ID
        /// </summary>
        [Column("LogError_CreateId", TypeName = "nvarchar(50)")]
        [Comment("建立者ID(Log的建立者有可能是訪客，所以型態用String)")]
        public string LogError_CreateId { get; set; }

        /// <summary>
        /// 建檔日期
        /// </summary>
        [Column("LogError_CreateDate", TypeName = "datetime")]
        [Comment("建檔日期")]
        public DateTime LogError_CreateDate { get; set; }

        /// <summary>
        /// 建立者IP
        /// </summary>
        [Column("LogError_CreateIp", TypeName = "nvarchar(30)")]
        [Comment("建立者IP")]
        public string LogError_CreateIp { get; set; }
    }
}