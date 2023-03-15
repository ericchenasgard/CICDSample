using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Net_Core_Common_Model.Entity.Sys
{
    /// <summary>
    /// 選單作業
    /// </summary>
    [Table("Sys_Module")]
    [Comment("選單作業")]
    public class CTab_SysModule
    {
        /// <summary>
        /// 主鍵
        /// </summary>
        [Key]
        [Column("Pk_Module", TypeName = "bigint")]
        [Comment("主鍵")]
        public long Pk_Module { get; set; }

        /// <summary>
        /// 選單分類主鍵
        /// </summary>
        [Column("FK_ModuleClass", TypeName = "bigint")]
        [Comment("選單分類主鍵")]
        public long FK_ModuleClass { get; set; }

        /// <summary>
        /// 作業名稱
        /// </summary>
        [Column("Module_Name", TypeName = "nvarchar(30)")]
        [Comment("作業名稱")]
        public string Module_Name { get; set; }

        /// <summary>
        /// 作業路徑
        /// </summary>
        [Column("Module_Route", TypeName = "nvarchar(50)")]
        [Comment("作業路徑")]
        public string Module_Route { get; set; }

        /// <summary>
        /// 作業識別碼
        /// </summary>
        [Column("Module_Discern", TypeName = "nvarchar(30)")]
        [Comment("作業識別碼")]
        public string Module_Discern { get; set; }

        /// <summary>
        /// 作業外部連結
        /// </summary>
        [Column("Module_outLink", TypeName = "nvarchar(200)")]
        [Comment("作業外部連結：點擊系統左側選單時，會直接跳轉外部連結")]
        public string? Module_outLink { get; set; }

        /// <summary>
        /// 有效日期起
        /// </summary>
        [Column("Module_StartDate", TypeName = "datetime")]
        [Comment("有效日期起")]
        public DateTime Module_StartDate { get; set; }

        /// <summary>
        /// 有效日期迄
        /// </summary>
        [Column("Module_EndDate", TypeName = "datetime")]
        [Comment("有效日期迄")]
        public DateTime Module_EndDate { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [Column("Module_order", TypeName = "decimal(9,0)")]
        [Comment("排序(升冪)")]
        public decimal Module_order { get; set; }

        /// <summary>
        /// 狀態
        /// </summary>
        [Column("Module_State", TypeName = "nvarchar(1)")]
        [Comment("狀態：「0:停用，1:啟用」")]
        public string Module_State { get; set; }

        /// <summary>
        /// 建立者ID
        /// </summary>
        [Column("Module_CreateId", TypeName = "nvarchar(50)")]
        [Comment("建立者ID")]
        public string Module_CreateId { get; set; }

        /// <summary>
        /// 建檔日期
        /// </summary>
        [Column("Module_CreateDate", TypeName = "datetime")]
        [Comment("建檔日期")]
        public DateTime Module_CreateDate { get; set; }

        /// <summary>
        /// 建立者IP
        /// </summary>
        [Column("Module_CreateIp", TypeName = "nvarchar(30)")]
        [Comment("建立者IP")]
        public string Module_CreateIp { get; set; }

        /// <summary>
        /// 異動者ID
        /// </summary>
        [Column("Module_EditId", TypeName = "nvarchar(50)")]
        [Comment("異動者ID")]
        public string Module_EditId { get; set; }

        /// <summary>
        /// 異動日期
        /// </summary>
        [Column("Module_EditDate", TypeName = "datetime")]
        [Comment("異動日期")]
        public DateTime Module_EditDate { get; set; }

        /// <summary>
        /// 異動者IP
        /// </summary>
        [Column("Module_EditIp", TypeName = "nvarchar(30)")]
        [Comment("異動者IP")]
        public string Module_EditIp { get; set; }
    }
}