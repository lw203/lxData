using Microsoft.EntityFrameworkCore.Migrations;

namespace Lx.Infrastruct.Data.Migrations
{
    public partial class Init20200925 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TAG_PARENTID",
                table: "TAG");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_TAG_PARENTID",
                table: "TAG",
                column: "PARENTID",
                principalTable: "TAG",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
