using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Net_Core_Common_Model.Entity.User
{
    /// <summary>
    /// 使用者角色成員
    /// </summary>
    [Table("User_Role_Member")]
    [Comment("使用者角色成員")]
    public class CTab_UserRoleMember
    {
        /// <summary>
        /// 使用者角色主鍵
        /// </summary>
        [Column("Cfk_Role", TypeName = "bigint")]
        [Comment("使用者角色主鍵")]
        public long Cfk_Role { get; set; }

        /// <summary>
        /// 使用者主鍵
        /// </summary>
        [Column("Cfk_Info", TypeName = "bigint")]
        [Comment("使用者主鍵")]
        public long Cfk_Info { get; set; }
    }
}