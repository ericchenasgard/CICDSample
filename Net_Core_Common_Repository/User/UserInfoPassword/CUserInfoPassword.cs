using Net_Core_Common_Model.Dto;
using Net_Core_Common_Model.Dto.User.UserInfoPassword;
using Net_Core_Common_Model.Entity;
using Net_Core_Common_Model.Entity.User;

namespace Net_Core_Common_Repository.User.UserInfoPassword
{
    /// <summary>
    /// 使用者密碼變更記錄
    /// </summary>
    public class CUserInfoPassword : IUserInfoPassword
    {
        private readonly CEntityContext _oCEntityContext;

        #region 建構式
        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="oCEntityContext">資料庫實體</param>
        public CUserInfoPassword(CEntityContext oCEntityContext)
        {
            this._oCEntityContext = oCEntityContext;
        }
        #endregion

        #region 新增資料
        /// <summary>
        /// 新增資料
        /// </summary>
        /// <param name="oCIn_UserInfoPassword_PageData">頁面資料</param>
        /// <param name="oCOut_UserInfo">使用者資訊</param>
        /// <returns>新增的資料/成功執行的筆數/回傳訊息</returns>
        public (CTab_UserInfoPassword, int, string) fnInsert(CIn_UserInfoPassword_PageData oCIn_UserInfoPassword_PageData, COut_UserInfo oCOut_UserInfo)
        {
            // 成功執行的筆數
            int iRT = 0;

            // 新增的資料
            CTab_UserInfoPassword oCTab_UserInfoPassword = new CTab_UserInfoPassword();

            // 回傳訊息
            string sMessage = "";

            try
            {
                #region 建立者、異動者資訊
                oCTab_UserInfoPassword.InfoPas_CreateId = oCOut_UserInfo.sCreateId;
                oCTab_UserInfoPassword.InfoPas_CreateDate = oCOut_UserInfo.dCreateDate;
                oCTab_UserInfoPassword.InfoPas_CreateIp = oCOut_UserInfo.sCreateIp;
                #endregion

                // 組合新增的資料
                this._oCEntityContext.CTab_UserInfoPassword.Add(oCTab_UserInfoPassword).CurrentValues.SetValues(oCIn_UserInfoPassword_PageData);

                // 執行新增
                iRT = this._oCEntityContext.SaveChanges();
            }
            catch (Exception ex)
            {
                sMessage = ex.Message;
            }

            return (oCTab_UserInfoPassword, iRT, sMessage);
        }
        #endregion
    }
}