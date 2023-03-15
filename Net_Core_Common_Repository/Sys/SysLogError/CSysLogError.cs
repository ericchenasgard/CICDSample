using Net_Core_Common_Model.Dto.Sys.SysLogError;
using Net_Core_Common_Model.Entity;
using Net_Core_Common_Model.Entity.Sys;

namespace Net_Core_Common_Repository.Sys.SysLogError
{
    /// <summary>
    /// 錯誤Log
    /// </summary>
    public class CSysLogError : ISysLogError
    {
        private readonly CEntityContext _oCEntityContext;

        #region 建構式
        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="oCEntityContext">資料庫實體</param>
        public CSysLogError(CEntityContext oCEntityContext)
        {
            this._oCEntityContext = oCEntityContext;
        }
        #endregion

        #region 新增資料
        /// <summary>
        /// 新增資料
        /// </summary>
        /// <param name="oCIn_SysLogError_PageData">頁面資料</param>
        /// <returns>成功執行的筆數/回傳訊息</returns>
        public (int, string) fnInsert(CIn_SysLogError_PageData oCIn_SysLogError_PageData)
        {
            // 成功執行的筆數
            int iRT = 0;

            // 新增的資料
            CTab_SysLogError oCTab_SysLogError = new CTab_SysLogError();

            // 回傳訊息
            string sMessage = "";

            try
            {
                // 組合新增的資料
                this._oCEntityContext.CTab_SysLogError.Add(oCTab_SysLogError).CurrentValues.SetValues(oCIn_SysLogError_PageData);

                // 執行新增
                iRT = this._oCEntityContext.SaveChanges();
            }
            catch (Exception ex)
            {
                sMessage = ex.Message;
            }

            return (iRT, sMessage);
        }
        #endregion
    }
}
