using Microsoft.EntityFrameworkCore;
using Net_Core_Common_Model.Entity.User;
using Net_Core_Common_Model.Entity.Sys;

namespace Net_Core_Common_Model.Entity
{
    /// <summary>
    /// 定義實體資料庫資訊
    /// </summary>
    public partial class CEntityContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=192.168.5.204;Initial Catalog=NET_Common;User ID=sa;Password=sa;Integrated Security=False;MultipleActiveResultSets=true;");
        }

        #region DbSet

        #region Sys
        public DbSet<CTab_SysCodeDetail> CTab_SysCodeDetail { get; set; }

        public DbSet<CTab_SysCodeMain> CTab_SysCodeMain { get; set; }

        public DbSet<CTab_SysLogError> CTab_SysLogError { get; set; }

        public DbSet<CTab_SysLogExecute> CTab_SysLogExecute { get; set; }

        public DbSet<CTab_SysLogLogin> CTab_SysLogLogin { get; set; }

        public DbSet<CTab_SysLogTrajectory> CTab_SysLogTrajectory { get; set; }

        public DbSet<CTab_SysModule> CTab_SysModule { get; set; }

        public DbSet<CTab_SysModuleClass> CTab_SysModuleClass { get; set; }

        public DbSet<CTab_SysModuleControl> CTab_SysModuleControl { get; set; }

        public DbSet<CTab_SysParameter> CTab_SysParameter { get; set; }
        #endregion

        #region User
        public DbSet<CTab_UserInfo> CTab_UserInfo { get; set; }

        public DbSet<CTab_UserInfoAuth> CTab_UserInfoAuth { get; set; }

        public DbSet<CTab_UserInfoControl> CTab_UserInfoControl { get; set; }

        public DbSet<CTab_UserInfoPassword> CTab_UserInfoPassword { get; set; }

        public DbSet<CTab_UserRole> CTab_UserRole { get; set; }

        public DbSet<CTab_UserRoleAuth> CTab_UserRoleAuth { get; set; }

        public DbSet<CTab_UserRoleControl> CTab_UserRoleControl { get; set; }

        public DbSet<CTab_UserRoleMember> CTab_UserRoleMember { get; set; }
        #endregion

        #endregion

        #region 使用Fluent API設定模型
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Sys
            modelBuilder.Entity<CTab_SysCodeDetail>().HasKey(x => new { x.Cfk_CodeMain_Code, x.Ck_CodeDet_Code });
            modelBuilder.Entity<CTab_SysModuleControl>().HasKey(x => new { x.Cfk_Module, x.ModCon_Code });
            modelBuilder.Entity<CTab_SysParameter>().HasKey(x => new { x.Ck_Par_Group, x.Ck_Par_Code });
            #endregion

            #region User
            modelBuilder.Entity<CTab_UserInfoAuth>().HasKey(x => new { x.Cfk_Info, x.Cfk_Module });
            modelBuilder.Entity<CTab_UserInfoControl>().HasKey(x => new { x.Cfk_Info, x.Cfk_Module, x.Cfk_ModuleControl });
            modelBuilder.Entity<CTab_UserInfoPassword>().HasKey(x => new { x.Cfk_Info, x.Ck_InfoPas_Sn });
            modelBuilder.Entity<CTab_UserRoleAuth>().HasKey(x => new { x.Cfk_Role, x.Cfk_Module });
            modelBuilder.Entity<CTab_UserRoleControl>().HasKey(x => new { x.Cfk_Role, x.Cfk_Module, x.Cfk_ModuleControl });
            modelBuilder.Entity<CTab_UserRoleMember>().HasKey(x => new { x.Cfk_Role, x.Cfk_Info });
            #endregion
        }
        #endregion
    }
}
