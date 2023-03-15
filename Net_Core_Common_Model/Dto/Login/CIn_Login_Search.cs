namespace Net_Core_Common_Model.Dto.Login
{
    /// <summary>
    /// 登入-畫面欄位
    /// </summary>
    public class CIn_Login_Search
    {
        /// <summary>
        /// 使用者帳號
        /// </summary>
        public string UserAccount { get; set; }

        /// <summary>
        /// 使用者密碼
        /// </summary>
        public string UserPassword { get; set; }

        /// <summary>
        /// 使用者IP
        /// </summary>
        public string UserIp { get; set; }

        /// <summary>
        /// 解除鎖定時間
        /// </summary>
        public int LiftLockMinute { get; set; }
    }
}