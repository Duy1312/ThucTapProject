using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThucTapQuanLyPhatTu.Migrations
{
    public partial class v69 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_donDangKies_phatTus_PhatTuId",
                table: "donDangKies");

            migrationBuilder.AlterColumn<int>(
                name: "TrangThaiDon",
                table: "donDangKies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PhatTuId",
                table: "donDangKies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgaySuLy",
                table: "donDangKies",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayGuiDon",
                table: "donDangKies",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AddForeignKey(
                name: "FK_donDangKies_phatTus_PhatTuId",
                table: "donDangKies",
                column: "PhatTuId",
                principalTable: "phatTus",
                principalColumn: "PhatTuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_donDangKies_phatTus_PhatTuId",
                table: "donDangKies");

            migrationBuilder.AlterColumn<int>(
                name: "TrangThaiDon",
                table: "donDangKies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PhatTuId",
                table: "donDangKies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgaySuLy",
                table: "donDangKies",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayGuiDon",
                table: "donDangKies",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_donDangKies_phatTus_PhatTuId",
                table: "donDangKies",
                column: "PhatTuId",
                principalTable: "phatTus",
                principalColumn: "PhatTuId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
