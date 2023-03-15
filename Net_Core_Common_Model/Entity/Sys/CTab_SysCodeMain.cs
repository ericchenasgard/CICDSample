using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Net_Core_Common_Model.Entity.Sys
{
    /// <summary>
    /// 系統代碼檔(代碼類別)
    /// </summary>
    [Table("Sys_Code_Main")]
    [Comment("系統代碼檔(代碼類別)")]
    public class CTab_SysCodeMain
    {
        /// <summary>
        /// 類別代號
        /// </summary>
        [Key]
        [Column("Pk_CodeMain_Code", TypeName = "nvarchar(50)")]
        [Comment("類別代號")]
        public string Pk_CodeMain_Code { get; set; }

        /// <summary>
        /// 類別名稱
        /// </summary>
        [Column("CodeMain_Name", TypeName = "nvarchar(50)")]
        [Comment("類別名稱")]
        public string CodeMain_Name { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        [Column("CodeMain_Remark", TypeName = "nvarchar(300)")]
        [Comment("備註")]
        public string? CodeMain_Remark { get; set; }

        /// <summary>
        /// 狀態
        /// </summary>
        [Column("CodeMain_State", TypeName = "nvarchar(1)")]
        [Comment("狀態：「0:停用，1:啟用」")]
        public string CodeMain_State { get; set; }

        /// <summary>
        /// 建立者ID
        /// </summary>
        [Column("CodeMain_CreateId", TypeName = "nvarchar(50)")]
        [Comment("建立者ID")]
        public string CodeMain_CreateId { get; set; }

        /// <summary>
        /// 建檔日期
        /// </summary>
        [Column("CodeMain_CreateDate", TypeName = "datetime")]
        [Comment("建檔日期")]
        public DateTime CodeMain_CreateDate { get; set; }

        /// <summary>
        /// 建立者IP
        /// </summary>
        [Column("CodeMain_CreateIp", TypeName = "nvarchar(30)")]
        [Comment("建立者IP")]
        public string CodeMain_CreateIp { get; set; }

        /// <summary>
        /// 異動者ID
        /// </summary>
        [Column("CodeMain_EditId", TypeName = "nvarchar(50)")]
        [Comment("異動者ID")]
        public string CodeMain_EditId { get; set; }

        /// <summary>
        /// 異動日期
        /// </summary>
        [Column("CodeMain_EditDate", TypeName = "datetime")]
        [Comment("異動日期")]
        public DateTime CodeMain_EditDate { get; set; }

        /// <summary>
        /// 異動者IP
        /// </summary>
        [Column("CodeMain_EditIp", TypeName = "nvarchar(30)")]
        [Comment("異動者IP")]
        public string CodeMain_EditIp { get; set; }
    }
}
