using Net_Core_Common_Model.Dto.Sys.SysLogLogin;
using Net_Core_Common_Model.Entity;
using Net_Core_Common_Model.Entity.Sys;

namespace Net_Core_Common_Repository.Sys.SysLogLogin
{
    /// <summary>
    /// 登入log (只記錄在DB裡)
    /// </summary>
    public class CSysLogLogin : ISysLogLogin
    {
        private readonly CEntityContext _oCEntityContext;

        #region 建構式
        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="oCEntityContext">資料庫實體</param>
        public CSysLogLogin(CEntityContext oCEntityContext)
        {
            this._oCEntityContext = oCEntityContext;
        }
        #endregion

        #region 新增資料
        /// <summary>
        /// 新增資料
        /// </summary>
        /// <param name="oCIn_SysLogLogin_PageData">頁面資料</param>
        /// <returns>成功執行的筆數/回傳訊息</returns>
        public (int, string) fnInsert(CIn_SysLogLogin_PageData oCIn_SysLogLogin_PageData)
        {
            // 成功執行的筆數
            int iRT = 0;

            // 新增的資料
            CTab_SysLogLogin oCTab_SysLogLogin = new CTab_SysLogLogin();

            // 回傳訊息
            string sMessage = "";

            try
            {
                // 組合新增的資料
                this._oCEntityContext.CTab_SysLogLogin.Add(oCTab_SysLogLogin).CurrentValues.SetValues(oCIn_SysLogLogin_PageData);

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
