using Net_Core_Common_Model.Dto.Sys.SysLogTrajectory;
using Net_Core_Common_Model.Entity;
using Net_Core_Common_Model.Entity.Sys;

namespace Net_Core_Common_Repository.Sys.SysLogTrajectory
{
    /// <summary>
    /// 程式執行Log
    /// </summary>
    public class CSysLogTrajectory : ISysLogTrajectory
    {
        private readonly CEntityContext _oCEntityContext;

        #region 建構式
        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="oCEntityContext">資料庫實體</param>
        public CSysLogTrajectory(CEntityContext oCEntityContext)
        {
            this._oCEntityContext = oCEntityContext;
        }
        #endregion

        #region 新增資料
        /// <summary>
        /// 新增資料
        /// </summary>
        /// <param name="oCIn_SysLogTrajectory_PageData">頁面資料</param>
        /// <returns>成功執行的筆數/回傳訊息</returns>
        public (int, string) fnInsert(CIn_SysLogTrajectory_PageData oCIn_SysLogTrajectory_PageData)
        {
            // 成功執行的筆數
            int iRT = 0;

            // 新增的資料
            CTab_SysLogTrajectory oCTab_SysLogTrajectory = new CTab_SysLogTrajectory();

            // 回傳訊息
            string sMessage = "";

            try
            {
                // 組合新增的資料
                this._oCEntityContext.CTab_SysLogTrajectory.Add(oCTab_SysLogTrajectory).CurrentValues.SetValues(oCIn_SysLogTrajectory_PageData);

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
