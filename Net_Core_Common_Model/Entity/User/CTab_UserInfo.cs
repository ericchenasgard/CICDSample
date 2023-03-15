using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Net_Core_Common_Model.Entity.User
{
    /// <summary>
    /// 使用者資訊
    /// </summary>
    [Table("User_Info")]
    [Comment("使用者資訊")]
    public class CTab_UserInfo
    {
        /// <summary>
        /// 主鍵
        /// </summary>
        [Key]
        [Column("Pk_Info", TypeName = "bigint")]
        [Comment("主鍵")]
        public long Pk_Info { get; set; }

        /// <summary>
        /// 帳號類別
        /// </summary>
        [Column("Info_IsAd", TypeName = "nvarchar(1)")]
        [Comment("帳號類別：「0:獨立，1:AD」")]
        public string Info_IsAd { get; set; }

        /// <summary>
        /// 系統管理者
        /// </summary>
        [Column("Info_IsAdmin", TypeName = "bit")]
        [Comment("系統管理者")]
        public bool? Info_IsAdmin { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Column("Info_Name", TypeName = "nvarchar(30)")]
        [Comment("姓名")]
        public string Info_Name { get; set; }

        /// <summary>
        /// 信箱
        /// </summary>
        [Column("Info_Email", TypeName = "nvarchar(200)")]
        [Comment("信箱")]
        public string Info_Email { get; set; }

        /// <summary>
        /// 登入帳號
        /// </summary>
        [Column("Info_Account", TypeName = "nvarchar(20)")]
        [Comment("登入帳號")]
        public string Info_Account { get; set; }

        /// <summary>
        /// AD帳號
        /// </summary>
        [Column("Info_AccountAd", TypeName = "nvarchar(50)")]
        [Comment("AD帳號")]
        public string? Info_AccountAd { get; set; }

        /// <summary>
        /// 密碼
        /// </summary>
        [Column("Info_Password", TypeName = "nvarchar(200)")]
        [Comment("密碼")]
        public string? Info_Password { get; set; }

        /// <summary>
        /// 更換密碼日期
        /// </summary>
        [Column("Info_UpdatePwDate", TypeName = "datetime")]
        [Comment("更換密碼日期")]
        public DateTime? Info_UpdatePwDate { get; set; }

        /// <summary>
        /// 帳號鎖定
        /// </summary>
        [Column("Info_Lock", TypeName = "bit")]
        [Comment("帳號鎖定")]
        public bool? Info_Lock { get; set; }

        /// <summary>
        /// 帳號鎖定時間
        /// </summary>
        [Column("Info_LockDate", TypeName = "datetime")]
        [Comment("帳號鎖定時間")]
        public DateTime? Info_LockDate { get; set; }

        /// <summary>
        /// 帳號鎖定IP
        /// </summary>
        [Column("Info_LockIp", TypeName = "nvarchar(30)")]
        [Comment("帳號鎖定IP")]
        public string? Info_LockIp { get; set; }

        /// <summary>
        /// 登入錯誤次數
        /// </summary>
        [Column("Info_ErrorCount", TypeName = "decimal(3,0)")]
        [Comment("登入錯誤次數")]
        public decimal Info_ErrorCount { get; set; }

        /// <summary>
        /// 狀態
        /// </summary>
        [Column("Info_State", TypeName = "nvarchar(1)")]
        [Comment("狀態：「0:停用，1:啟用」")]
        public string Info_State { get; set; }

        /// <summary>
        /// 停用原因-選項
        /// </summary>
        [Column("Info_Disable", TypeName = "nvarchar(1)")]
        [Comment("停用原因-選項")]
        public string? Info_Disable { get; set; }

        /// <summary>
        /// 停用原因-其他
        /// </summary>
        [Column("Info_DisableReason", TypeName = "nvarchar(50)")]
        [Comment("停用原因：[選項：其他]的值")]
        public string? Info_DisableReason { get; set; }

        /// <summary>
        /// 有效日期起
        /// </summary>
        [Column("Info_StartDate", TypeName = "datetime")]
        [Comment("有效日期起")]
        public DateTime Info_StartDate { get; set; }

        /// <summary>
        /// 有效日期迄
        /// </summary>
        [Column("Info_EndDate", TypeName = "datetime")]
        [Comment("有效日期迄")]
        public DateTime Info_EndDate { get; set; }

        /// <summary>
        /// 建立者ID
        /// </summary>
        [Column("Info_CreateId", TypeName = "nvarchar(50)")]
        [Comment("建立者ID")]
        public string Info_CreateId { get; set; }

        /// <summary>
        /// 建檔日期
        /// </summary>
        [Column("Info_CreateDate", TypeName = "datetime")]
        [Comment("建檔日期")]
        public DateTime Info_CreateDate { get; set; }

        /// <summary>
        /// 建立者IP
        /// </summary>
        [Column("Info_CreateIp", TypeName = "nvarchar(30)")]
        [Comment("建立者IP")]
        public string Info_CreateIp { get; set; }

        /// <summary>
        /// 異動者ID
        /// </summary>
        [Column("Info_EditId", TypeName = "nvarchar(50)")]
        [Comment("異動者ID")]
        public string Info_EditId { get; set; }

        /// <summary>
        /// 異動日期
        /// </summary>
        [Column("Info_EditDate", TypeName = "datetime")]
        [Comment("異動日期")]
        public DateTime Info_EditDate { get; set; }

        /// <summary>
        /// 異動者IP
        /// </summary>
        [Column("Info_EditIp", TypeName = "nvarchar(30)")]
        [Comment("異動者IP")]
        public string Info_EditIp { get; set; }
    }
}