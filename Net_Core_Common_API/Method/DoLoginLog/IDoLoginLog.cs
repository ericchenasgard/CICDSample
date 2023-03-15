namespace Net_Core_Common_API.Method.DoLoginLog
{
    /// <summary>
    /// 寫入登入log
    /// </summary>
    public interface IDoLoginLog
    {
        /// <summary>
        /// 寫入登入log
        /// </summary>
        /// <param name="sUserAccount">使用者帳號</param>
        /// <param name="sLoginMessage">登入訊息</param>
        /// <param name="bLoginResult">登入成功與否</param>
        /// <param name="sUserIp">建立者IP</param>
        /// <returns>成功執行的筆數</returns>
        public (int, string) fnDoLoginLog(string sUserAccount, string sLoginMessage, bool bLoginResult, string sUserIp);
    }
}
