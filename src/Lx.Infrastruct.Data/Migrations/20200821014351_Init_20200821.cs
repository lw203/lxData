using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lx.Infrastruct.Data.Migrations
{
    public partial class Init_20200821 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MERCHANT_ACCOUNT",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CREATETIME = table.Column<DateTime>(type: "date", nullable: false),
                    LASTUPDATETIME = table.Column<string>(type: "varchar(200)", nullable: true),
                    NICKNAME = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    PHONE = table.Column<string>(type: "varchar(20)", maxLength: 32, nullable: true),
                    EMAIL = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    PASSWORD = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    AVATAR = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MERCHANT_ACCOUNT", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LOGIN_RECORD",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CREATETIME = table.Column<DateTime>(type: "date", nullable: false),
                    LASTUPDATETIME = table.Column<string>(type: "varchar(200)", nullable: true),
                    IP = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    AREA = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    BROWER = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    OS = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    MERCHANTID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IDX_LOGIN_RECORD_ID", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MERCHANTID",
                        column: x => x.MERCHANTID,
                        principalTable: "MERCHANT_ACCOUNT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IDX_LOGIN_RECORD_CREATETIME",
                table: "LOGIN_RECORD",
                column: "CREATETIME");

            migrationBuilder.CreateIndex(
                name: "IDX_LOGIN_RECORD_MERCHANTID",
                table: "LOGIN_RECORD",
                column: "MERCHANTID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IDX_MERCHANT_ACCOUNT_CTIME",
                table: "MERCHANT_ACCOUNT",
                column: "CREATETIME");

            migrationBuilder.CreateIndex(
                name: "IDX_MERCHANT_ACCOUNT_NICKNAME",
                table: "MERCHANT_ACCOUNT",
                column: "NICKNAME");

            migrationBuilder.CreateIndex(
                name: "IDX_MERCHANT_ACCOUNT_PHONE",
                table: "MERCHANT_ACCOUNT",
                column: "PHONE");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LOGIN_RECORD");

            migrationBuilder.DropTable(
                name: "MERCHANT_ACCOUNT");
        }
    }
}
