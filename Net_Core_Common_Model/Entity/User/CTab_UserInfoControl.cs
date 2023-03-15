using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Net_Core_Common_Model.Entity.User
{
    /// <summary>
    /// 使用者作業控制項權限
    /// </summary>
    [Table("User_Info_Control")]
    [DisplayName("使用者作業控制項權限")]
    public class CTab_UserInfoControl
    {
        /// <summary>
        /// 使用者主鍵
        /// </summary>
        [Column("Cfk_Info", TypeName = "bigint")]
        [Comment("使用者主鍵")]
        public long Cfk_Info { get; set; }

        /// <summary>
        /// 選單作業主鍵
        /// </summary>
        [Column("Cfk_Module", TypeName = "bigint")]
        [Comment("選單作業主鍵")]
        public long Cfk_Module { get; set; }

        /// <summary>
        /// 選單作業控制項
        /// </summary>
        [Column("Cfk_ModuleControl", TypeName = "nvarchar(50)")]
        [Comment("選單作業控制項")]
        public string Cfk_ModuleControl { get; set; }
    }
}
