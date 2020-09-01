using Microsoft.EntityFrameworkCore.Migrations;

namespace Lx.Infrastruct.Data.Migrations
{
    public partial class Init_2020082101 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IDX_LOGIN_RECORD_MERCHANTID",
                table: "LOGIN_RECORD");

            migrationBuilder.CreateIndex(
                name: "IDX_LOGIN_RECORD_MERCHANTID",
                table: "LOGIN_RECORD",
                column: "MERCHANTID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IDX_LOGIN_RECORD_MERCHANTID",
                table: "LOGIN_RECORD");

            migrationBuilder.CreateIndex(
                name: "IDX_LOGIN_RECORD_MERCHANTID",
                table: "LOGIN_RECORD",
                column: "MERCHANTID",
                unique: true);
        }
    }
}
