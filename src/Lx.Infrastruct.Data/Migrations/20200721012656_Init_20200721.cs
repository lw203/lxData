using Microsoft.EntityFrameworkCore.Migrations;

namespace Lx.Infrastruct.Data.Migrations
{
    public partial class Init_20200721 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PASSWORD",
                table: "LX_LOGIN_USER",
                newName: "C_PASSWORD");

            migrationBuilder.RenameColumn(
                name: "NICENAME",
                table: "LX_LOGIN_USER",
                newName: "C_NICENAME");

            migrationBuilder.RenameColumn(
                name: "LOGINNAME",
                table: "LX_LOGIN_USER",
                newName: "C_LOGINNAME");

            migrationBuilder.RenameColumn(
                name: "LOCK",
                table: "LX_LOGIN_USER",
                newName: "i_LOCK");

            migrationBuilder.RenameColumn(
                name: "CREATETIME",
                table: "LX_LOGIN_USER",
                newName: "D_CREATETIME");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "LX_LOGIN_USER",
                newName: "I_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "C_PASSWORD",
                table: "LX_LOGIN_USER",
                newName: "PASSWORD");

            migrationBuilder.RenameColumn(
                name: "C_NICENAME",
                table: "LX_LOGIN_USER",
                newName: "NICENAME");

            migrationBuilder.RenameColumn(
                name: "C_LOGINNAME",
                table: "LX_LOGIN_USER",
                newName: "LOGINNAME");

            migrationBuilder.RenameColumn(
                name: "i_LOCK",
                table: "LX_LOGIN_USER",
                newName: "LOCK");

            migrationBuilder.RenameColumn(
                name: "D_CREATETIME",
                table: "LX_LOGIN_USER",
                newName: "CREATETIME");

            migrationBuilder.RenameColumn(
                name: "I_ID",
                table: "LX_LOGIN_USER",
                newName: "ID");
        }
    }
}
