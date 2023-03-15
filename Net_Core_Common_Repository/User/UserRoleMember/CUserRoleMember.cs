using Net_Core_Common_Model.Dto;
using Net_Core_Common_Model.Dto.User.UserRoleMember;
using Net_Core_Common_Model.Entity;
using Net_Core_Common_Model.Entity.User;
using System.Linq;

namespace Net_Core_Common_Repository.User.UserRoleMember
{
    /// <summary>
    /// 使用者角色成員
    /// </summary>
    public class CUserRoleMember : IUserRoleMember
    {
        private readonly CEntityContext _oCEntityContext;

        #region 建構式
        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="oCEntityContext">資料庫實體</param>
        public CUserRoleMember(CEntityContext oCEntityContext)
        {
            this._oCEntityContext = oCEntityContext;
        }
        #endregion

        #region 新增資料
        /// <summary>
        /// 新增資料
        /// </summary>
        /// <param name="oCIn_UserRoleMember_PageData">頁面資料</param>
        /// <param name="oCOut_UserInfo">使用者資訊</param>
        /// <returns>新增的資料/成功執行的筆數/回傳訊息</returns>
        public (CTab_UserRoleMember, int, string) fnInsert(CIn_UserRoleMember_PageData oCIn_UserRoleMember_PageData, COut_UserInfo oCOut_UserInfo)
        {
            // 成功執行的筆數
            int iRT = 0;

            // 新增的資料
            CTab_UserRoleMember oCTab_UserRoleMember = new CTab_UserRoleMember();

            // 回傳訊息
            string sMessage = "";

            try
            {
                // 組合新增的資料
                this._oCEntityContext.CTab_UserRoleMember.Add(oCTab_UserRoleMember).CurrentValues.SetValues(oCIn_UserRoleMember_PageData);

                // 執行新增
                iRT = this._oCEntityContext.SaveChanges();
            }
            catch (Exception ex)
            {
                sMessage = ex.Message;
            }

            return (oCTab_UserRoleMember, iRT, sMessage);
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
                var vDelete = (from ta in this._oCEntityContext.CTab_UserRoleMember
                               where ta.Cfk_Role == lPk
                               select ta).SingleOrDefault();

                if (vDelete != null)
                {
                    // 可刪除多筆
                    this._oCEntityContext.CTab_UserRoleMember.RemoveRange(vDelete);

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
        /// <param name="oCIn_UserRoleMember_Search">查詢條件</param>
        /// <returns>查詢結果/回傳訊息</returns>
        public (List<CTab_UserRoleMember>, string) fnGet(CIn_UserRoleMember_Search oCIn_UserRoleMember_Search)
        {
            // 查詢結果
            List<CTab_UserRoleMember> lCTab_UserRoleMember = new List<CTab_UserRoleMember>();

            // 回傳訊息
            string sMessage = "";

            try
            {
                // 查詢全部
                var vRT = from ta in this._oCEntityContext.CTab_UserRoleMember
                          select ta;

                #region 查詢條件
                if (oCIn_UserRoleMember_Search.Cfk_Role != null)
                {
                    vRT = vRT.Where(x => x.Cfk_Role == oCIn_UserRoleMember_Search.Cfk_Role);
                }

                if (oCIn_UserRoleMember_Search.Cfk_Info != null)
                {
                    vRT = vRT.Where(x => x.Cfk_Info == oCIn_UserRoleMember_Search.Cfk_Info);
                }
                #endregion

                lCTab_UserRoleMember = vRT.ToList();
            }
            catch (Exception ex)
            {
                sMessage = ex.Message;
            }

            return (lCTab_UserRoleMember, sMessage);
        }
        #endregion

        #region 取得資料 (包含：角色名稱&使用者名稱)
        /// <summary>
        /// 取得資料 (包含：角色名稱&使用者名稱)
        /// </summary>
        /// <param name="oCIn_UserRoleMember_Search">查詢條件</param>
        /// <returns>查詢結果/回傳訊息</returns>
        public (List<COut_UserRoleInfoName>, string) fnGetName(CIn_UserRoleMember_Search oCIn_UserRoleMember_Search)
        {
            // 查詢結果
            List<COut_UserRoleInfoName> lCOut_UserRoleInfoName = new List<COut_UserRoleInfoName>();

            // 回傳訊息
            string sMessage = "";

            try
            {
                // 查詢全部
                var vRT = from ta in this._oCEntityContext.CTab_UserRoleMember
                          join ur in this._oCEntityContext.CTab_UserRole on ta.Cfk_Role equals ur.Pk_Role
                          join ui in this._oCEntityContext.CTab_UserInfo on ta.Cfk_Info equals ui.Pk_Info
                          select new
                          {
                              ta.Cfk_Role,
                              ur.Role_Name,
                              ur.Role_StartDate,
                              ur.Role_EndDate,
                              ta.Cfk_Info,
                              ui.Info_Account,
                              ui.Info_Name
                          };

                #region 查詢條件
                if (oCIn_UserRoleMember_Search.Cfk_Info != null)
                {
                    vRT = vRT.Where(x => DateTime.Now >= x.Role_StartDate && DateTime.Now <= x.Role_EndDate);
                }
                #endregion

                #region 轉成COut_UserRoleInfoName(使用者角色名稱&使用者名稱)
                foreach (var vRoleInfoName in vRT)
                {
                    COut_UserRoleInfoName oCOut_UserRoleInfoName = new COut_UserRoleInfoName();

                    oCOut_UserRoleInfoName.Cfk_Role = vRoleInfoName.Cfk_Role;
                    oCOut_UserRoleInfoName.Role_Name = vRoleInfoName.Role_Name;
                    oCOut_UserRoleInfoName.Role_StartDate = vRoleInfoName.Role_StartDate;
                    oCOut_UserRoleInfoName.Role_EndDate = vRoleInfoName.Role_EndDate;
                    oCOut_UserRoleInfoName.Cfk_Info = vRoleInfoName.Cfk_Info;
                    oCOut_UserRoleInfoName.Info_Account = vRoleInfoName.Info_Account;
                    oCOut_UserRoleInfoName.Info_Name = vRoleInfoName.Info_Name;

                    lCOut_UserRoleInfoName.Add(oCOut_UserRoleInfoName);
                }
                #endregion
            }
            catch (Exception ex)
            {
                sMessage = ex.Message;
            }

            return (lCOut_UserRoleInfoName, sMessage);
        }
        #endregion
    }
}