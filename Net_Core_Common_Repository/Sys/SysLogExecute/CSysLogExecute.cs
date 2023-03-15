using Net_Core_Common_Model.Dto;
using Net_Core_Common_Model.Dto.Sys.SysLogExecute;
using Net_Core_Common_Model.Entity;
using Net_Core_Common_Model.Entity.Sys;

namespace Net_Core_Common_Repository.Sys.SysLogExecute
{
    /// <summary>
    /// 系統操作歷程
    /// </summary>
    public class CSysLogExecute : ISysLogExecute
    {
        private readonly CEntityContext _oCEntityContext;

        #region 建構式
        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="oCEntityContext">資料庫實體</param>
        public CSysLogExecute(CEntityContext oCEntityContext)
        {
            this._oCEntityContext = oCEntityContext;
        }
        #endregion

        #region 新增資料
        /// <summary>
        /// 新增資料
        /// </summary>
        /// <param name="oCIn_SysLogExecute_PageData">頁面資料</param>
        /// <param name="oCOut_UserInfo">使用者資訊</param>
        /// <returns>新增的資料/成功執行的筆數/回傳訊息</returns>
        public (CTab_SysLogExecute, int, string) fnInsert(CIn_SysLogExecute_PageData oCIn_SysLogExecute_PageData, COut_UserInfo oCOut_UserInfo)
        {
            // 成功執行的筆數
            int iRT = 0;

            // 新增的資料
            CTab_SysLogExecute oCTab_SysLogExecute = new CTab_SysLogExecute();

            // 回傳訊息
            string sMessage = "";

            try
            {
                #region 建立者、異動者資訊
                oCTab_SysLogExecute.LogExec_CreateId = oCOut_UserInfo.sCreateId;
                oCTab_SysLogExecute.LogExec_CreateDate = oCOut_UserInfo.dCreateDate;
                oCTab_SysLogExecute.LogExec_CreateIp = oCOut_UserInfo.sCreateIp;
                #endregion

                // 組合新增的資料
                this._oCEntityContext.CTab_SysLogExecute.Add(oCTab_SysLogExecute).CurrentValues.SetValues(oCIn_SysLogExecute_PageData);

                // 執行新增
                iRT = this._oCEntityContext.SaveChanges();
            }
            catch (Exception ex)
            {
                sMessage = ex.Message;
            }

            return (oCTab_SysLogExecute, iRT, sMessage);
        }
        #endregion

        #region 取得資料
        /// <summary>
        /// 取得資料-依查詢條件做查詢
        /// </summary>
        /// <param name="oCIn_SysLogExecute_Search">查詢條件</param>
        /// <returns>查詢結果/回傳訊息</returns>
        public (List<CTab_SysLogExecute>, string) fnGet(CIn_SysLogExecute_Search oCIn_SysLogExecute_Search)
        {
            // 查詢結果
            List<CTab_SysLogExecute> lCTab_SysLogExecute = new List<CTab_SysLogExecute>();

            // 回傳訊息
            string sMessage = "";

            try
            {
                // 查詢全部
                var vRT = from ta in this._oCEntityContext.CTab_SysLogExecute
                          select ta;

                #region 查詢條件
                if (oCIn_SysLogExecute_Search.LogExec_Module != null)
                {
                    vRT = vRT.Where(x => x.LogExec_Module.Contains(oCIn_SysLogExecute_Search.LogExec_Module));
                }

                if (oCIn_SysLogExecute_Search.LogExec_Action != null)
                {
                    vRT = vRT.Where(x => x.LogExec_Action.Contains(oCIn_SysLogExecute_Search.LogExec_Action));
                }

                if (oCIn_SysLogExecute_Search.LogExec_ChangeItem != null)
                {
                    vRT = vRT.Where(x => x.LogExec_ChangeItem.Contains(oCIn_SysLogExecute_Search.LogExec_ChangeItem));
                }

                if (oCIn_SysLogExecute_Search.LogExec_CreateId != null)
                {
                    vRT = vRT.Where(x => x.LogExec_CreateId == oCIn_SysLogExecute_Search.LogExec_CreateId);
                }
                #endregion

                lCTab_SysLogExecute = vRT.ToList();
            }
            catch (Exception ex)
            {
                sMessage = ex.Message;
            }

            return (lCTab_SysLogExecute, sMessage);
        }
        #endregion
    }
}