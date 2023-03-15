using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Net_Core_Common_Model.Entity.User
{
    /// <summary>
    /// 使用者作業權限
    /// </summary>
    [Table("User_Info_Auth")]
    [Comment("使用者作業權限")]
    public class CTab_UserInfoAuth
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
    }
}
