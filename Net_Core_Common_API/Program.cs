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

    // �NNLog���U�즹�M�פ�
    builder.Logging.ClearProviders();

    // �]�wlog�������̤p����
    builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Information);
    builder.Host.UseNLog();

    // Add services to the container.
    builder.Services.AddControllers();

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();

    // ���U Swagger ���;�
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
            // ���\��domain
            policy.WithOrigins("http://localhost:8081")
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials();
        });
    });

    #region ���ҦX�k���Ī� JWT Token
    builder.Services
        .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true, // �O�_�n�ҥ����ҵo���
                ValidIssuer = builder.Configuration["Jwt:Issuer"], // �t�m���ҵo���
                ValidateAudience = true, // �O�_�n�ҥ����ұ�����
                ValidAudience = builder.Configuration["Jwt:Audience"], // �t�m���ұ�����
                ValidateLifetime = true, // �O�_�n�ҥ����Ҧ��Įɶ�
                ValidateIssuerSigningKey = true, // �O�_����SecurityKey
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])) // �t�mñ�����ҥΪ��_
            };
        });
    #endregion

    builder.Services.AddDbContext<CEntityContext>();

    #region �w�q�֨�����(�ϥ� Redis Server �� ���s�O����)
    // Redis Server
    builder.Services.AddDistributedRedisCache(option =>
    {
        option.Configuration = builder.Configuration["Redis:Connection"];
    });

    ////// �����O����
    ////builder.Services.AddDistributedMemoryCache();

    // �[�JSession�A��
    builder.Services.AddSession();
    #endregion

    #region �@�Υ\��(�̾ڱM�פ��P���վ�)
    builder.Services.AddScoped<IGetUserInfo, CGetUserInfo>();
    builder.Services.AddScoped<IDoLoginLog, CDoLoginLog>();
    builder.Services.AddScoped<ISetResponse, CSetResponse>();

    // �P�_�b���O�_���v��
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

    #region �n�J
    builder.Services.AddScoped<ILogin, CLogin>();
    builder.Services.AddScoped<ISysLogLogin, CSysLogLogin>();
    #endregion

    #region User (�ϥΪ̺޲z)
    builder.Services.AddScoped<IUserInfo, CUserInfo>();
    builder.Services.AddScoped<IUserInfoAuth, CUserInfoAuth>();
    builder.Services.AddScoped<IUserInfoControl, CUserInfoControl>();
    builder.Services.AddScoped<IUserInfoPassword, CUserInfoPassword>();
    builder.Services.AddScoped<IUserRole, CUserRole>();
    builder.Services.AddScoped<IUserRoleAuth, CUserRoleAuth>();
    builder.Services.AddScoped<IUserRoleControl, CUserRoleControl>();
    builder.Services.AddScoped<IUserRoleMember, CUserRoleMember>();
    #endregion

    #region Sys (���޲z)
    builder.Services.AddScoped<ISysModule, CSysModule>();
    builder.Services.AddScoped<ISysModuleClass, CSysModuleClass>();
    builder.Services.AddScoped<ISysModuleControl, CSysModuleControl>();
    #endregion

    #region Sys (�t�κ޲z)
    builder.Services.AddScoped<ISysCodeDetail, CSysCodeDetail>();
    builder.Services.AddScoped<ISysCodeMain, CSysCodeMain>();
    builder.Services.AddScoped<ISysLogError, CSysLogError>();
    builder.Services.AddScoped<ISysLogExecute, CSysLogExecute>();
    builder.Services.AddScoped<ISysLogLogin, CSysLogLogin>();
    builder.Services.AddScoped<ISysLogTrajectory, CSysLogTrajectory>();
    builder.Services.AddScoped<ISysParameter, CSysParameter>();
    #endregion

    #region �@�Υ\��(�Ҧ��M�׳��i�ϥΪ�)
    builder.Services.AddScoped<IDoAES, CDoAES>();
    builder.Services.AddScoped<IDoJson, CDoJson>();
    builder.Services.AddScoped<IDoNLog, CDoNLog>();
    builder.Services.AddScoped<IGetSnowflakeId, CGetSnowflakeId>();

    // ����HttpContext������T
    builder.Services.AddHttpContextAccessor();
    builder.Services.AddScoped<IGetRequestInfo, CGetRequestInfo>();
    // ----------------------
    #endregion

    #region �]�wEndpoint�ҫ����Ҫ����~�^�Ǯ榡
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

            // �^�ǫe�ݼҽk�T��
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

    // ���� & ���v
    app.UseAuthentication();
    app.UseAuthorization();

    // �N SessionMiddleware �[�J Pipeline
    app.UseSession();

    app.Use(async (context, next) =>
    {
        // �^�ǫe�ݼҽk�T��
        COut_Response cOut_Response = new COut_Response();

        var currentEndpoint = context.GetEndpoint();

        if (currentEndpoint is null)
        {
            await next(context);

            // �^�ǫe�ݼҽk�T��
            cOut_Response.Data = "";
            cOut_Response.Message = ResponseCode.Code501.fnGetDescription();
            cOut_Response.Status = ((int)ResponseCode.Code501).ToString();

            await context.Response.WriteAsJsonAsync(cOut_Response);
            return;
        }

        await next(context);
    });

    // �[�JRequireAuthorization�A��ܨC�@�Ӳ׺ݳ��n����w�]��Policy
    app.MapControllers().RequireAuthorization();

    app.Run();
}
catch (Exception ex)
{
    // ����]�w���~�����~����
    logger.Error(ex, "�o�Ϳ��~�Aprogram����ҰʡC");

    throw;
}
finally
{
    // ���T�w�b�����ɡA��NLog����
    LogManager.Shutdown();
}