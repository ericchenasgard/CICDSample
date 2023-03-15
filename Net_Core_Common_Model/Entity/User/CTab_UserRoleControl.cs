using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Net_Core_Common_Model.Entity.User
{
    /// <summary>
    /// 使用者角色作業控制項權限
    /// </summary>
    [Table("User_Role_Control")]
    [Comment("使用者角色作業控制項權限")]
    public class CTab_UserRoleControl
    {
        /// <summary>
        /// 使用者角色主鍵
        /// </summary>
        [Column("Cfk_Role", TypeName = "bigint")]
        [Comment("角色主鍵")]
        public long Cfk_Role { get; set; }

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