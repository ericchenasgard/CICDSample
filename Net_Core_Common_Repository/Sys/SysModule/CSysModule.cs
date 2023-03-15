using Net_Core_Common_Model.Dto;
using Net_Core_Common_Model.Dto.Sys.SysModule;
using Net_Core_Common_Model.Entity;
using Net_Core_Common_Model.Entity.Sys;

namespace Net_Core_Common_Repository.Sys.SysModule
{
    /// <summary>
    /// 選單作業
    /// </summary>
    public class CSysModule : ISysModule
    {
        private readonly CEntityContext _oCEntityContext;

        #region 建構式
        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="oCEntityContext">資料庫實體</param>
        public CSysModule(CEntityContext oCEntityContext)
        {
            this._oCEntityContext = oCEntityContext;
        }
        #endregion

        #region 新增資料
        /// <summary>
        /// 新增資料
        /// </summary>
        /// <param name="oCIn_SysModule_PageData">頁面資料</param>
        /// <param name="oCOut_UserInfo">使用者資訊</param>
        /// <returns>新增的資料/成功執行的筆數/回傳訊息</returns>
        public (CTab_SysModule, int, string) fnInsert(CIn_SysModule_PageData oCIn_SysModule_PageData, COut_UserInfo oCOut_UserInfo)
        {
            // 成功執行的筆數
            int iRT = 0;

            // 新增的資料
            CTab_SysModule oCTab_SysModule = new CTab_SysModule();

            // 回傳訊息
            string sMessage = "";

            try
            {
                #region 建立者、異動者資訊
                oCTab_SysModule.Module_CreateId = oCOut_UserInfo.sCreateId;
                oCTab_SysModule.Module_CreateDate = oCOut_UserInfo.dCreateDate;
                oCTab_SysModule.Module_CreateIp = oCOut_UserInfo.sCreateIp;
                oCTab_SysModule.Module_EditId = oCOut_UserInfo.sCreateId;
                oCTab_SysModule.Module_EditDate = oCOut_UserInfo.dCreateDate;
                oCTab_SysModule.Module_EditIp = oCOut_UserInfo.sCreateIp;
                #endregion

                // 組合新增的資料
                this._oCEntityContext.CTab_SysModule.Add(oCTab_SysModule).CurrentValues.SetValues(oCIn_SysModule_PageData);

                // 執行新增
                iRT = this._oCEntityContext.SaveChanges();
            }
            catch (Exception ex)
            {
                sMessage = ex.Message;
            }

            return (oCTab_SysModule, iRT, sMessage);
        }
        #endregion

        #region 更新資料
        /// <summary>
        /// 更新資料
        /// </summary>
        /// <param name="oCIn_SysModule_Update">更新資料</param>
        /// <param name="oCOut_UserInfo">使用者資訊</param>
        /// <returns>更新的資料/成功執行的筆數/回傳訊息</returns>
        public (CTab_SysModule, int, string) fnUpdate(CIn_SysModule_Update oCIn_SysModule_Update, COut_UserInfo oCOut_UserInfo)
        {
            // 成功執行的筆數
            int iRT = 0;

            // 更新的資料
            CTab_SysModule oCTab_SysModule = new CTab_SysModule();

            // 回傳訊息
            string sMessage = "";

            try
            {
                // 取得要更新的那筆資料
                var vUpdate = (from ta in this._oCEntityContext.CTab_SysModule
                               where ta.Pk_Module == oCIn_SysModule_Update.Pk_Module
                               select ta).SingleOrDefault();

                // 定義更新的資料
                if (vUpdate != null)
                {
                    vUpdate.FK_ModuleClass = oCIn_SysModule_Update.FK_ModuleClass;
                    vUpdate.Module_Name = oCIn_SysModule_Update.Module_Name;
                    vUpdate.Module_Route = oCIn_SysModule_Update.Module_Route;
                    vUpdate.Module_Discern = oCIn_SysModule_Update.Module_Discern;
                    vUpdate.Module_outLink = oCIn_SysModule_Update.Module_outLink;
                    vUpdate.Module_StartDate = oCIn_SysModule_Update.Module_StartDate;
                    vUpdate.Module_EndDate = oCIn_SysModule_Update.Module_EndDate;
                    vUpdate.Module_order = oCIn_SysModule_Update.Module_order;
                    vUpdate.Module_State = oCIn_SysModule_Update.Module_State;

                    vUpdate.Module_EditId = oCOut_UserInfo.sCreateId;
                    vUpdate.Module_EditDate = oCOut_UserInfo.dCreateDate;
                    vUpdate.Module_EditIp = oCOut_UserInfo.sCreateIp;

                    // 執行更新
                    iRT = this._oCEntityContext.SaveChanges();

                    if (iRT > 0)
                    {
                        oCTab_SysModule = vUpdate;
                    }
                }
            }
            catch (Exception ex)
            {
                sMessage = ex.Message;
            }

            return (oCTab_SysModule, iRT, sMessage);
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
                var vDelete = (from ta in this._oCEntityContext.CTab_SysModule
                               where ta.Pk_Module == lPk
                               select ta).SingleOrDefault();

                if (vDelete != null)
                {
                    // 可刪除多筆
                    this._oCEntityContext.CTab_SysModule.RemoveRange(vDelete);

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
        /// <param name="oCIn_SysModule_Search">查詢條件</param>
        /// <returns>查詢結果/回傳訊息</returns>
        public (List<CTab_SysModule>, string) fnGet(CIn_SysModule_Search oCIn_SysModule_Search)
        {
            // 查詢結果
            List<CTab_SysModule> lCTab_SysModule = new List<CTab_SysModule>();

            // 回傳訊息
            string sMessage = "";

            try
            {
                // 查詢全部
                var vRT = from ta in this._oCEntityContext.CTab_SysModule
                          select ta;

                #region 查詢條件
                if (oCIn_SysModule_Search.Pk_Module != null)
                {
                    vRT = vRT.Where(x => x.Pk_Module == oCIn_SysModule_Search.Pk_Module);
                }

                if (oCIn_SysModule_Search.Module_Name != null)
                {
                    vRT = vRT.Where(x => x.Module_Name.Contains(oCIn_SysModule_Search.Module_Name));
                }

                if (oCIn_SysModule_Search.Module_State != null)
                {
                    vRT = vRT.Where(x => x.Module_State.Contains(oCIn_SysModule_Search.Module_State));
                }
                #endregion

                lCTab_SysModule = vRT.ToList();
            }
            catch (Exception ex)
            {
                sMessage = ex.Message;
            }

            return (lCTab_SysModule, sMessage);
        }
        #endregion
    }
}