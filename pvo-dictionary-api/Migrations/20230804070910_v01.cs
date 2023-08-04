using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThucTapQuanLyPhatTu.Migrations
{
    public partial class v01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "phatTus",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "otpExpirationTime",
                table: "phatTus",
                type: "datetime(6)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "otpExpirationTime",
                table: "phatTus");

            migrationBuilder.UpdateData(
                table: "phatTus",
                keyColumn: "Role",
                keyValue: null,
                column: "Role",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "phatTus",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
