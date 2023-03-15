using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.IdentityModel.Tokens;
using Net_Core_Common_API.Method.DoLoginLog;
using Net_Core_Common_API.Method.SetResponse;
using Net_Core_Common_Model.Dto;
using Net_Core_Common_Model.Dto.Login;
using Net_Core_Common_Model.Dto.User.UserInfo;
using Net_Core_Common_Model.Dto.User.UserRoleMember;
using Net_Core_Common_Model.Entity.User;
using Net_Core_Common_Repository.Login;
using Net_Core_Common_Repository.User.UserInfo;
using Net_Core_Common_Repository.User.UserRoleMember;
using Net_Core_Common_Services.Public.DoNLog;
using Net_Core_Common_Services.Public.GetRequestInfo;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Net_Core_Common_API.Controllers
{
    /// <summary>
    /// 登入
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        /// <summary>
        /// 執行NLog記錄
        /// </summary>
        private readonly IDoNLog _oIDoNLog;

        /// <summary>
        /// 回傳資料/訊息/狀態
        /// </summary>
        private readonly ISetResponse _oISetResponse;

        /// <summary>
        /// 登入
        /// </summary>
        private readonly ILogin _oILogin;

        /// <summary>
        /// 寫入登入log
        /// </summary>
        private readonly IDoLoginLog _oIDoLoginLog;

        /// <summary>
        /// 取得IP
        /// </summary>
        private readonly IGetRequestInfo _oIGetRequestInfo;

        /// <summary>
        /// 使用者帳號設定
        /// </summary>
        private readonly IUserInfo _oIUserInfo;

        /// <summary>
        /// 使用者角色權限
        /// </summary>
        private readonly IUserRoleMember _oIUserRoleMember;

        /// <summary>
        /// 以Dictionary的方式取用組態設定
        /// </summary>
        private readonly IConfiguration _oIConfiguration;

        /// <summary>
        /// 使用分散式快取
        /// </summary>
        private readonly IDistributedCache _oIDistributedCache;

        #region 建構式
        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="oIDoNLog">執行NLog記錄</param>
        /// <param name="oISetResponse">回傳資料/訊息/狀態</param>
        /// <param name="oILogin">登入</param>
        /// <param name="oIDoLoginLog">寫入登入log</param>
        /// <param name="oIGetRequestInfo">取得IP</param>
        /// <param name="oIUserInfo">使用者資訊</param>
        /// <param name="oIUserRoleMember">使用者角色成員</param>
        /// <param name="oIConfiguration">Dictionary的方式取用組態設定</param>
        /// <param name="oIDistributedCache">使用分散式快取</param>
        public LoginController(IDoNLog oIDoNLog, ISetResponse oISetResponse, ILogin oILogin, IDoLoginLog oIDoLoginLog, IGetRequestInfo oIGetRequestInfo, IUserInfo oIUserInfo, IUserRoleMember oIUserRoleMember, IConfiguration oIConfiguration, IDistributedCache oIDistributedCache)
        {
            this._oIDoNLog = oIDoNLog;
            this._oISetResponse = oISetResponse;
            this._oILogin = oILogin;
            this._oIDoLoginLog = oIDoLoginLog;
            this._oIGetRequestInfo = oIGetRequestInfo;
            this._oIUserInfo = oIUserInfo;
            this._oIUserRoleMember = oIUserRoleMember;
            this._oIConfiguration = oIConfiguration;
            this._oIDistributedCache = oIDistributedCache;
        }
        #endregion

        /// <summary>
        /// 登入
        /// </summary>
        /// <param name="oCIn_Login_PageData">登入帳號/密碼</param>
        /// <returns>登入資訊</returns>
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(CIn_Login_PageData oCIn_Login_PageData)
        {
            // 紀錄執行是否有錯誤
            bool bIsError = false;

            // 紀錄執行訊息
            string sMessage = "";

            // 判斷帳號是否被鎖定
            bool bIsNoLock = false;

            // 判斷帳號/密碼是否有效
            bool bIsEffective = false;

            string test = "";

            // 帳號
            string sUserAccount = oCIn_Login_PageData.UserAccount;

            // 密碼(AES加密)
            string sUserPassword = oCIn_Login_PageData.UserPassword;

            // 取得使用者資料
            List<CTab_UserInfo> lCTab_UserInfo = new List<CTab_UserInfo>();
            string sInfoMessage = "";

            // 取得使用者角色
            List<COut_UserRoleInfoName> lCOut_UserRoleInfoName = new List<COut_UserRoleInfoName>();
            string sRoleMessage = "";

            // 使用者主鍵
            long sInfoPk = 0;

            // 使用者角色
            string sUserRole = "";

            // 登入成功與否
            bool bLoginResult = false;

            // 登入Token
            var vToken = "";

            #region 登入資訊
            CIn_Login_Search oCIn_Login_Search = new CIn_Login_Search();
            oCIn_Login_Search.UserAccount = sUserAccount; // 登入帳號
            oCIn_Login_Search.UserPassword = sUserPassword; // 登入密碼
            oCIn_Login_Search.UserIp = this._oIGetRequestInfo.fnGetClientIP(); // 登入者Ip
            oCIn_Login_Search.LiftLockMinute = 2; // 解除鎖定時間
            #endregion

            #region 判斷帳號是否被鎖定
            bIsNoLock = this._oILogin.fnCheckLockAccount(oCIn_Login_Search);

            if (!bIsNoLock)
            {
                sMessage += "帳號已鎖定。";
                bIsError = true;
            }
            else
            {
                #region 判斷帳號/密碼是否有效
                bIsEffective = this._oILogin.fnCheckEffectiveUser(oCIn_Login_Search);

                if (!bIsEffective)
                {
                    sMessage += "帳號密碼錯誤。";
                    bIsError = true;
                }
                #endregion
            }
            #endregion

            if (!bIsError)
            {
                #region 取得使用者資料
                // 塞入查詢值
                CIn_UserInfo_Search oCIn_UserInfo_Search = new CIn_UserInfo_Search()
                {
                    Info_Account = sUserAccount
                };

                // 取得執行結果(回傳資料)
                (lCTab_UserInfo, sInfoMessage) = this._oIUserInfo.fnGet(oCIn_UserInfo_Search);

                if (lCTab_UserInfo.Count > 0 && sInfoMessage == "")
                {
                    // 取得使用者PK
                    CTab_UserInfo tabInfo = lCTab_UserInfo.First();
                    sInfoPk = tabInfo.Pk_Info;

                    #region 取得使用者角色
                    // 塞入查詢值
                    CIn_UserRoleMember_Search oCIn_UserRoleMember_Search = new CIn_UserRoleMember_Search()
                    {
                        Cfk_Info = sInfoPk
                    };

                    // 取得執行結果(回傳資料)
                    (lCOut_UserRoleInfoName, sRoleMessage) = this._oIUserRoleMember.fnGetName(oCIn_UserRoleMember_Search);

                    if (lCOut_UserRoleInfoName.Count > 0 && sRoleMessage == "")
                    {
                        // 取得使用者角色
                        COut_UserRoleInfoName tabRole = lCOut_UserRoleInfoName.First();
                        sUserRole = tabRole.Role_Name;
                    }
                    else
                    {
                        sMessage += "this._oIUserRoleMember.fnGetName()，取得使用者角色發生錯誤：" + sRoleMessage + "。";
                    }
                    #endregion
                }
                else
                {
                    sMessage += "this._oIUserInfo.fnGet()，取得使用者資料發生錯誤：" + sInfoMessage + "。";
                }
                #endregion

                #region 產生Token
                var vClaims = new List<Claim>
                {
                    new Claim("Account", sUserAccount),
                    new Claim("Role", sUserRole)
                };

                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._oIConfiguration["Jwt:Key"]));

                var jwt = new JwtSecurityToken
                (
                    issuer: this._oIConfiguration["Jwt:Issuer"],
                    audience: this._oIConfiguration["Jwt:Audience"],
                    claims: vClaims,
                    expires: DateTime.Now.AddMinutes(Convert.ToDouble(this._oIConfiguration["Jwt:Exp"])),
                    signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
                );

                vToken = new JwtSecurityTokenHandler().WriteToken(jwt);
                #endregion
            }

            #region 寫入登入log
            var (iChange, sLoginLogMessage) = this._oIDoLoginLog.fnDoLoginLog(sUserAccount, sMessage, bLoginResult, this._oIGetRequestInfo.fnGetClientIP());

            if (sLoginLogMessage != "")
            {
                sMessage += "this._oIDoLoginLog.fnDoLoginLog()，寫入登入log發生錯誤：" + sLoginLogMessage + "。";
            }
            #endregion

            #region 回傳資料/訊息/狀態
            // 回傳資料
            string sOut_Data = vToken;

            #region 回傳訊息
            string sOut_Message = "";
            if (sMessage != "")
            {
                sOut_Message = sOut_Message + sMessage + "。";
            }
            #endregion

            COut_Response cOut_Response = this._oISetResponse.fnSetResponse(sOut_Data, sOut_Message);
            #endregion

            return new JsonResult(cOut_Response);
        }
    }
}