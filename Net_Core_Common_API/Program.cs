using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Net_Core_Common_API.Method.AuthorizationMiddleware;
using Net_Core_Common_API.Method.AuthPermission;
using Net_Core_Common_API.Method.DoAuth;
using Net_Core_Common_API.Method.DoAuthHandler;
using Net_Core_Common_API.Method.DoAuthProvider;
using Net_Core_Common_API.Method.DoLoginLog;
using Net_Core_Common_API.Method.GetUserInfo;
using Net_Core_Common_API.Method.SetResponse;
using Net_Core_Common_Model.Dto;
using Net_Core_Common_Model.Entity;
using Net_Core_Common_Repository.Login;
using Net_Core_Common_Repository.Sys.SysCodeDetail;
using Net_Core_Common_Repository.Sys.SysCodeMain;
using Net_Core_Common_Repository.Sys.SysLogError;
using Net_Core_Common_Repository.Sys.SysLogExecute;
using Net_Core_Common_Repository.Sys.SysLogLogin;
using Net_Core_Common_Repository.Sys.SysLogTrajectory;
using Net_Core_Common_Repository.Sys.SysModule;
using Net_Core_Common_Repository.Sys.SysModuleClass;
using Net_Core_Common_Repository.Sys.SysModuleControl;
using Net_Core_Common_Repository.Sys.SysParameter;
using Net_Core_Common_Repository.User.UserInfo;
using Net_Core_Common_Repository.User.UserInfoAuth;
using Net_Core_Common_Repository.User.UserInfoControl;
using Net_Core_Common_Repository.User.UserInfoPassword;
using Net_Core_Common_Repository.User.UserRole;
using Net_Core_Common_Repository.User.UserRoleAuth;
using Net_Core_Common_Repository.User.UserRoleControl;
using Net_Core_Common_Repository.User.UserRoleMember;
using Net_Core_Common_Services.Define;
using Net_Core_Common_Services.Extension;
using Net_Core_Common_Services.Public.DoAES;
using Net_Core_Common_Services.Public.DoJson;
using Net_Core_Common_Services.Public.DoNLog;
using Net_Core_Common_Services.Public.GetRequestInfo;
using Net_Core_Common_Services.Public.GetSnowflakeId;
using NLog;
using NLog.Web;
using System.Text;

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    // 將NLog註冊到此專案內
    builder.Logging.ClearProviders();

    // 設定log紀錄的最小等級
    builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Information);
    builder.Host.UseNLog();

    // Add services to the container.
    builder.Services.AddControllers();

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();

    // 註冊 Swagger 產生器
    builder.Services.AddSwaggerGen(x =>
    {
        string sApiXml = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "Api.xml");
        x.IncludeXmlComments(sApiXml);
        x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "JWT Authorization",
        });
        x.AddSecurityRequirement(
        new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer",
                    },
                },
                new string[] { }
            },
        });
    });

    builder.Services.AddCors(options =>
    {
        options.AddPolicy("NET", policy =>
        {
            // 允許的domain
            policy.WithOrigins("http://localhost:8081")
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials();
        });
    });

    #region 驗證合法有效的 JWT Token
    builder.Services
        .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true, // 是否要啟用驗證發行者
                ValidIssuer = builder.Configuration["Jwt:Issuer"], // 配置驗證發行者
                ValidateAudience = true, // 是否要啟用驗證接收者
                ValidAudience = builder.Configuration["Jwt:Audience"], // 配置驗證接收者
                ValidateLifetime = true, // 是否要啟用驗證有效時間
                ValidateIssuerSigningKey = true, // 是否驗證SecurityKey
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])) // 配置簽章驗證用金鑰
            };
        });
    #endregion

    builder.Services.AddDbContext<CEntityContext>();

    #region 定義快取機制(使用 Redis Server 或 內存記憶體)
    // Redis Server
    builder.Services.AddDistributedRedisCache(option =>
    {
        option.Configuration = builder.Configuration["Redis:Connection"];
    });

    ////// 本機記憶體
    ////builder.Services.AddDistributedMemoryCache();

    // 加入Session服務
    builder.Services.AddSession();
    #endregion

    #region 共用功能(依據專案不同做調整)
    builder.Services.AddScoped<IGetUserInfo, CGetUserInfo>();
    builder.Services.AddScoped<IDoLoginLog, CDoLoginLog>();
    builder.Services.AddScoped<ISetResponse, CSetResponse>();

    // 判斷帳號是否有權限
    builder.Services.AddAuthorization(option =>
    {
        option.DefaultPolicy = new AuthorizationPolicyBuilder()
            .AddRequirements(new DoAuthRequirement())
            .Build();
    });

    builder.Services.AddScoped<IAuthorizationMiddlewareResultHandler, DoAuthMiddlewareResultHandler>();
    builder.Services.AddScoped<IAuthorizationHandler, DoAuthHandler>();
    builder.Services.AddScoped<IDoAuthProvider, CDoAuthProvider>();
    // ----------------------
    #endregion

    #region 登入
    builder.Services.AddScoped<ILogin, CLogin>();
    builder.Services.AddScoped<ISysLogLogin, CSysLogLogin>();
    #endregion

    #region User (使用者管理)
    builder.Services.AddScoped<IUserInfo, CUserInfo>();
    builder.Services.AddScoped<IUserInfoAuth, CUserInfoAuth>();
    builder.Services.AddScoped<IUserInfoControl, CUserInfoControl>();
    builder.Services.AddScoped<IUserInfoPassword, CUserInfoPassword>();
    builder.Services.AddScoped<IUserRole, CUserRole>();
    builder.Services.AddScoped<IUserRoleAuth, CUserRoleAuth>();
    builder.Services.AddScoped<IUserRoleControl, CUserRoleControl>();
    builder.Services.AddScoped<IUserRoleMember, CUserRoleMember>();
    #endregion

    #region Sys (選單管理)
    builder.Services.AddScoped<ISysModule, CSysModule>();
    builder.Services.AddScoped<ISysModuleClass, CSysModuleClass>();
    builder.Services.AddScoped<ISysModuleControl, CSysModuleControl>();
    #endregion

    #region Sys (系統管理)
    builder.Services.AddScoped<ISysCodeDetail, CSysCodeDetail>();
    builder.Services.AddScoped<ISysCodeMain, CSysCodeMain>();
    builder.Services.AddScoped<ISysLogError, CSysLogError>();
    builder.Services.AddScoped<ISysLogExecute, CSysLogExecute>();
    builder.Services.AddScoped<ISysLogLogin, CSysLogLogin>();
    builder.Services.AddScoped<ISysLogTrajectory, CSysLogTrajectory>();
    builder.Services.AddScoped<ISysParameter, CSysParameter>();
    #endregion

    #region 共用功能(所有專案都可使用的)
    builder.Services.AddScoped<IDoAES, CDoAES>();
    builder.Services.AddScoped<IDoJson, CDoJson>();
    builder.Services.AddScoped<IDoNLog, CDoNLog>();
    builder.Services.AddScoped<IGetSnowflakeId, CGetSnowflakeId>();

    // 取用HttpContext相關資訊
    builder.Services.AddHttpContextAccessor();
    builder.Services.AddScoped<IGetRequestInfo, CGetRequestInfo>();
    // ----------------------
    #endregion

    #region 設定Endpoint模型驗證的錯誤回傳格式
    builder.Services.Configure<ApiBehaviorOptions>(options =>
    {
        string sMsg = "";

        options.InvalidModelStateResponseFactory = (context) =>
        {
            foreach (var key in context.ModelState.Keys)
            {
                var errors = context.ModelState[key].Errors;

                if (errors.Count() > 0)
                {
                    sMsg = errors[0].ErrorMessage;
                    break;
                }
            }

            // 回傳前端模糊訊息
            COut_Response cOut_Response = new COut_Response();

            cOut_Response.Data = "";
            cOut_Response.Message = ResponseCode.Code501.fnGetDescription();
            cOut_Response.Status = ((int)ResponseCode.Code501).ToString();

            return new JsonResult(cOut_Response);
        };
    });
    #endregion

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    app.UseSwagger();
    app.UseSwaggerUI();

    // Middleware of Https
    app.UseHttpsRedirection();

    app.UseCors("NET");

    // 驗證 & 授權
    app.UseAuthentication();
    app.UseAuthorization();

    // 將 SessionMiddleware 加入 Pipeline
    app.UseSession();

    app.Use(async (context, next) =>
    {
        // 回傳前端模糊訊息
        COut_Response cOut_Response = new COut_Response();

        var currentEndpoint = context.GetEndpoint();

        if (currentEndpoint is null)
        {
            await next(context);

            // 回傳前端模糊訊息
            cOut_Response.Data = "";
            cOut_Response.Message = ResponseCode.Code501.fnGetDescription();
            cOut_Response.Status = ((int)ResponseCode.Code501).ToString();

            await context.Response.WriteAsJsonAsync(cOut_Response);
            return;
        }

        await next(context);
    });

    // 加入RequireAuthorization，表示每一個終端都要執行預設的Policy
    app.MapControllers().RequireAuthorization();

    app.Run();
}
catch (Exception ex)
{
    // 捕獲設定錯誤的錯誤紀錄
    logger.Error(ex, "發生錯誤，program停止啟動。");

    throw;
}
finally
{
    // 須確定在關閉時，把NLog關閉
    LogManager.Shutdown();
}