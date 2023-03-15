using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Net_Core_Common_Model.Migrations
{
    /// <summary>
    /// Migrations_20221229_1
    /// </summary>
    public partial class _20221229_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sy_Code_Detail",
                columns: table => new
                {
                    Cfk_CodeMain_Code = table.Column<string>(type: "nvarchar(50)", nullable: false, comment: "類別代號"),
                    Ck_CodeDet_Code = table.Column<string>(type: "nvarchar(50)", nullable: true, comment: "代碼代號"),
                    CodeDet_Name = table.Column<string>(type: "nvarchar(50)", nullable: false, comment: "代碼名稱"),
                    CodeDet_Remark = table.Column<string>(type: "nvarchar(100)", nullable: true, comment: "備註"),
                    CodeDet_State = table.Column<string>(type: "nvarchar(1)", nullable: false, comment: "狀態：「0:停用，1:啟用」")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sy_Code_Detail", x => x.Cfk_CodeMain_Code);
                },
                comment: "系統代碼檔(代碼明細)");

            migrationBuilder.CreateTable(
                name: "Sys_Code_Main",
                columns: table => new
                {
                    Pk_CodeMain_Code = table.Column<string>(type: "nvarchar(50)", nullable: false, comment: "類別代號"),
                    CodeMain_Name = table.Column<string>(type: "nvarchar(50)", nullable: false, comment: "類別名稱"),
                    CodeMain_Remark = table.Column<string>(type: "nvarchar(300)", nullable: true, comment: "備註"),
                    CodeMain_State = table.Column<string>(type: "nvarchar(1)", nullable: false, comment: "狀態：「0:停用，1:啟用」"),
                    CodeMain_CreateId = table.Column<string>(type: "nvarchar(50)", nullable: false, comment: "建立者ID"),
                    CodeMain_CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "建檔日期"),
                    CodeMain_CreateIp = table.Column<string>(type: "nvarchar(30)", nullable: false, comment: "建立者IP"),
                    CodeMain_EditId = table.Column<string>(type: "nvarchar(50)", nullable: false, comment: "異動者ID"),
                    CodeMain_EditDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "異動日期"),
                    CodeMain_EditIp = table.Column<string>(type: "nvarchar(30)", nullable: false, comment: "異動者IP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_Code_Main", x => x.Pk_CodeMain_Code);
                },
                comment: "系統代碼檔(代碼類別)");

            migrationBuilder.CreateTable(
                name: "Sys_Log_Error",
                columns: table => new
                {
                    Pk_LogError = table.Column<long>(type: "bigint", nullable: false, comment: "主鍵")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogError_ExceptionType = table.Column<string>(type: "nvarchar(200)", nullable: false, comment: "Exception Type"),
                    LogError_ExceptionSource = table.Column<string>(type: "nvarchar(200)", nullable: false, comment: "Exception Source"),
                    LogError_ExceptionStackTrace = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Exception StackTrace"),
                    LogError_ExceptionTargetSite = table.Column<string>(type: "nvarchar(200)", nullable: false, comment: "Exception TargetSite"),
                    LogError_ExceptionMessage = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Exception Message"),
                    LogError_IisHost = table.Column<string>(type: "nvarchar(50)", nullable: false, comment: "IIS HOST"),
                    LogError_Agent = table.Column<string>(type: "nvarchar(200)", nullable: false, comment: "UserAgent"),
                    LogError_CreateId = table.Column<string>(type: "nvarchar(50)", nullable: false, comment: "建立者ID(Log的建立者有可能是訪客，所以型態用String)"),
                    LogError_CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "建檔日期"),
                    LogError_CreateIp = table.Column<string>(type: "nvarchar(30)", nullable: false, comment: "建立者IP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_Log_Error", x => x.Pk_LogError);
                },
                comment: "錯誤Log");

            migrationBuilder.CreateTable(
                name: "Sys_Log_Execute",
                columns: table => new
                {
                    Pk_LogExec = table.Column<long>(type: "bigint", nullable: false, comment: "主鍵")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogExec_Module = table.Column<string>(type: "nvarchar(50)", nullable: false, comment: "異動作業"),
                    LogExec_Action = table.Column<string>(type: "nvarchar(50)", nullable: false, comment: "執行動作"),
                    LogExec_ChangeItem = table.Column<string>(type: "nvarchar(200)", nullable: false, comment: "異動項目"),
                    LogExec_CreateCode = table.Column<string>(type: "nvarchar(50)", nullable: false, comment: "異動者ID"),
                    LogExec_CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "異動時間"),
                    LogExec_CreateIp = table.Column<string>(type: "nvarchar(30)", nullable: false, comment: "異動者IP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_Log_Execute", x => x.Pk_LogExec);
                },
                comment: "系統操作歷程");

            migrationBuilder.CreateTable(
                name: "Sys_Log_Login",
                columns: table => new
                {
                    Pk_LogLogin = table.Column<long>(type: "bigint", nullable: false, comment: "主鍵")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogLogin_Account = table.Column<string>(type: "nvarchar(100)", nullable: false, comment: "帳號"),
                    LogLogin_UserAgent = table.Column<string>(type: "nvarchar(200)", nullable: false, comment: "UserAgent"),
                    LogLogin_Message = table.Column<string>(type: "nvarchar(500)", nullable: false, comment: "登入訊息"),
                    LogLogin_Result = table.Column<bool>(type: "bit", nullable: false, comment: "登入成功與否 (0:失敗，1成功)"),
                    LogLogin_IisHost = table.Column<string>(type: "nvarchar(50)", nullable: false, comment: "IIS HOST"),
                    LogLogin_CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "建檔日期"),
                    LogLogin_CreateIp = table.Column<string>(type: "nvarchar(30)", nullable: false, comment: "建立者IP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_Log_Login", x => x.Pk_LogLogin);
                },
                comment: "登入Log");

            migrationBuilder.CreateTable(
                name: "Sys_Log_Trajectory",
                columns: table => new
                {
                    Pk_LogTra = table.Column<long>(type: "bigint", nullable: false, comment: "主鍵")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogTra_Group = table.Column<string>(type: "nvarchar(50)", nullable: false, comment: "Route Group"),
                    LogTra_Controller = table.Column<string>(type: "nvarchar(50)", nullable: false, comment: "Route Controller"),
                    LogTra_Action = table.Column<string>(type: "nvarchar(50)", nullable: false, comment: "Route Action"),
                    LogTra_RequestContent = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Request內容"),
                    LogTra_RequestTime = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Request時間"),
                    LogTra_ResponseContent = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Response內容"),
                    LogTra_ResponseTime = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Response時間"),
                    LogTra_IisHost = table.Column<string>(type: "nvarchar(50)", nullable: false, comment: "IIS HOST"),
                    LogTra_Agent = table.Column<string>(type: "nvarchar(200)", nullable: false, comment: "UserAgent"),
                    LogTra_CreateId = table.Column<string>(type: "nvarchar(50)", nullable: false, comment: "建立者ID(Log的建立者有可能是訪客，所以型態用String)"),
                    LogTra_CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "建檔日期"),
                    LogTra_CreateIp = table.Column<string>(type: "nvarchar(30)", nullable: false, comment: "建立者IP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_Log_Trajectory", x => x.Pk_LogTra);
                },
                comment: "程式執行Log");

            migrationBuilder.CreateTable(
                name: "Sys_Module",
                columns: table => new
                {
                    Pk_Mod = table.Column<long>(type: "bigint", nullable: false, comment: "主鍵")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_ModuleClass = table.Column<long>(type: "bigint", nullable: false, comment: "選單分類主鍵"),
                    Module_Name = table.Column<string>(type: "nvarchar(30)", nullable: false, comment: "作業名稱"),
                    Module_Route = table.Column<string>(type: "nvarchar(50)", nullable: false, comment: "作業路徑"),
                    Module_Discern = table.Column<string>(type: "nvarchar(30)", nullable: false, comment: "作業識別碼"),
                    Module_outLink = table.Column<string>(type: "nvarchar(200)", nullable: true, comment: "作業外部連結：點擊系統左側選單時，會直接跳轉外部連結"),
                    Module_StartDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "有效日期起"),
                    Module_EndDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "有效日期迄"),
                    Module_order = table.Column<decimal>(type: "decimal(9,0)", nullable: false, comment: "排序(升冪)"),
                    Module_State = table.Column<string>(type: "nvarchar(1)", nullable: false, comment: "狀態：「0:停用，1:啟用」"),
                    Module_CreateId = table.Column<string>(type: "nvarchar(50)", nullable: false, comment: "建立者ID"),
                    Module_CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "建檔日期"),
                    Module_CreateIp = table.Column<string>(type: "nvarchar(30)", nullable: false, comment: "建立者IP"),
                    Module_EditId = table.Column<string>(type: "nvarchar(50)", nullable: false, comment: "異動者ID"),
                    Module_EditDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "異動日期"),
                    Module_EditIp = table.Column<string>(type: "nvarchar(30)", nullable: false, comment: "異動者IP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_Module", x => x.Pk_Mod);
                },
                comment: "選單作業");

            migrationBuilder.CreateTable(
                name: "Sys_Module_Class",
                columns: table => new
                {
                    Pk_ModuleClass = table.Column<long>(type: "bigint", nullable: false, comment: "主鍵")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModClass_Parent = table.Column<long>(type: "bigint", nullable: false, comment: "上層分類(選單分類的主鍵)"),
                    ModClass_Name = table.Column<string>(type: "nvarchar(30)", nullable: false, comment: "分類名稱"),
                    ModClass_order = table.Column<decimal>(type: "decimal(9,0)", nullable: false, comment: "排序(升冪)"),
                    ModClass_State = table.Column<string>(type: "nvarchar(1)", nullable: false, comment: "狀態：「0:停用，1:啟用」"),
                    ModClass_CreateId = table.Column<string>(type: "nvarchar(50)", nullable: false, comment: "建立者ID"),
                    ModClass_CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "建檔日期"),
                    ModClass_CreateIp = table.Column<string>(type: "nvarchar(30)", nullable: false, comment: "建立者IP"),
                    ModClass_EditId = table.Column<string>(type: "nvarchar(50)", nullable: false, comment: "異動者ID"),
                    ModClass_EditDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "異動日期"),
                    ModClass_EditIp = table.Column<string>(type: "nvarchar(30)", nullable: false, comment: "異動者IP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_Module_Class", x => x.Pk_ModuleClass);
                },
                comment: "選單分類");

            migrationBuilder.CreateTable(
                name: "Sys_Module_Control",
                columns: table => new
                {
                    Cfk_Module = table.Column<long>(type: "bigint", nullable: false, comment: "選單作業主鍵")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ck_ModCon_Discern = table.Column<string>(type: "nvarchar(50)", nullable: false, comment: "選單作業控制項-識別碼"),
                    ModCon_Name = table.Column<string>(type: "nvarchar(50)", nullable: false, comment: "選單作業控制項-名稱")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_Module_Control", x => x.Cfk_Module);
                },
                comment: "選單作業控制項");

            migrationBuilder.CreateTable(
                name: "Sys_Parameter",
                columns: table => new
                {
                    Ck_Par_Group = table.Column<string>(type: "nvarchar(50)", nullable: false, comment: "參數群組"),
                    Ck_Par_Code = table.Column<string>(type: "nvarchar(50)", nullable: false, comment: "參數編號"),
                    Par_Name = table.Column<string>(type: "nvarchar(50)", nullable: false, comment: "參數名稱"),
                    Par_State = table.Column<string>(type: "nvarchar(1)", nullable: false, comment: "狀態：「0:停用，1:啟用」"),
                    Par_Value1 = table.Column<string>(type: "nvarchar(200)", nullable: false, comment: "值1"),
                    Par_Value2 = table.Column<string>(type: "nvarchar(200)", nullable: true, comment: "值2"),
                    Par_Value3 = table.Column<string>(type: "nvarchar(200)", nullable: true, comment: "值3"),
                    Par_Value4 = table.Column<string>(type: "nvarchar(200)", nullable: true, comment: "值4"),
                    Par_Value5 = table.Column<string>(type: "nvarchar(200)", nullable: true, comment: "值5"),
                    Par_Value6 = table.Column<string>(type: "nvarchar(200)", nullable: true, comment: "值6"),
                    Par_Value7 = table.Column<string>(type: "nvarchar(200)", nullable: true, comment: "值7"),
                    Par_Value8 = table.Column<string>(type: "nvarchar(200)", nullable: true, comment: "值8"),
                    Par_Value9 = table.Column<string>(type: "nvarchar(200)", nullable: true, comment: "值9"),
                    Par_Value10 = table.Column<string>(type: "nvarchar(200)", nullable: true, comment: "值10"),
                    Par_Remarks = table.Column<string>(type: "nvarchar(200)", nullable: true, comment: "說明"),
                    Par_CreateId = table.Column<string>(type: "nvarchar(50)", nullable: false, comment: "建立者ID"),
                    Par_CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "建檔日期"),
                    Par_CreateIp = table.Column<string>(type: "nvarchar(30)", nullable: false, comment: "建立者IP"),
                    Par_EditId = table.Column<string>(type: "nvarchar(50)", nullable: false, comment: "異動者ID"),
                    Par_EditDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "異動日期"),
                    Par_EditIp = table.Column<string>(type: "nvarchar(30)", nullable: false, comment: "異動者IP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_Parameter", x => new { x.Ck_Par_Group, x.Ck_Par_Code });
                },
                comment: "系統參數檔");

            migrationBuilder.CreateTable(
                name: "User_Info",
                columns: table => new
                {
                    Pk_Info = table.Column<long>(type: "bigint", nullable: false, comment: "主鍵")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Info_IsAd = table.Column<string>(type: "nvarchar(1)", nullable: false, comment: "帳號類別：「0:獨立，1:AD」"),
                    Info_IsAdmin = table.Column<bool>(type: "bit", nullable: true, comment: "系統管理者"),
                    Info_Name = table.Column<string>(type: "nvarchar(30)", nullable: false, comment: "姓名"),
                    Info_Email = table.Column<string>(type: "nvarchar(200)", nullable: false, comment: "信箱"),
                    Info_Account = table.Column<string>(type: "nvarchar(20)", nullable: false, comment: "登入帳號"),
                    Info_AccountAd = table.Column<string>(type: "nvarchar(50)", nullable: true, comment: "AD帳號"),
                    Info_Password = table.Column<string>(type: "nvarchar(200)", nullable: true, comment: "密碼"),
                    Info_UpdatePwDate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "更換密碼日期"),
                    Info_Lock = table.Column<bool>(type: "bit", nullable: true, comment: "帳號鎖定"),
                    Info_LockDate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "帳號鎖定時間"),
                    Info_LockIp = table.Column<string>(type: "nvarchar(30)", nullable: true, comment: "帳號鎖定IP"),
                    Info_ErrorCount = table.Column<decimal>(type: "decimal(3,0)", nullable: false, comment: "登入錯誤次數"),
                    Info_State = table.Column<string>(type: "nvarchar(1)", nullable: false, comment: "狀態：「0:停用，1:啟用」"),
                    Info_Disable = table.Column<string>(type: "nvarchar(1)", nullable: true, comment: "停用原因-選項"),
                    Info_DisableReason = table.Column<string>(type: "nvarchar(50)", nullable: true, comment: "停用原因：[選項：其他]的值"),
                    Info_StartDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "有效日期起"),
                    Info_EndDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "有效日期迄"),
                    Info_CreateId = table.Column<string>(type: "nvarchar(50)", nullable: false, comment: "建立者ID"),
                    Info_CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "建檔日期"),
                    Info_CreateIp = table.Column<string>(type: "nvarchar(30)", nullable: false, comment: "建立者IP"),
                    Info_EditId = table.Column<string>(type: "nvarchar(50)", nullable: false, comment: "異動者ID"),
                    Info_EditDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "異動日期"),
                    Info_EditIp = table.Column<string>(type: "nvarchar(30)", nullable: false, comment: "異動者IP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Info", x => x.Pk_Info);
                },
                comment: "使用者資訊");

            migrationBuilder.CreateTable(
                name: "User_Info_Auth",
                columns: table => new
                {
                    Cfk_Info = table.Column<long>(type: "bigint", nullable: false, comment: "使用者主鍵"),
                    Cfk_Module = table.Column<long>(type: "bigint", nullable: false, comment: "選單作業主鍵")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Info_Auth", x => new { x.Cfk_Info, x.Cfk_Module });
                },
                comment: "使用者作業權限");

            migrationBuilder.CreateTable(
                name: "User_Info_Control",
                columns: table => new
                {
                    Cfk_Info = table.Column<long>(type: "bigint", nullable: false, comment: "使用者主鍵"),
                    Cfk_Module = table.Column<long>(type: "bigint", nullable: false, comment: "選單作業主鍵"),
                    Cfk_ModuleControl = table.Column<string>(type: "nvarchar(50)", nullable: false, comment: "選單作業控制項")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Info_Control", x => new { x.Cfk_Info, x.Cfk_Module, x.Cfk_ModuleControl });
                });

            migrationBuilder.CreateTable(
                name: "User_Info_Password",
                columns: table => new
                {
                    Cfk_Info = table.Column<long>(type: "bigint", nullable: false, comment: "使用者主鍵"),
                    Ck_InfoPas_Sn = table.Column<long>(type: "bigint", nullable: false, comment: "流水號：記錄變更的序號"),
                    InfoPas_Password = table.Column<string>(type: "nvarchar(100)", nullable: false, comment: "新密碼"),
                    InfoPas_CreateId = table.Column<string>(type: "nvarchar(50)", nullable: false, comment: "建立者ID"),
                    InfoPas_CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "建檔日期"),
                    InfoPas_CreateIp = table.Column<string>(type: "nvarchar(30)", nullable: false, comment: "建立者IP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Info_Password", x => new { x.Cfk_Info, x.Ck_InfoPas_Sn });
                },
                comment: "使用者密碼變更記錄");

            migrationBuilder.CreateTable(
                name: "User_Role",
                columns: table => new
                {
                    Pk_Role = table.Column<long>(type: "bigint", nullable: false, comment: "主鍵")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role_Name = table.Column<string>(type: "nvarchar(30)", nullable: false, comment: "角色名稱"),
                    Role_StartDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "有效日期起"),
                    Role_EndDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "有效日期迄"),
                    Role_State = table.Column<string>(type: "nvarchar(1)", nullable: false, comment: "狀態：「0:停用，1:啟用」"),
                    Role_CreateId = table.Column<string>(type: "nvarchar(50)", nullable: false, comment: "建立者ID"),
                    Role_CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "建檔日期"),
                    Role_CreateIp = table.Column<string>(type: "nvarchar(30)", nullable: false, comment: "建立者IP"),
                    Role_EditId = table.Column<string>(type: "nvarchar(50)", nullable: false, comment: "異動者ID"),
                    Role_EditDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "異動日期"),
                    Role_EditIp = table.Column<string>(type: "nvarchar(30)", nullable: false, comment: "異動者IP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Role", x => x.Pk_Role);
                },
                comment: "使用者角色設定");

            migrationBuilder.CreateTable(
                name: "User_Role_Auth",
                columns: table => new
                {
                    Cfk_Role = table.Column<long>(type: "bigint", nullable: false, comment: "使用者角色主鍵"),
                    Cfk_Module = table.Column<long>(type: "bigint", nullable: false, comment: "選單作業主鍵")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Role_Auth", x => new { x.Cfk_Role, x.Cfk_Module });
                },
                comment: "使用者角色作業權限");

            migrationBuilder.CreateTable(
                name: "User_Role_Control",
                columns: table => new
                {
                    Cfk_Role = table.Column<long>(type: "bigint", nullable: false, comment: "角色主鍵"),
                    Cfk_Module = table.Column<long>(type: "bigint", nullable: false, comment: "選單作業主鍵"),
                    Cfk_ModuleControl = table.Column<string>(type: "nvarchar(50)", nullable: false, comment: "選單作業控制項")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Role_Control", x => new { x.Cfk_Role, x.Cfk_Module, x.Cfk_ModuleControl });
                },
                comment: "使用者角色作業控制項權限");

            migrationBuilder.CreateTable(
                name: "User_Role_Member",
                columns: table => new
                {
                    Cfk_Role = table.Column<long>(type: "bigint", nullable: false, comment: "使用者角色主鍵"),
                    Cfk_Info = table.Column<long>(type: "bigint", nullable: false, comment: "使用者主鍵")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Role_Member", x => new { x.Cfk_Role, x.Cfk_Info });
                },
                comment: "使用者角色成員");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sy_Code_Detail");

            migrationBuilder.DropTable(
                name: "Sys_Code_Main");

            migrationBuilder.DropTable(
                name: "Sys_Log_Error");

            migrationBuilder.DropTable(
                name: "Sys_Log_Execute");

            migrationBuilder.DropTable(
                name: "Sys_Log_Login");

            migrationBuilder.DropTable(
                name: "Sys_Log_Trajectory");

            migrationBuilder.DropTable(
                name: "Sys_Module");

            migrationBuilder.DropTable(
                name: "Sys_Module_Class");

            migrationBuilder.DropTable(
                name: "Sys_Module_Control");

            migrationBuilder.DropTable(
                name: "Sys_Parameter");

            migrationBuilder.DropTable(
                name: "User_Info");

            migrationBuilder.DropTable(
                name: "User_Info_Auth");

            migrationBuilder.DropTable(
                name: "User_Info_Control");

            migrationBuilder.DropTable(
                name: "User_Info_Password");

            migrationBuilder.DropTable(
                name: "User_Role");

            migrationBuilder.DropTable(
                name: "User_Role_Auth");

            migrationBuilder.DropTable(
                name: "User_Role_Control");

            migrationBuilder.DropTable(
                name: "User_Role_Member");
        }
    }
}
