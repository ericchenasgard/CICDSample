using Net_Core_Common_Model.Dto.Sys.SysLogError;

namespace Net_Core_Common_Repository.Sys.SysLogError
{
    /// <summary>
    /// 錯誤Log
    /// </summary>
    public interface ISysLogError
    {
        /// <summary>
        /// 新增資料
        /// </summary>
        /// <param name="oCIn_SysLogError_PageData">頁面資料</param>
        /// <returns>成功執行的筆數/回傳訊息</returns>
        public (int, string) fnInsert(CIn_SysLogError_PageData oCIn_SysLogError_PageData);
    }
}
