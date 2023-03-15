using Net_Core_Common_Model.Dto;
using Net_Core_Common_Model.Dto.User.UserInfoAuth;
using Net_Core_Common_Model.Entity;
using Net_Core_Common_Model.Entity.User;

namespace Net_Core_Common_Repository.User.UserInfoAuth
{
    /// <summary>
    /// 使用者作業權限
    /// </summary>
    public class CUserInfoAuth : IUserInfoAuth
    {
        private readonly CEntityContext _oCEntityContext;

        #region 建構式
        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="oCEntityContext">資料庫實體</param>
        public CUserInfoAuth(CEntityContext oCEntityContext)
        {
            this._oCEntityContext = oCEntityContext;
        }
        #endregion

        #region 新增資料
        /// <summary>
        /// 新增資料
        /// </summary>
        /// <param name="oCIn_UserInfoAuth_PageData">頁面資料</param>
        /// <param name="oCOut_UserInfo">使用者資訊</param>
        /// <returns>新增的資料/成功執行的筆數/回傳訊息</returns>
        public (CTab_UserInfoAuth, int, string) fnInsert(CIn_UserInfoAuth_PageData oCIn_UserInfoAuth_PageData, COut_UserInfo oCOut_UserInfo)
        {
            // 成功執行的筆數
            int iRT = 0;

            // 新增的資料
            CTab_UserInfoAuth oCTab_UserInfoAuth = new CTab_UserInfoAuth();

            // 回傳訊息
            string sMessage = "";

            try
            {
                // 組合新增的資料
                this._oCEntityContext.CTab_UserInfoAuth.Add(oCTab_UserInfoAuth).CurrentValues.SetValues(oCIn_UserInfoAuth_PageData);

                // 執行新增
                iRT = this._oCEntityContext.SaveChanges();
            }
            catch (Exception ex)
            {
                sMessage = ex.Message;
            }

            return (oCTab_UserInfoAuth, iRT, sMessage);
        }
        #endregion

        #region 刪除資料
        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <param name="lInfoPk">使用者PK</param>
        /// <param name="lModulePk">選單作業PK</param>
        /// <returns>成功執行的筆數/回傳訊息</returns>
        public (int, string) fnDelete(long lInfoPk, long lModulePk)
        {
            // 成功執行的筆數
            int iRT = 0;

            // 回傳訊息
            string sMessage = "";

            try
            {
                // 取得要刪除的那筆資料
                var vDelete = (from ta in this._oCEntityContext.CTab_UserInfoAuth
                               where ta.Cfk_Info == lInfoPk && ta.Cfk_Module == lModulePk
                               select ta).SingleOrDefault();

                if (vDelete != null)
                {
                    // 可刪除多筆
                    this._oCEntityContext.CTab_UserInfoAuth.RemoveRange(vDelete);

                    // 執行刪除
                    iRT = this._oCEntityContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                sMessage = ex.Message;
            }

            return (iRT, sMessage);
        }
        #endregion

        #region 取得資料
        /// <summary>
        /// 取得資料-依查詢條件做查詢
        /// </summary>
        /// <param name="oCIn_UserInfoAuth_Search">查詢條件</param>
        /// <returns>查詢結果/回傳訊息</returns>
        public (List<CTab_UserInfoAuth>, string) fnGet(CIn_UserInfoAuth_Search oCIn_UserInfoAuth_Search)
        {
            // 查詢結果
            List<CTab_UserInfoAuth> lCTab_UserInfoAuth = new List<CTab_UserInfoAuth>();

            // 回傳訊息
            string sMessage = "";

            try
            {
                // 查詢全部
                var vRT = from ta in this._oCEntityContext.CTab_UserInfoAuth
                          select ta;

                #region 查詢條件
                if (oCIn_UserInfoAuth_Search.Cfk_Info != null)
                {
                    vRT = vRT.Where(x => x.Cfk_Info == oCIn_UserInfoAuth_Search.Cfk_Info);
                }

                if (oCIn_UserInfoAuth_Search.Cfk_Module != null)
                {
                    vRT = vRT.Where(x => x.Cfk_Module == oCIn_UserInfoAuth_Search.Cfk_Module);
                }
                #endregion

                lCTab_UserInfoAuth = vRT.ToList();
            }
            catch (Exception ex)
            {
                sMessage = ex.Message;
            }

            return (lCTab_UserInfoAuth, sMessage);
        }
        #endregion
    }
}