using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lx.Infrastruct.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LX_LOGIN_USER",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    LOGINNAME = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    PASSWORD = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false),
                    NICENAME = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    LOCK = table.Column<int>(nullable: false),
                    CREATETIME = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LX_LOGIN_USER", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "STUDENT",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    NAME = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    EMAIL = table.Column<string>(type: "varchar(100)", maxLength: 20, nullable: false),
                    PHONE = table.Column<string>(type: "varchar(100)", maxLength: 11, nullable: false),
                    BIRTHDATE = table.Column<DateTime>(nullable: false),
                    ADDRESS_PROVINCE = table.Column<string>(nullable: true),
                    ADDRESS_CITY = table.Column<string>(nullable: true),
                    ADDRESS_COUNTY = table.Column<string>(nullable: true),
                    ADDRESS_STREET = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STUDENT", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LX_LOGIN_USER");

            migrationBuilder.DropTable(
                name: "STUDENT");
        }
    }
}
