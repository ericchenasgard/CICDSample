using Net_Core_Common_Model.Dto.Sys.SysLogTrajectory;

namespace Net_Core_Common_Repository.Sys.SysLogTrajectory
{
    /// <summary>
    /// 程式執行Log
    /// </summary>
    public interface ISysLogTrajectory
    {
        /// <summary>
        /// 新增資料
        /// </summary>
        /// <param name="oCIn_SysLogTrajectory_PageData">頁面資料</param>
        /// <returns>成功執行的筆數/回傳訊息</returns>
        public (int, string) fnInsert(CIn_SysLogTrajectory_PageData oCIn_SysLogTrajectory_PageData);
    }
}
