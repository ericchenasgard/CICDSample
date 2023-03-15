using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Net_Core_Common_Model.Migrations
{
    /// <summary>
    /// Migrations_20221229_3
    /// </summary>
    public partial class _20221229_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Pk_Mod",
                table: "Sys_Module",
                newName: "Pk_Module");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Pk_Module",
                table: "Sys_Module",
                newName: "Pk_Mod");
        }
    }
}
