using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Net_Core_Common_API.Method.SetResponse;
using Net_Core_Common_Model.Dto;
using Net_Core_Common_Services.Public.DoNLog;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Net_Core_Common_API.Controllers
{
    /// <summary>
    /// 刷新Token
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TokenRefreshController : ControllerBase
    {
        /// <summary>
        /// 執行NLog記錄
        /// </summary>
        private readonly IDoNLog _oIDoNLog;

        /// <summary>
        /// 以Dictionary的方式取用組態設定
        /// </summary>
        private readonly IConfiguration _oIConfiguration;

        /// <summary>
        /// 回傳資料/訊息/狀態
        /// </summary>
        private readonly ISetResponse _oISetResponse;

        /// <summary>
        /// 使用HttpContext取得Request資訊
        /// </summary>
        private HttpContext _Context { get; set; }

        #region 建構式
        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="oIDoNLog">執行NLog記錄</param>
        /// <param name="oIConfiguration">Dictionary的方式取用組態設定</param>
        /// <param name="oISetResponse">回傳資料/訊息/狀態</param>
        /// <param name="httpContextAccessor">使用HttpContext取得Request資訊</param>
        public TokenRefreshController(IDoNLog oIDoNLog, IConfiguration oIConfiguration, ISetResponse oISetResponse, IHttpContextAccessor httpContextAccessor)
        {
            this._oIDoNLog = oIDoNLog;
            this._oIConfiguration = oIConfiguration;
            this._oISetResponse = oISetResponse;
            this._Context = httpContextAccessor.HttpContext;
        }
        #endregion

        #region 取得選單權限控制樹
        /// <summary>
        /// 取得選單權限控制樹
        /// </summary>
        /// <returns>查詢結果(單筆)</returns>
        [HttpPost("Get")]
        public ActionResult Get()
        {
            // 帳號
            string sUserAccount = "";

            // 使用者角色
            string sUserRole = "";

            // 登入Token
            var vToken = "";

            // 回傳訊息
            string sOut_Message = "";

            try
            {
                #region 取得目前Token資訊
                var lClaims = this._Context.User.Claims.ToList();

                if (lClaims != null)
                {
                    foreach (var vCla in lClaims)
                    {
                        // 取得 Claims類型
                        string sType = vCla.Type.ToString();

                        // 取得 Claims值
                        string sValue = vCla.Value.ToString();

                        if (sType == "Account")
                        {
                            sUserAccount = sValue;
                        }

                        if (sType == "Role")
                        {
                            sUserRole = sValue;
                        }
                    }
                }
                #endregion

                #region 產生新的Token
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
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
                );

                vToken = new JwtSecurityTokenHandler().WriteToken(jwt);
                #endregion
            }
            catch (Exception ex)
            {
                sOut_Message = ex.Message;
            }

            #region 回傳資料/訊息/狀態
            // 回傳資料
            string sOut_Data = vToken;

            COut_Response cOut_Response = this._oISetResponse.fnSetResponse(sOut_Data, sOut_Message);
            #endregion

            return new JsonResult(cOut_Response);
        }
        #endregion
    }
}