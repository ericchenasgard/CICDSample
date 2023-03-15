using Net_Core_Common_Model.Dto.Login;
using Net_Core_Common_Model.Entity;

namespace Net_Core_Common_Repository.Login
{
    /// <summary>
    /// 選單作業
    /// </summary>
    public class CLogin : ILogin
    {
        private readonly CEntityContext _oCEntityContext;

        #region 建構式
        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="oCEntityContext">資料庫實體</param>
        public CLogin(CEntityContext oCEntityContext)
        {
            this._oCEntityContext = oCEntityContext;
        }
        #endregion

        #region 判斷帳號是否被鎖定
        /// <summary>
        /// 判斷帳號是否被鎖定
        /// </summary>
        /// <param name="oCIn_Login_Search">查詢條件</param>
        /// <returns>是否鎖定(true/false)</returns>
        public bool fnCheckLockAccount(CIn_Login_Search oCIn_Login_Search)
        {
            bool bIsNoLock = true;

            // 查詢全部
            var vRT = from ta in this._oCEntityContext.CTab_UserInfo
                      select ta;

            if (vRT != null)
            {
                var vLocks = vRT.Where(x => (x.Info_Account == oCIn_Login_Search.UserAccount && x.Info_Lock == true)
                            || (x.Info_Account == oCIn_Login_Search.UserAccount && x.Info_Lock == true && x.Info_LockIp == oCIn_Login_Search.UserIp));

                if (vLocks.Count() > 0)
                {
                    double dLockMinute = Convert.ToDouble(oCIn_Login_Search.LiftLockMinute);

                    foreach (var vLock in vLocks)
                    {
                        // 現在時間
                        DateTime dDateTimeNow = DateTime.Now;

                        // 帳號被鎖定的時間
                        DateTime dLockDate = Convert.ToDateTime(vLock.Info_LockDate);

                        if (dDateTimeNow < dLockDate.AddMinutes(dLockMinute))
                        {
                            // 帳號已被鎖定
                            bIsNoLock = false;
                        }
                    }
                }
            }

            return bIsNoLock;
        }
        #endregion

        #region 判斷帳號/密碼是否有效
        /// <summary>
        /// 判斷帳號/密碼是否有效
        /// </summary>
        /// <param name="oCIn_Login_Search">查詢條件</param>
        /// <returns>是否有效(true/false)</returns>
        public bool fnCheckEffectiveUser(CIn_Login_Search oCIn_Login_Search)
        {
            bool bIsEffective = false;

            // 查詢全部
            var vRT = from ta in this._oCEntityContext.CTab_UserInfo
                      select ta;

            if (vRT != null)
            {
                var vEffective = vRT.Where(x => x.Info_State == "1" && x.Info_IsAd == "0"
                                       && (DateTime.Now >= x.Info_StartDate && DateTime.Now <= x.Info_EndDate)
                                       && x.Info_Account == oCIn_Login_Search.UserAccount && x.Info_Password == oCIn_Login_Search.UserPassword);

                if (vEffective.Count() > 0)
                {
                    // 帳號密碼是正確的，為有效帳號
                    bIsEffective = true;
                }
            }

            return bIsEffective;
        }
        #endregion
    }
}
