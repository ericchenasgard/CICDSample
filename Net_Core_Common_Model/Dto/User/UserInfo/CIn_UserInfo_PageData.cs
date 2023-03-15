namespace Net_Core_Common_Model.Dto.User.UserInfo
{
    /// <summary>
    /// 使用者資訊-畫面欄位
    /// </summary>
    public class CIn_UserInfo_PageData
    {
        /// <summary>
        /// 帳號類別：「0:獨立，1:AD」
        /// </summary>
        public string Info_IsAd { get; set; }

        /// <summary>
        /// 系統管理者
        /// </summary>
        public bool? Info_IsAdmin { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Info_Name { get; set; }

        /// <summary>
        /// 信箱
        /// </summary>
        public string Info_Email { get; set; }

        /// <summary>
        /// 登入帳號
        /// </summary>
        public string Info_Account { get; set; }

        /// <summary>
        /// AD帳號
        /// </summary>
        public string? Info_AccountAd { get; set; }

        /// <summary>
        /// 密碼
        /// </summary>
        public string? Info_Password { get; set; }

        /// <summary>
        /// 更換密碼日期
        /// </summary>
        public DateTime? Info_UpdatePwDate { get; set; }

        /// <summary>
        /// 帳號鎖定
        /// </summary>
        public bool? Info_Lock { get; set; }

        /// <summary>
        /// 帳號鎖定時間
        /// </summary>
        public DateTime? Info_LockDate { get; set; }

        /// <summary>
        /// 帳號鎖定IP
        /// </summary>
        public string? Info_LockIp { get; set; }

        /// <summary>
        /// 狀態：「0:停用，1:啟用」
        /// </summary>
        public string Info_State { get; set; }

        /// <summary>
        /// 停用原因-選項
        /// </summary>
        public string? Info_Disable { get; set; }

        /// <summary>
        /// 停用原因：[選項：其他]的值
        /// </summary>
        public string? Info_DisableReason { get; set; }
    }
}