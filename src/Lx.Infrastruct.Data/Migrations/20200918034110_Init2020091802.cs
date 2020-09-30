using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lx.Infrastruct.Data.Migrations
{
    public partial class Init2020091802 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PEOPLE",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CREATETIME = table.Column<DateTime>(type: "date", nullable: false),
                    CREATEID = table.Column<Guid>(nullable: true),
                    LASTUPDATETIME = table.Column<string>(type: "varchar(100)", nullable: true),
                    UPDATEID = table.Column<Guid>(nullable: true),
                    PEOPLENAME = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    DYNASTY = table.Column<int>(type: "varchar(50)", maxLength: 50, nullable: false),
                    SORT = table.Column<int>(type: "varchar(50)", maxLength: 50, nullable: false),
                    EXPLAIN = table.Column<string>(type: "varchar(4000)", maxLength: 100, nullable: true),
                    STATUS = table.Column<int>(type: "varchar(20)", maxLength: 20, nullable: false),
                    CHECKID = table.Column<Guid>(nullable: true),
                    CHECKTIME = table.Column<DateTime>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PEOPLE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "USER_ACCOUNT",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CREATETIME = table.Column<DateTime>(type: "date", nullable: false),
                    CreateId = table.Column<Guid>(nullable: true),
                    LASTUPDATETIME = table.Column<string>(type: "varchar(200)", nullable: true),
                    UpdateId = table.Column<Guid>(nullable: true),
                    USERNAME = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    PHONE = table.Column<string>(type: "varchar(20)", maxLength: 32, nullable: true),
                    NICKNAME = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    EMAIL = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    PASSWORD = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    AVATAR = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_ACCOUNT", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PEOPLE_DETAIL",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CREATETIME = table.Column<DateTime>(type: "date", nullable: false),
                    CREATEID = table.Column<Guid>(nullable: true),
                    LASTUPDATETIME = table.Column<string>(type: "varchar(200)", nullable: true),
                    UPDATEID = table.Column<Guid>(nullable: true),
                    TITLE = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    SUBTITLE = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    CONTENT = table.Column<string>(type: "varchar(4000)", maxLength: 4000, nullable: true),
                    CHECKID = table.Column<Guid>(nullable: true),
                    CHECKTIME = table.Column<DateTime>(type: "date", nullable: true),
                    PEOPLEID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IDX_PEOPLE_DETAIL_ID", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PEOPLEID",
                        column: x => x.PEOPLEID,
                        principalTable: "PEOPLE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LOGIN_RECORD",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CREATETIME = table.Column<DateTime>(type: "date", nullable: false),
                    CreateId = table.Column<Guid>(nullable: true),
                    LASTUPDATETIME = table.Column<string>(type: "varchar(200)", nullable: true),
                    UpdateId = table.Column<Guid>(nullable: true),
                    IP = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    AREA = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    BROWER = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    OS = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    USERID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IDX_LOGIN_RECORD_ID", x => x.ID);
                    table.ForeignKey(
                        name: "FK_USERID",
                        column: x => x.USERID,
                        principalTable: "USER_ACCOUNT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IDX_LOGIN_RECORD_CREATETIME",
                table: "LOGIN_RECORD",
                column: "CREATETIME");

            migrationBuilder.CreateIndex(
                name: "IDX_LOGIN_RECORD_USERID",
                table: "LOGIN_RECORD",
                column: "USERID");

            migrationBuilder.CreateIndex(
                name: "IDX_PEOPLE_CREATETIME",
                table: "PEOPLE",
                column: "CREATETIME");

            migrationBuilder.CreateIndex(
                name: "IDX_PEOPLE_DYNASTY",
                table: "PEOPLE",
                column: "DYNASTY");

            migrationBuilder.CreateIndex(
                name: "IDX_PEOPLE_NAME",
                table: "PEOPLE",
                column: "PEOPLENAME");

            migrationBuilder.CreateIndex(
                name: "IDX_PEOPLE_DETAIL_CREATETIME",
                table: "PEOPLE_DETAIL",
                column: "CREATETIME");

            migrationBuilder.CreateIndex(
                name: "IDX_PEOPLE_DETAIL_PEOPLEID",
                table: "PEOPLE_DETAIL",
                column: "PEOPLEID");

            migrationBuilder.CreateIndex(
                name: "IDX_USER_ACCOUNT_CTIME",
                table: "USER_ACCOUNT",
                column: "CREATETIME");

            migrationBuilder.CreateIndex(
                name: "IDX_USER_ACCOUNT_PHONE",
                table: "USER_ACCOUNT",
                column: "PHONE");

            migrationBuilder.CreateIndex(
                name: "IDX_USER_ACCOUNT_USERNAME",
                table: "USER_ACCOUNT",
                column: "USERNAME");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LOGIN_RECORD");

            migrationBuilder.DropTable(
                name: "PEOPLE_DETAIL");

            migrationBuilder.DropTable(
                name: "USER_ACCOUNT");

            migrationBuilder.DropTable(
                name: "PEOPLE");
        }
    }
}
