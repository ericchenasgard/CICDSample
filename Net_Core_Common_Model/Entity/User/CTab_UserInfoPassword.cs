using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Net_Core_Common_Model.Entity.User
{
    /// <summary>
    /// 使用者密碼變更記錄
    /// </summary>
    [Table("User_Info_Password")]
    [Comment("使用者密碼變更記錄")]
    public class CTab_UserInfoPassword
    {
        /// <summary>
        /// 使用者主鍵
        /// </summary>
        [Column("Cfk_Info", TypeName = "bigint")]
        [Comment("使用者主鍵")]
        public long Cfk_Info { get; set; }

        /// <summary>
        /// 流水號
        /// </summary>
        [Column("Ck_InfoPas_Sn", TypeName = "bigint")]
        [Comment("流水號：記錄變更的序號")]
        public long Ck_InfoPas_Sn { get; set; }

        /// <summary>
        /// 新密碼
        /// </summary>
        [Column("InfoPas_Password", TypeName = "nvarchar(100)")]
        [Comment("新密碼")]
        public string InfoPas_Password { get; set; }

        /// <summary>
        /// 建立者ID
        /// </summary>
        [Column("InfoPas_CreateId", TypeName = "nvarchar(50)")]
        [Comment("建立者ID")]
        public string InfoPas_CreateId { get; set; }

        /// <summary>
        /// 建檔日期
        /// </summary>
        [Column("InfoPas_CreateDate", TypeName = "datetime")]
        [Comment("建檔日期")]
        public DateTime InfoPas_CreateDate { get; set; }

        /// <summary>
        /// 建立者IP
        /// </summary>
        [Column("InfoPas_CreateIp", TypeName = "nvarchar(30)")]
        [Comment("建立者IP")]
        public string InfoPas_CreateIp { get; set; }
    }
}
