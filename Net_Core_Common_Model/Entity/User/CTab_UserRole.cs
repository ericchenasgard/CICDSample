using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Net_Core_Common_Model.Entity.User
{
    /// <summary>
    /// 使用者角色設定
    /// </summary>
    [Table("User_Role")]
    [Comment("使用者角色設定")]
    public class CTab_UserRole
    {
        /// <summary>
        /// 主鍵
        /// </summary>
        [Key]
        [Column("Pk_Role", TypeName = "bigint")]
        [Comment("主鍵")]
        public long Pk_Role { get; set; }

        /// <summary>
        /// 角色名稱
        /// </summary>
        [Column("Role_Name", TypeName = "nvarchar(30)")]
        [Comment("角色名稱")]
        public string Role_Name { get; set; }

        /// <summary>
        /// 有效日期起
        /// </summary>
        [Column("Role_StartDate", TypeName = "datetime")]
        [Comment("有效日期起")]
        public DateTime Role_StartDate { get; set; }

        /// <summary>
        /// 有效日期迄
        /// </summary>
        [Column("Role_EndDate", TypeName = "datetime")]
        [Comment("有效日期迄")]
        public DateTime Role_EndDate { get; set; }

        /// <summary>
        /// 狀態
        /// </summary>
        [Column("Role_State", TypeName = "nvarchar(1)")]
        [Comment("狀態：「0:停用，1:啟用」")]
        public string Role_State { get; set; }

        /// <summary>
        /// 建立者ID
        /// </summary>
        [Column("Role_CreateId", TypeName = "nvarchar(50)")]
        [Comment("建立者ID")]
        public string Role_CreateId { get; set; }

        /// <summary>
        /// 建檔日期
        /// </summary>
        [Column("Role_CreateDate", TypeName = "datetime")]
        [Comment("建檔日期")]
        public DateTime Role_CreateDate { get; set; }

        /// <summary>
        /// 建立者IP
        /// </summary>
        [Column("Role_CreateIp", TypeName = "nvarchar(30)")]
        [Comment("建立者IP")]
        public string Role_CreateIp { get; set; }

        /// <summary>
        /// 異動者ID
        /// </summary>
        [Column("Role_EditId", TypeName = "nvarchar(50)")]
        [Comment("異動者ID")]
        public string Role_EditId { get; set; }

        /// <summary>
        /// 異動日期
        /// </summary>
        [Column("Role_EditDate", TypeName = "datetime")]
        [Comment("異動日期")]
        public DateTime Role_EditDate { get; set; }

        /// <summary>
        /// 異動者IP
        /// </summary>
        [Column("Role_EditIp", TypeName = "nvarchar(30)")]
        [Comment("異動者IP")]
        public string Role_EditIp { get; set; }
    }
}