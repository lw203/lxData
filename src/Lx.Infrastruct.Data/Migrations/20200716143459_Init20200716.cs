using Microsoft.EntityFrameworkCore.Migrations;

namespace Lx.Infrastruct.Data.Migrations
{
    public partial class Init20200716 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "STUDENT",
                newName: "BIRTHDATE");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BIRTHDATE",
                table: "STUDENT",
                newName: "BirthDate");
        }
    }
}
