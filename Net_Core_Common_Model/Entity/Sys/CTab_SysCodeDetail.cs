using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Net_Core_Common_Model.Entity.Sys
{
    /// <summary>
    /// 系統代碼檔(代碼明細)
    /// </summary>
    [Table("Sy_Code_Detail")]
    [Comment("系統代碼檔(代碼明細)")]
    public class CTab_SysCodeDetail
    {
        /// <summary>
        /// 類別代號
        /// </summary>
        [Column("Cfk_CodeMain_Code", TypeName = "nvarchar(50)")]
        [Comment("類別代號")]
        public string Cfk_CodeMain_Code { get; set; }

        /// <summary>
        /// 代碼代號
        /// </summary>
        [Column("Ck_CodeDet_Code", TypeName = "nvarchar(50)")]
        [Comment("代碼代號")]
        public string Ck_CodeDet_Code { get; set; }

        /// <summary>
        /// 代碼名稱
        /// </summary>
        [Column("CodeDet_Name", TypeName = "nvarchar(50)")]
        [Comment("代碼名稱")]
        public string CodeDet_Name { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        [Column("CodeDet_Remark", TypeName = "nvarchar(100)")]
        [Comment("備註")]
        public string? CodeDet_Remark { get; set; }

        /// <summary>
        /// 狀態
        /// </summary>
        [Column("CodeDet_State", TypeName = "nvarchar(1)")]
        [Comment("狀態：「0:停用，1:啟用」")]
        public string CodeDet_State { get; set; }
    }
}
