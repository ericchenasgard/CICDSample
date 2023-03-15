using Net_Core_Common_Model.Dto;
using Net_Core_Common_Model.Dto.User.UserRole;
using Net_Core_Common_Model.Entity;
using Net_Core_Common_Model.Entity.User;

namespace Net_Core_Common_Repository.User.UserRole
{
    /// <summary>
    /// 使用者角色設定
    /// </summary>
    public class CUserRole : IUserRole
    {
        private readonly CEntityContext _oCEntityContext;

        #region 建構式
        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="oCEntityContext">資料庫實體</param>
        public CUserRole(CEntityContext oCEntityContext)
        {
            this._oCEntityContext = oCEntityContext;
        }
        #endregion

        #region 新增資料
        /// <summary>
        /// 新增資料
        /// </summary>
        /// <param name="oCIn_UserRole_PageData">頁面資料</param>
        /// <param name="oCOut_UserInfo">使用者資訊</param>
        /// <returns>新增的資料/成功執行的筆數/回傳訊息</returns>
        public (CTab_UserRole, int, string) fnInsert(CIn_UserRole_PageData oCIn_UserRole_PageData, COut_UserInfo oCOut_UserInfo)
        {
            // 成功執行的筆數
            int iRT = 0;

            // 新增的資料
            CTab_UserRole oCTab_UserRole = new CTab_UserRole();

            // 回傳訊息
            string sMessage = "";

            try
            {
                #region 建立者、異動者資訊
                oCTab_UserRole.Role_CreateId = oCOut_UserInfo.sCreateId;
                oCTab_UserRole.Role_CreateDate = oCOut_UserInfo.dCreateDate;
                oCTab_UserRole.Role_CreateIp = oCOut_UserInfo.sCreateIp;
                oCTab_UserRole.Role_EditId = oCOut_UserInfo.sCreateId;
                oCTab_UserRole.Role_EditDate = oCOut_UserInfo.dCreateDate;
                oCTab_UserRole.Role_EditIp = oCOut_UserInfo.sCreateIp;
                #endregion

                // 組合新增的資料
                this._oCEntityContext.CTab_UserRole.Add(oCTab_UserRole).CurrentValues.SetValues(oCIn_UserRole_PageData);

                // 執行新增
                iRT = this._oCEntityContext.SaveChanges();
            }
            catch (Exception ex)
            {
                sMessage = ex.Message;
            }

            return (oCTab_UserRole, iRT, sMessage);
        }
        #endregion

        #region 更新資料
        /// <summary>
        /// 更新資料
        /// </summary>
        /// <param name="oCIn_UserRole_Update">更新資料</param>
        /// <param name="oCOut_UserInfo">使用者資訊</param>
        /// <returns>更新的資料/成功執行的筆數/回傳訊息</returns>
        public (CTab_UserRole, int, string) fnUpdate(CIn_UserRole_Update oCIn_UserRole_Update, COut_UserInfo oCOut_UserInfo)
        {
            // 成功執行的筆數
            int iRT = 0;

            // 更新的資料
            CTab_UserRole oCTab_UserRole = new CTab_UserRole();

            // 回傳訊息
            string sMessage = "";

            try
            {
                // 取得要更新的那筆資料
                var vUpdate = (from ta in this._oCEntityContext.CTab_UserRole
                               where ta.Pk_Role == oCIn_UserRole_Update.Pk_Role
                               select ta).SingleOrDefault();

                // 定義更新的資料
                if (vUpdate != null)
                {
                    vUpdate.Role_Name = oCIn_UserRole_Update.Role_Name;
                    vUpdate.Role_StartDate = oCIn_UserRole_Update.Role_StartDate;
                    vUpdate.Role_EndDate = oCIn_UserRole_Update.Role_EndDate;
                    vUpdate.Role_State = oCIn_UserRole_Update.Role_State;

                    vUpdate.Role_EditId = oCOut_UserInfo.sCreateId;
                    vUpdate.Role_EditDate = oCOut_UserInfo.dCreateDate;
                    vUpdate.Role_EditIp = oCOut_UserInfo.sCreateIp;

                    // 執行更新
                    iRT = this._oCEntityContext.SaveChanges();

                    if (iRT > 0)
                    {
                        oCTab_UserRole = vUpdate;
                    }
                }
            }
            catch (Exception ex)
            {
                sMessage = ex.Message;
            }

            return (oCTab_UserRole, iRT, sMessage);
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
                var vDelete = (from ta in this._oCEntityContext.CTab_UserRole
                               where ta.Pk_Role == lPk
                               select ta).SingleOrDefault();

                if (vDelete != null)
                {
                    // 可刪除多筆
                    this._oCEntityContext.CTab_UserRole.RemoveRange(vDelete);

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
        /// <param name="oCIn_UserRole_Search">查詢條件</param>
        /// <returns>查詢結果/回傳訊息</returns>
        public (List<CTab_UserRole>, string) fnGet(CIn_UserRole_Search oCIn_UserRole_Search)
        {
            // 查詢結果
            List<CTab_UserRole> lCTab_UserRole = new List<CTab_UserRole>();

            // 回傳訊息
            string sMessage = "";

            try
            {
                // 查詢全部
                var vRT = from ta in this._oCEntityContext.CTab_UserRole
                          select ta;

                #region 查詢條件
                if (oCIn_UserRole_Search.Pk_Role != null)
                {
                    vRT = vRT.Where(x => x.Pk_Role == oCIn_UserRole_Search.Pk_Role);
                }

                if (oCIn_UserRole_Search.Role_Name != null)
                {
                    vRT = vRT.Where(x => x.Role_Name.Contains(oCIn_UserRole_Search.Role_Name));
                }

                if (oCIn_UserRole_Search.Role_State != null)
                {
                    vRT = vRT.Where(x => x.Role_State.Contains(oCIn_UserRole_Search.Role_State));
                }
                #endregion

                lCTab_UserRole = vRT.ToList();
            }
            catch (Exception ex)
            {
                sMessage = ex.Message;
            }

            return (lCTab_UserRole, sMessage);
        }
        #endregion
    }
}