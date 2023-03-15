using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Net_Core_Common_Model.Entity.Sys
{
    /// <summary>
    /// 選單作業控制項
    /// </summary>
    [Table("Sys_Module_Control")]
    [Comment("選單作業控制項")]
    public class CTab_SysModuleControl
    {
        /// <summary>
        /// 選單作業主鍵
        /// </summary>
        [Column("Cfk_Module", TypeName = "bigint")]
        [Comment("選單作業主鍵")]
        public long Cfk_Module { get; set; }

        /// <summary>
        /// 選單作業控制項-識別碼
        /// </summary>
        [Column("ModCon_Code", TypeName = "nvarchar(50)")]
        [Comment("選單作業控制項-識別碼")]
        public string ModCon_Code { get; set; }

        /// <summary>
        /// 選單作業控制項-名稱
        /// </summary>
        [Column("ModCon_Name", TypeName = "nvarchar(50)")]
        [Comment("選單作業控制項-名稱")]
        public string ModCon_Name { get; set; }
    }
}