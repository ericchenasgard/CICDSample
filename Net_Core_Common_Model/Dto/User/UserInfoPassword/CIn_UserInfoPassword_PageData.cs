namespace Net_Core_Common_Model.Dto.User.UserInfoPassword
{
    /// <summary>
    /// 使用者密碼變更記錄-Insert欄位
    /// </summary>
    public class CIn_UserInfoPassword_PageData
    {
        /// <summary>
        /// 使用者主鍵
        /// </summary>
        public long Cfk_Info { get; set; }

        /// <summary>
        /// 流水號：記錄變更的序號
        /// </summary>
        public long Ck_InfoPas_Sn { get; set; }

        /// <summary>
        /// 新密碼
        /// </summary>
        public string InfoPas_Password { get; set; }
    }
}