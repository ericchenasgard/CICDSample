using Net_Core_Common_Model.Dto.Sys.SysLogLogin;

namespace Net_Core_Common_Repository.Sys.SysLogLogin
{
    /// <summary>
    /// 登入log (只記錄在DB裡)
    /// </summary>
    public interface ISysLogLogin
    {
        /// <summary>
        /// 新增資料
        /// </summary>
        /// <param name="oCIn_SysLogLogin_PageData">頁面資料</param>
        /// <returns>成功執行的筆數/回傳訊息</returns>
        public (int, string) fnInsert(CIn_SysLogLogin_PageData oCIn_SysLogLogin_PageData);
    }
}
