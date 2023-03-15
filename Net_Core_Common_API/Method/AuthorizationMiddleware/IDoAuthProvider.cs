namespace Net_Core_Common_API.Method.DoAuth
{
    public interface IDoAuthProvider
    {
        /// <summary>
        /// 判斷該帳號/角色是否有呼叫API的權限
        /// </summary>
        /// <param name="sAccount">使用者帳號</param>
        /// <param name="sRole">使用者角色</param>
        /// <returns>查詢結果/回傳訊息</returns>
        public (bool, string) fnDoAuth(string sAccount, string sRole);
    }
}
