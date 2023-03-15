namespace Net_Core_Common_Model.Dto.Login
{
    /// <summary>
    /// 登入-畫面欄位
    /// </summary>
    public class CIn_Login_PageData
    {
        /// <summary>
        /// 使用者帳號
        /// </summary>
        public string UserAccount { get; set; }

        /// <summary>
        /// 使用者密碼
        /// </summary>
        public string UserPassword { get; set; }
    }
}