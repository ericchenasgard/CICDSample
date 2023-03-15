using Net_Core_Common_Model.Dto;
using Net_Core_Common_Model.Dto.Sys.SysModuleControl;
using Net_Core_Common_Model.Entity;
using Net_Core_Common_Model.Entity.Sys;

namespace Net_Core_Common_Repository.Sys.SysModuleControl
{
    /// <summary>
    /// 選單作業控制項
    /// </summary>
    public class CSysModuleControl : ISysModuleControl
    {
        private readonly CEntityContext _oCEntityContext;

        #region 建構式
        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="oCEntityContext">資料庫實體</param>
        public CSysModuleControl(CEntityContext oCEntityContext)
        {
            this._oCEntityContext = oCEntityContext;
        }
        #endregion

        #region 新增資料
        /// <summary>
        /// 新增資料
        /// </summary>
        /// <param name="oCIn_SysModuleControl_PageData">頁面資料</param>
        /// <param name="oCOut_UserInfo">使用者資訊</param>
        /// <returns>新增的資料/成功執行的筆數/回傳訊息</returns>
        public (CTab_SysModuleControl, int, string) fnInsert(CIn_SysModuleControl_PageData oCIn_SysModuleControl_PageData, COut_UserInfo oCOut_UserInfo)
        {
            // 成功執行的筆數
            int iRT = 0;

            // 新增的資料
            CTab_SysModuleControl oCTab_SysModuleControl = new CTab_SysModuleControl();

            // 回傳訊息
            string sMessage = "";

            try
            {
                // 組合新增的資料
                this._oCEntityContext.CTab_SysModuleControl.Add(oCTab_SysModuleControl).CurrentValues.SetValues(oCIn_SysModuleControl_PageData);

                // 執行新增
                iRT = this._oCEntityContext.SaveChanges();
            }
            catch (Exception ex)
            {
                sMessage = ex.Message;
            }

            return (oCTab_SysModuleControl, iRT, sMessage);
        }
        #endregion

        #region 刪除資料
        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <param name="lModulePk">選單作業PK</param>
        /// <param name="sModControlPk">選單作業控制項PK</param>
        /// <returns>成功執行的筆數/回傳訊息</returns>
        public (int, string) fnDelete(long lModulePk, string sModControlPk)
        {
            // 成功執行的筆數
            int iRT = 0;

            // 回傳訊息
            string sMessage = "";

            try
            {
                // 取得要刪除的那筆資料
                var vDelete = (from ta in this._oCEntityContext.CTab_SysModuleControl
                               where ta.Cfk_Module == lModulePk
                               && ta.ModCon_Code == sModControlPk
                               select ta).SingleOrDefault();

                if (vDelete != null)
                {
                    // 可刪除多筆
                    this._oCEntityContext.CTab_SysModuleControl.RemoveRange(vDelete);

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
        /// <param name="oCIn_SysModuleControl_Search">查詢條件</param>
        /// <returns>查詢結果/回傳訊息</returns>
        public (List<CTab_SysModuleControl>, string) fnGet(CIn_SysModuleControl_Search oCIn_SysModuleControl_Search)
        {
            // 查詢結果
            List<CTab_SysModuleControl> lCTab_SysModuleControl = new List<CTab_SysModuleControl>();

            // 回傳訊息
            string sMessage = "";

            try
            {
                // 查詢全部
                var vRT = from ta in this._oCEntityContext.CTab_SysModuleControl
                          select ta;

                #region 查詢條件
                if (oCIn_SysModuleControl_Search.Cfk_Module != null)
                {
                    vRT = vRT.Where(x => x.Cfk_Module == oCIn_SysModuleControl_Search.Cfk_Module);
                }

                if (oCIn_SysModuleControl_Search.ModCon_Code != null)
                {
                    vRT = vRT.Where(x => x.ModCon_Code.Contains(oCIn_SysModuleControl_Search.ModCon_Code));
                }

                if (oCIn_SysModuleControl_Search.ModCon_Name != null)
                {
                    vRT = vRT.Where(x => x.ModCon_Name.Contains(oCIn_SysModuleControl_Search.ModCon_Name));
                }
                #endregion

                lCTab_SysModuleControl = vRT.ToList();
            }
            catch (Exception ex)
            {
                sMessage = ex.Message;
            }

            return (lCTab_SysModuleControl, sMessage);
        }
        #endregion
    }
}