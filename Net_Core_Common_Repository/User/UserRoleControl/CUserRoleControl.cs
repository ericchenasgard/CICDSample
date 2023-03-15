using Net_Core_Common_Model.Dto;
using Net_Core_Common_Model.Dto.User.UserRoleControl;
using Net_Core_Common_Model.Entity;
using Net_Core_Common_Model.Entity.User;

namespace Net_Core_Common_Repository.User.UserRoleControl
{
    /// <summary>
    /// 使用者角色作業控制項權限
    /// </summary>
    public class CUserRoleControl : IUserRoleControl
    {
        private readonly CEntityContext _oCEntityContext;

        #region 建構式
        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="oCEntityContext">資料庫實體</param>
        public CUserRoleControl(CEntityContext oCEntityContext)
        {
            this._oCEntityContext = oCEntityContext;
        }
        #endregion

        #region 新增資料
        /// <summary>
        /// 新增資料
        /// </summary>
        /// <param name="oCIn_UserRoleControl_PageData">頁面資料</param>
        /// <param name="oCOut_UserInfo">使用者資訊</param>
        /// <returns>新增的資料/成功執行的筆數/回傳訊息</returns>
        public (CTab_UserRoleControl, int, string) fnInsert(CIn_UserRoleControl_PageData oCIn_UserRoleControl_PageData, COut_UserInfo oCOut_UserInfo)
        {
            // 成功執行的筆數
            int iRT = 0;

            // 新增的資料
            CTab_UserRoleControl oCTab_UserRoleControl = new CTab_UserRoleControl();

            // 回傳訊息
            string sMessage = "";

            try
            {
                // 組合新增的資料
                this._oCEntityContext.CTab_UserRoleControl.Add(oCTab_UserRoleControl).CurrentValues.SetValues(oCIn_UserRoleControl_PageData);

                // 執行新增
                iRT = this._oCEntityContext.SaveChanges();
            }
            catch (Exception ex)
            {
                sMessage = ex.Message;
            }

            return (oCTab_UserRoleControl, iRT, sMessage);
        }
        #endregion

        #region 刪除資料
        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <param name="lRolePk">使用者PK</param>
        /// <param name="lModulePk">選單作業PK</param>
        /// <returns>成功執行的筆數/回傳訊息</returns>
        public (int, string) fnDeletef(long lRolePk, long lModulePk)
        {
            // 成功執行的筆數
            int iRT = 0;

            // 回傳訊息
            string sMessage = "";

            try
            {
                // 取得要刪除的那筆資料
                var vDelete = (from ta in this._oCEntityContext.CTab_UserRoleControl
                               where ta.Cfk_Role == lRolePk && ta.Cfk_Module == lModulePk
                               select ta).SingleOrDefault();

                if (vDelete != null)
                {
                    // 可刪除多筆
                    this._oCEntityContext.CTab_UserRoleControl.RemoveRange(vDelete);

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
        /// <param name="oCIn_UserRoleControl_Search">查詢條件</param>
        /// <returns>查詢結果/回傳訊息</returns>
        public (List<CTab_UserRoleControl>, string) fnGet(CIn_UserRoleControl_Search oCIn_UserRoleControl_Search)
        {
            // 查詢結果
            List<CTab_UserRoleControl> lCTab_UserRoleControl = new List<CTab_UserRoleControl>();

            // 回傳訊息
            string sMessage = "";

            try
            {
                // 查詢全部
                var vRT = from ta in this._oCEntityContext.CTab_UserRoleControl
                          select ta;

                #region 查詢條件
                if (oCIn_UserRoleControl_Search.Cfk_Role != null)
                {
                    vRT = vRT.Where(x => x.Cfk_Role == oCIn_UserRoleControl_Search.Cfk_Role);
                }

                if (oCIn_UserRoleControl_Search.Cfk_Module != null)
                {
                    vRT = vRT.Where(x => x.Cfk_Module == oCIn_UserRoleControl_Search.Cfk_Module);
                }

                if (oCIn_UserRoleControl_Search.Cfk_ModCon_Code != null)
                {
                    vRT = vRT.Where(x => x.Cfk_ModuleControl.Contains(oCIn_UserRoleControl_Search.Cfk_ModCon_Code));
                }
                #endregion

                lCTab_UserRoleControl = vRT.ToList();
            }
            catch (Exception ex)
            {
                sMessage = ex.Message;
            }

            return (lCTab_UserRoleControl, sMessage);
        }
        #endregion

        #region 取得資料 (包含：使用者角色&模組代號&控制項代號)
        /// <summary>
        /// 取得資料 (包含：使用者角色&模組代號&控制項代號)
        /// </summary>
        /// <param name="sRole">登入帳號</param>
        /// <param name="sModule">呼叫API：模組代號</param>
        /// <param name="sControl">呼叫API：控制項代號</param>
        /// <returns>查詢結果/回傳訊息</returns>
        public (bool, string) fnGetName(string sRole, string sModule, string sControl)
        {
            // 查詢結果
            bool bResult = false;

            // 回傳訊息
            string sMessage = "";

            try
            {
                // 查詢全部
                var vRT = from urc in this._oCEntityContext.CTab_UserRoleControl
                          join ur in this._oCEntityContext.CTab_UserRole on urc.Cfk_Role equals ur.Pk_Role
                          join sm in this._oCEntityContext.CTab_SysModule on urc.Cfk_Module equals sm.Pk_Module
                          select new
                          {
                              urc.Cfk_Role,
                              ur.Role_Name,
                              ur.Role_State,
                              ur.Role_StartDate,
                              ur.Role_EndDate,
                              urc.Cfk_Module,
                              sm.Module_Name,
                              sm.Module_Route,
                              sm.Module_Discern,
                              sm.Module_State,
                              sm.Module_StartDate,
                              sm.Module_EndDate,
                              urc.Cfk_ModuleControl
                          };

                #region 查詢條件
                if (vRT.Count() > 0)
                {
                    vRT = vRT.Where(x => x.Role_Name == sRole && x.Role_State == "1" && DateTime.Now >= x.Role_StartDate && DateTime.Now <= x.Role_EndDate);
                    vRT = vRT.Where(y => y.Module_Discern == sModule && y.Module_State == "1" && DateTime.Now >= y.Module_StartDate && DateTime.Now <= y.Module_EndDate);
                    vRT = vRT.Where(z => z.Cfk_ModuleControl == sControl);
                }
                #endregion

                if (vRT.Count() > 0)
                {
                    bResult = true;
                }
            }
            catch (Exception ex)
            {
                sMessage = ex.Message;
            }

            return (bResult, sMessage);
        }
        #endregion
    }
}