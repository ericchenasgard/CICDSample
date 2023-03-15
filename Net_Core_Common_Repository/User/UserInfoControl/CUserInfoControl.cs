using Net_Core_Common_Model.Dto;
using Net_Core_Common_Model.Dto.User.UserInfoControl;
using Net_Core_Common_Model.Entity;
using Net_Core_Common_Model.Entity.User;

namespace Net_Core_Common_Repository.User.UserInfoControl
{
    /// <summary>
    /// 使用者作業控制項權限
    /// </summary>
    public class CUserInfoControl : IUserInfoControl
    {
        private readonly CEntityContext _oCEntityContext;

        #region 建構式
        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="oCEntityContext">資料庫實體</param>
        public CUserInfoControl(CEntityContext oCEntityContext)
        {
            this._oCEntityContext = oCEntityContext;
        }
        #endregion

        #region 新增資料
        /// <summary>
        /// 新增資料
        /// </summary>
        /// <param name="oCIn_UserInfoControl_PageData">頁面資料</param>
        /// <param name="oCOut_UserInfo">使用者資訊</param>
        /// <returns>新增的資料/成功執行的筆數/回傳訊息</returns>
        public (CTab_UserInfoControl, int, string) fnInsert(CIn_UserInfoControl_PageData oCIn_UserInfoControl_PageData, COut_UserInfo oCOut_UserInfo)
        {
            // 成功執行的筆數
            int iRT = 0;

            // 新增的資料
            CTab_UserInfoControl oCTab_UserInfoControl = new CTab_UserInfoControl();

            // 回傳訊息
            string sMessage = "";

            try
            {
                // 組合新增的資料
                this._oCEntityContext.CTab_UserInfoControl.Add(oCTab_UserInfoControl).CurrentValues.SetValues(oCIn_UserInfoControl_PageData);

                // 執行新增
                iRT = this._oCEntityContext.SaveChanges();
            }
            catch (Exception ex)
            {
                sMessage = ex.Message;
            }

            return (oCTab_UserInfoControl, iRT, sMessage);
        }
        #endregion

        #region 刪除資料
        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <param name="lInfoPk">使用者PK</param>
        /// <param name="lModulePk">選單作業PK</param>
        /// <returns>成功執行的筆數/回傳訊息</returns>
        public (int, string) fnDeletef(long lInfoPk, long lModulePk)
        {
            // 成功執行的筆數
            int iRT = 0;

            // 回傳訊息
            string sMessage = "";

            try
            {
                // 取得要刪除的那筆資料
                var vDelete = (from ta in this._oCEntityContext.CTab_UserInfoControl
                               where ta.Cfk_Info == lInfoPk && ta.Cfk_Module == lModulePk
                               select ta).SingleOrDefault();

                if (vDelete != null)
                {
                    // 可刪除多筆
                    this._oCEntityContext.CTab_UserInfoControl.RemoveRange(vDelete);

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
        /// <param name="oCIn_UserInfoControl_Search">查詢條件</param>
        /// <returns>查詢結果/回傳訊息</returns>
        public (List<CTab_UserInfoControl>, string) fnGet(CIn_UserInfoControl_Search oCIn_UserInfoControl_Search)
        {
            // 查詢結果
            List<CTab_UserInfoControl> lCTab_UserInfoControl = new List<CTab_UserInfoControl>();

            // 回傳訊息
            string sMessage = "";

            try
            {
                // 查詢全部
                var vRT = from ta in this._oCEntityContext.CTab_UserInfoControl
                          select ta;

                #region 查詢條件
                if (oCIn_UserInfoControl_Search.Cfk_Info != null)
                {
                    vRT = vRT.Where(x => x.Cfk_Info == oCIn_UserInfoControl_Search.Cfk_Info);
                }

                if (oCIn_UserInfoControl_Search.Cfk_Module != null)
                {
                    vRT = vRT.Where(x => x.Cfk_Module == oCIn_UserInfoControl_Search.Cfk_Module);
                }

                if (oCIn_UserInfoControl_Search.Cfk_ModCon_Code != null)
                {
                    vRT = vRT.Where(x => x.Cfk_ModuleControl.Contains(oCIn_UserInfoControl_Search.Cfk_ModCon_Code));
                }
                #endregion

                lCTab_UserInfoControl = vRT.ToList();
            }
            catch (Exception ex)
            {
                sMessage = ex.Message;
            }

            return (lCTab_UserInfoControl, sMessage);
        }
        #endregion

        #region 取得資料 (包含：使用者帳號&模組名稱&擁有的控制項)
        /// <summary>
        /// 取得資料 (包含：使用者帳號&模組代號&控制項代號)
        /// </summary>
        /// <param name="sAccount">登入帳號</param>
        /// <param name="sModule">呼叫API：模組代號</param>
        /// <param name="sControl">呼叫API：控制項代號</param>
        /// <returns>查詢結果/回傳訊息</returns>
        public (bool, string) fnGetName(string sAccount, string sModule, string sControl)
        {
            // 查詢結果
            bool bResult = false;

            // 回傳訊息
            string sMessage = "";

            try
            {
                // 查詢全部
                var vRT = from uic in this._oCEntityContext.CTab_UserInfoControl
                          join ui in this._oCEntityContext.CTab_UserInfo on uic.Cfk_Info equals ui.Pk_Info
                          join sm in this._oCEntityContext.CTab_SysModule on uic.Cfk_Module equals sm.Pk_Module
                          select new
                          {
                              uic.Cfk_Info,
                              ui.Info_Account,
                              ui.Info_State,
                              ui.Info_StartDate,
                              ui.Info_EndDate,
                              uic.Cfk_Module,
                              sm.Module_Name,
                              sm.Module_Route,
                              sm.Module_Discern,
                              sm.Module_State,
                              sm.Module_StartDate,
                              sm.Module_EndDate,
                              uic.Cfk_ModuleControl
                          };

                #region 查詢條件
                if (vRT.Count() > 0)
                {
                    vRT = vRT.Where(x => x.Info_Account == sAccount && x.Info_State == "1" && DateTime.Now >= x.Info_StartDate && DateTime.Now <= x.Info_EndDate);
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