using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Net_Core_Common_Model.Entity.Sys
{
    /// <summary>
    /// 系統操作歷程
    /// </summary>
    [Table("Sys_Log_Execute")]
    [Comment("系統操作歷程")]
    public class CTab_SysLogExecute
    {
        /// <summary>
        /// 主鍵
        /// </summary>
        [Key]
        [Column("Pk_LogExec", TypeName = "bigint")]
        [Comment("主鍵")]
        public long Pk_LogExec { get; set; }

        /// <summary>
        /// 異動作業
        /// </summary>
        [Column("LogExec_Module", TypeName = "nvarchar(50)")]
        [Comment("異動作業")]
        public string LogExec_Module { get; set; }

        /// <summary>
        /// 執行動作
        /// </summary>
        [Column("LogExec_Action", TypeName = "nvarchar(50)")]
        [Comment("執行動作")]
        public string LogExec_Action { get; set; }

        /// <summary>
        /// 異動項目
        /// </summary>
        [Column("LogExec_ChangeItem", TypeName = "nvarchar(200)")]
        [Comment("異動項目")]
        public string LogExec_ChangeItem { get; set; }

        /// <summary>
        /// 異動者ID
        /// </summary>
        [Column("LogExec_CreateCode", TypeName = "nvarchar(50)")]
        [Comment("異動者ID")]
        public string LogExec_CreateId { get; set; }

        /// <summary>
        /// 異動時間
        /// </summary>
        [Column("LogExec_CreateDate", TypeName = "datetime")]
        [Comment("異動時間")]
        public DateTime LogExec_CreateDate { get; set; }

        /// <summary>
        /// 異動者IP
        /// </summary>
        [Column("LogExec_CreateIp", TypeName = "nvarchar(30)")]
        [Comment("異動者IP")]
        public string LogExec_CreateIp { get; set; }
    }
}
