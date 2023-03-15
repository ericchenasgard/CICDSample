using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Net_Core_Common_Model.Entity.Sys
{
    /// <summary>
    /// 登入Log
    /// </summary>
    [Table("Sys_Log_Login")]
    [Comment("登入Log")]
    public class CTab_SysLogLogin
    {
        /// <summary>
        /// 主鍵
        /// </summary>
        [Key]
        [Column("Pk_LogLogin", TypeName = "bigint")]
        [Comment("主鍵")]
        public long Pk_LogLogin { get; set; }

        /// <summary>
        /// 帳號
        /// </summary>
        [Column("LogLogin_Account", TypeName = "nvarchar(100)")]
        [Comment("帳號")]
        public string LogLogin_Account { get; set; }

        /// <summary>
        /// UserAgent
        /// </summary>
        [Column("LogLogin_UserAgent", TypeName = "nvarchar(200)")]
        [Comment("UserAgent")]
        public string LogLogin_UserAgent { get; set; }

        /// <summary>
        /// 登入訊息
        /// </summary>
        [Column("LogLogin_Message", TypeName = "nvarchar(500)")]
        [Comment("登入訊息")]
        public string LogLogin_Message { get; set; }

        /// <summary>
        /// 登入成功與否
        /// </summary>
        [Column("LogLogin_Result", TypeName = "bit")]
        [Comment("登入成功與否 (0:失敗，1成功)")]
        public bool LogLogin_Result { get; set; }

        /// <summary>
        /// IIS HOST
        /// </summary>
        [Column("LogLogin_IisHost", TypeName = "nvarchar(50)")]
        [Comment("IIS HOST")]
        public string LogLogin_IisHost { get; set; }

        /// <summary>
        /// 建檔日期
        /// </summary>
        [Column("LogLogin_CreateDate", TypeName = "datetime")]
        [Comment("建檔日期")]
        public DateTime LogLogin_CreateDate { get; set; }

        /// <summary>
        /// 建立者IP
        /// </summary>
        [Column("LogLogin_CreateIp", TypeName = "nvarchar(30)")]
        [Comment("建立者IP")]
        public string LogLogin_CreateIp { get; set; }
    }
}