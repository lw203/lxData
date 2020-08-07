using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lx.Infrastruct.Data.Migrations
{
    public partial class Init20200804 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LX_LOGIN_USER",
                columns: table => new
                {
                    I_ID = table.Column<Guid>(nullable: false),
                    C_LOGINNAME = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    C_PASSWORD = table.Column<string>(type: "varchar(100)", maxLength: 32, nullable: false),
                    C_NICENAME = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    i_LOCK = table.Column<int>(nullable: false),
                    D_CREATETIME = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LX_LOGIN_USER", x => x.I_ID);
                });

            migrationBuilder.CreateTable(
                name: "MERCHANT_ACCOUNT",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    NICKNAME = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    PHONE = table.Column<string>(type: "varchar(20)", maxLength: 32, nullable: false),
                    EMAIL = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    PASSWORD = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    AVATAR = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    CREATETIME = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MERCHANT_ACCOUNT", x => x.ID);
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

            migrationBuilder.CreateIndex(
                name: "IX_LX_LOGIN_USER_D_CREATETIME",
                table: "LX_LOGIN_USER",
                column: "D_CREATETIME");

            migrationBuilder.CreateIndex(
                name: "IX_MERCHANT_ACCOUNT_CREATETIME",
                table: "MERCHANT_ACCOUNT",
                column: "CREATETIME");

            migrationBuilder.CreateIndex(
                name: "IX_MERCHANT_ACCOUNT_NICKNAME",
                table: "MERCHANT_ACCOUNT",
                column: "NICKNAME");

            migrationBuilder.CreateIndex(
                name: "IX_MERCHANT_ACCOUNT_PHONE",
                table: "MERCHANT_ACCOUNT",
                column: "PHONE");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LX_LOGIN_USER");

            migrationBuilder.DropTable(
                name: "MERCHANT_ACCOUNT");

            migrationBuilder.DropTable(
                name: "STUDENT");
        }
    }
}
