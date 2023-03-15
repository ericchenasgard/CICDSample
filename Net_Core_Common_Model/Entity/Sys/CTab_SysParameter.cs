using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Net_Core_Common_Model.Entity.Sys
{
    /// <summary>
    /// 系統參數檔
    /// </summary>
    [Table("Sys_Parameter")]
    [Comment("系統參數檔")]
    public class CTab_SysParameter
    {
        /// <summary>
        /// 參數群組
        /// </summary>
        [Column("Ck_Par_Group", TypeName = "nvarchar(50)")]
        [Comment("參數群組")]
        public string Ck_Par_Group { get; set; }

        /// <summary>
        /// 參數編號
        /// </summary>
        [Column("Ck_Par_Code", TypeName = "nvarchar(50)")]
        [Comment("參數編號")]
        public string Ck_Par_Code { get; set; }

        /// <summary>
        /// 參數名稱
        /// </summary>
        [Column("Par_Name", TypeName = "nvarchar(50)")]
        [Comment("參數名稱")]
        public string Par_Name { get; set; }

        /// <summary>
        /// 狀態
        /// </summary>
        [Column("Par_State", TypeName = "nvarchar(1)")]
        [Comment("狀態：「0:停用，1:啟用」")]
        public string Par_State { get; set; }

        /// <summary>
        /// 值1
        /// </summary>
        [Column("Par_Value1", TypeName = "nvarchar(200)")]
        [Comment("值1")]
        public string Par_Value1 { get; set; }

        /// <summary>
        /// 值2
        /// </summary>
        [Column("Par_Value2", TypeName = "nvarchar(200)")]
        [Comment("值2")]
        public string? Par_Value2 { get; set; }

        /// <summary>
        /// 值3
        /// </summary>
        [Column("Par_Value3", TypeName = "nvarchar(200)")]
        [Comment("值3")]
        public string? Par_Value3 { get; set; }

        /// <summary>
        /// 值4
        /// </summary>
        [Column("Par_Value4", TypeName = "nvarchar(200)")]
        [Comment("值4")]
        public string? Par_Value4 { get; set; }

        /// <summary>
        /// 值5
        /// </summary>
        [Column("Par_Value5", TypeName = "nvarchar(200)")]
        [Comment("值5")]
        public string? Par_Value5 { get; set; }

        /// <summary>
        /// 值6
        /// </summary>
        [Column("Par_Value6", TypeName = "nvarchar(200)")]
        [Comment("值6")]
        public string? Par_Value6 { get; set; }

        /// <summary>
        /// 值7
        /// </summary>
        [Column("Par_Value7", TypeName = "nvarchar(200)")]
        [Comment("值7")]
        public string? Par_Value7 { get; set; }

        /// <summary>
        /// 值8
        /// </summary>
        [Column("Par_Value8", TypeName = "nvarchar(200)")]
        [Comment("值8")]
        public string? Par_Value8 { get; set; }

        /// <summary>
        /// 值9
        /// </summary>
        [Column("Par_Value9", TypeName = "nvarchar(200)")]
        [Comment("值9")]
        public string? Par_Value9 { get; set; }

        /// <summary>
        /// 值10
        /// </summary>
        [Column("Par_Value10", TypeName = "nvarchar(200)")]
        [Comment("值10")]
        public string? Par_Value10 { get; set; }

        /// <summary>
        /// 說明
        /// </summary>
        [Column("Par_Remarks", TypeName = "nvarchar(200)")]
        [Comment("說明")]
        public string? Par_Remarks { get; set; }

        /// <summary>
        /// 建立者ID
        /// </summary>
        [Column("Par_CreateId", TypeName = "nvarchar(50)")]
        [Comment("建立者ID")]
        public string Par_CreateId { get; set; }

        /// <summary>
        /// 建檔日期
        /// </summary>
        [Column("Par_CreateDate", TypeName = "datetime")]
        [Comment("建檔日期")]
        public DateTime Par_CreateDate { get; set; }

        /// <summary>
        /// 建立者IP
        /// </summary>
        [Column("Par_CreateIp", TypeName = "nvarchar(30)")]
        [Comment("建立者IP")]
        public string Par_CreateIp { get; set; }

        /// <summary>
        /// 異動者ID
        /// </summary>
        [Column("Par_EditId", TypeName = "nvarchar(50)")]
        [Comment("異動者ID")]
        public string Par_EditId { get; set; }

        /// <summary>
        /// 異動日期
        /// </summary>
        [Column("Par_EditDate", TypeName = "datetime")]
        [Comment("異動日期")]
        public DateTime Par_EditDate { get; set; }

        /// <summary>
        /// 異動者IP
        /// </summary>
        [Column("Par_EditIp", TypeName = "nvarchar(30)")]
        [Comment("異動者IP")]
        public string Par_EditIp { get; set; }
    }
}
