using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lx.Infrastruct.Data.Migrations
{
    public partial class Init20200924 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "STATUS",
                table: "PEOPLE",
                type: "varchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "varchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "SORT",
                table: "PEOPLE",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "DYNASTY",
                table: "PEOPLE",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateTable(
                name: "TAG",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CREATETIME = table.Column<DateTime>(type: "date", nullable: false),
                    CREATEID = table.Column<Guid>(nullable: true),
                    LASTUPDATETIME = table.Column<string>(type: "varchar(100)", nullable: true),
                    UPDATEID = table.Column<Guid>(nullable: true),
                    NAME = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    PARENTID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAG", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TAG_PARENTID",
                        column: x => x.PARENTID,
                        principalTable: "TAG",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IDX_PARENTID",
                table: "TAG",
                column: "PARENTID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TAG");

            migrationBuilder.AlterColumn<int>(
                name: "STATUS",
                table: "PEOPLE",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SORT",
                table: "PEOPLE",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DYNASTY",
                table: "PEOPLE",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
