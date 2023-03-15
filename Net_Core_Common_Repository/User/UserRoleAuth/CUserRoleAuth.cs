using Net_Core_Common_Model.Dto;
using Net_Core_Common_Model.Dto.User.UserRoleAuth;
using Net_Core_Common_Model.Entity;
using Net_Core_Common_Model.Entity.User;

namespace Net_Core_Common_Repository.User.UserRoleAuth
{
    /// <summary>
    /// 使用者角色作業權限
    /// </summary>
    public class CUserRoleAuth : IUserRoleAuth
    {
        private readonly CEntityContext _oCEntityContext;

        #region 建構式
        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="oCEntityContext">資料庫實體</param>
        public CUserRoleAuth(CEntityContext oCEntityContext)
        {
            this._oCEntityContext = oCEntityContext;
        }
        #endregion

        #region 新增資料
        /// <summary>
        /// 新增資料
        /// </summary>
        /// <param name="oCIn_UserRoleAuth_PageData">頁面資料</param>
        /// <param name="oCOut_UserInfo">使用者資訊</param>
        /// <returns>新增的資料/成功執行的筆數/回傳訊息</returns>
        public (CTab_UserRoleAuth, int, string) fnInsert(CIn_UserRoleAuth_PageData oCIn_UserRoleAuth_PageData, COut_UserInfo oCOut_UserInfo)
        {
            // 成功執行的筆數
            int iRT = 0;

            // 新增的資料
            CTab_UserRoleAuth oCTab_UserRoleAuth = new CTab_UserRoleAuth();

            // 回傳訊息
            string sMessage = "";

            try
            {
                // 組合新增的資料
                this._oCEntityContext.CTab_UserRoleAuth.Add(oCTab_UserRoleAuth).CurrentValues.SetValues(oCIn_UserRoleAuth_PageData);

                // 執行新增
                iRT = this._oCEntityContext.SaveChanges();
            }
            catch (Exception ex)
            {
                sMessage = ex.Message;
            }

            return (oCTab_UserRoleAuth, iRT, sMessage);
        }
        #endregion

        #region 刪除資料
        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <param name="lPk">資料PK</param>
        /// <returns>成功執行的筆數/回傳訊息</returns>
        public (int, string) fnDelete(long lPk)
        {
            // 成功執行的筆數
            int iRT = 0;

            // 回傳訊息
            string sMessage = "";

            try
            {
                // 取得要刪除的那筆資料
                var vDelete = (from ta in this._oCEntityContext.CTab_UserRoleAuth
                               where ta.Cfk_Role == lPk
                               select ta).SingleOrDefault();

                if (vDelete != null)
                {
                    // 可刪除多筆
                    this._oCEntityContext.CTab_UserRoleAuth.RemoveRange(vDelete);

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
        /// <param name="oCIn_UserRoleAuth_Search">查詢條件</param>
        /// <returns>查詢結果/回傳訊息</returns>
        public (List<CTab_UserRoleAuth>, string) fnGet(CIn_UserRoleAuth_Search oCIn_UserRoleAuth_Search)
        {
            // 查詢結果
            List<CTab_UserRoleAuth> lCTab_UserRoleAuth = new List<CTab_UserRoleAuth>();

            // 回傳訊息
            string sMessage = "";

            try
            {
                // 查詢全部
                var vRT = from ta in this._oCEntityContext.CTab_UserRoleAuth
                          select ta;

                #region 查詢條件
                if (oCIn_UserRoleAuth_Search.Cfk_Role != null)
                {
                    vRT = vRT.Where(x => x.Cfk_Role == oCIn_UserRoleAuth_Search.Cfk_Role);
                }

                if (oCIn_UserRoleAuth_Search.Cfk_Module != null)
                {
                    vRT = vRT.Where(x => x.Cfk_Module == oCIn_UserRoleAuth_Search.Cfk_Module);
                }
                #endregion

                lCTab_UserRoleAuth = vRT.ToList();
            }
            catch (Exception ex)
            {
                sMessage = ex.Message;
            }

            return (lCTab_UserRoleAuth, sMessage);
        }
        #endregion
    }
}