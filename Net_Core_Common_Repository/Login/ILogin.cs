using Net_Core_Common_Model.Dto.Login;

namespace Net_Core_Common_Repository.Login
{
    /// <summary>
    /// 登入
    /// </summary>
    public interface ILogin
    {
        /// <summary>
        /// 判斷帳號是否被鎖定
        /// </summary>
        /// <param name="oCIn_Login_Search">查詢條件</param>
        /// <returns>是否鎖定(true/false)</returns>
        public bool fnCheckLockAccount(CIn_Login_Search oCIn_Login_Search);

        /// <summary>
        /// 判斷帳號/密碼是否有效
        /// </summary>
        /// <param name="oCIn_Login_Search">查詢條件</param>
        /// <returns>是否有效(true/false)</returns>
        public bool fnCheckEffectiveUser(CIn_Login_Search oCIn_Login_Search);
    }
}
