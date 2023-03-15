using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Net_Core_Common_Model.Entity.Sys
{
    /// <summary>
    /// 選單分類
    /// </summary>
    [Table("Sys_Module_Class")]
    [Comment("選單分類")]
    public class CTab_SysModuleClass
    {
        /// <summary>
        /// 主鍵
        /// </summary>
        [Key]
        [Column("Pk_ModuleClass", TypeName = "bigint")]
        [Comment("主鍵")]
        public long Pk_ModuleClass { get; set; }

        /// <summary>
        /// 上層分類
        /// </summary>
        [Column("ModClass_Parent", TypeName = "bigint")]
        [Comment("上層分類(選單分類的主鍵)")]
        public long? ModClass_Parent { get; set; }

        /// <summary>
        /// 分類名稱
        /// </summary>
        [Column("ModClass_Name", TypeName = "nvarchar(30)")]
        [Comment("分類名稱")]
        public string ModClass_Name { get; set; }

        /// <summary>
        /// 排序(升冪)
        /// </summary>
        [Column("ModClass_order", TypeName = "decimal(9,0)")]
        [Comment("排序(升冪)")]
        public decimal ModClass_order { get; set; }

        /// <summary>
        /// 狀態
        /// </summary>
        [Column("ModClass_State", TypeName = "nvarchar(1)")]
        [Comment("狀態：「0:停用，1:啟用」")]
        public string ModClass_State { get; set; }

        /// <summary>
        /// 建立者ID
        /// </summary>
        [Column("ModClass_CreateId", TypeName = "nvarchar(50)")]
        [Comment("建立者ID")]
        public string ModClass_CreateId { get; set; }

        /// <summary>
        /// 建檔日期
        /// </summary>
        [Column("ModClass_CreateDate", TypeName = "datetime")]
        [Comment("建檔日期")]
        public DateTime ModClass_CreateDate { get; set; }

        /// <summary>
        /// 建立者IP
        /// </summary>
        [Column("ModClass_CreateIp", TypeName = "nvarchar(30)")]
        [Comment("建立者IP")]
        public string ModClass_CreateIp { get; set; }

        /// <summary>
        /// 異動者ID
        /// </summary>
        [Column("ModClass_EditId", TypeName = "nvarchar(50)")]
        [Comment("異動者ID")]
        public string ModClass_EditId { get; set; }

        /// <summary>
        /// 異動日期
        /// </summary>
        [Column("ModClass_EditDate", TypeName = "datetime")]
        [Comment("異動日期")]
        public DateTime ModClass_EditDate { get; set; }

        /// <summary>
        /// 異動者IP
        /// </summary>
        [Column("ModClass_EditIp", TypeName = "nvarchar(30)")]
        [Comment("異動者IP")]
        public string ModClass_EditIp { get; set; }
    }
}