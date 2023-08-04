using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThucTapQuanLyPhatTu.Migrations
{
    public partial class v06 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "chuas",
                columns: table => new
                {
                    ChuaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    TenChua = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NgayThanhLap = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DiaChi = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TruTriId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chuas", x => x.ChuaId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "kieuThanhViens",
                columns: table => new
                {
                    KieuThanhVienId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TenKieu = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kieuThanhViens", x => x.KieuThanhVienId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "phatTus",
                columns: table => new
                {
                    PhatTuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Ho = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TenDem = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ten = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhapDanh = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AnhChup = table.Column<byte[]>(type: "longblob", nullable: true),
                    SoDienThoai = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NgaySinh = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    NgayXuatGia = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DaHoanTuc = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    status = table.Column<int>(type: "int", nullable: true),
                    isActive = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    NgayHoanTuc = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    otp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GioiTinh = table.Column<int>(type: "int", nullable: true),
                    KieuThanhVienId = table.Column<int>(type: "int", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Role = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ChuaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phatTus", x => x.PhatTuId);
                    table.ForeignKey(
                        name: "FK_phatTus_chuas_ChuaId",
                        column: x => x.ChuaId,
                        principalTable: "chuas",
                        principalColumn: "ChuaId");
                    table.ForeignKey(
                        name: "FK_phatTus_kieuThanhViens_KieuThanhVienId",
                        column: x => x.KieuThanhVienId,
                        principalTable: "kieuThanhViens",
                        principalColumn: "KieuThanhVienId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "daoTrangs",
                columns: table => new
                {
                    DaoTrangId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NoiToChuc = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SoThanhVienThamGia = table.Column<int>(type: "int", nullable: false),
                    NguoiChuTriId = table.Column<int>(type: "int", nullable: false),
                    ThoiGianToChuc = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    NoiDung = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DaKetThuc = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_daoTrangs", x => x.DaoTrangId);
                    table.ForeignKey(
                        name: "FK_daoTrangs_phatTus_NguoiChuTriId",
                        column: x => x.NguoiChuTriId,
                        principalTable: "phatTus",
                        principalColumn: "PhatTuId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Token",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Stoken = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Expired = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Revoked = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Token_type = table.Column<int>(type: "int", nullable: false),
                    RefreshTokenExpiry = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PhatTuId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Token", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Token_phatTus_PhatTuId",
                        column: x => x.PhatTuId,
                        principalTable: "phatTus",
                        principalColumn: "PhatTuId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "donDangKies",
                columns: table => new
                {
                    DonDangKyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PhatTuId = table.Column<int>(type: "int", nullable: false),
                    TrangThaiDon = table.Column<int>(type: "int", nullable: false),
                    NgayGuiDon = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    NgaySuLy = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    NguoiXuLyId = table.Column<int>(type: "int", nullable: true),
                    DaoTrangId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_donDangKies", x => x.DonDangKyId);
                    table.ForeignKey(
                        name: "FK_donDangKies_daoTrangs_DaoTrangId",
                        column: x => x.DaoTrangId,
                        principalTable: "daoTrangs",
                        principalColumn: "DaoTrangId");
                    table.ForeignKey(
                        name: "FK_donDangKies_phatTus_PhatTuId",
                        column: x => x.PhatTuId,
                        principalTable: "phatTus",
                        principalColumn: "PhatTuId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "phatTuDaoTrangs",
                columns: table => new
                {
                    PhatTuDaoTrangId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PhatTuId = table.Column<int>(type: "int", nullable: true),
                    DaoTrangId = table.Column<int>(type: "int", nullable: false),
                    DaThamGia = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LyDoKhongThamGia = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phatTuDaoTrangs", x => x.PhatTuDaoTrangId);
                    table.ForeignKey(
                        name: "FK_phatTuDaoTrangs_daoTrangs_DaoTrangId",
                        column: x => x.DaoTrangId,
                        principalTable: "daoTrangs",
                        principalColumn: "DaoTrangId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_phatTuDaoTrangs_phatTus_PhatTuId",
                        column: x => x.PhatTuId,
                        principalTable: "phatTus",
                        principalColumn: "PhatTuId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "phatTus",
                columns: new[] { "PhatTuId", "AnhChup", "ChuaId", "DaHoanTuc", "Email", "GioiTinh", "Ho", "KieuThanhVienId", "NgayCapNhat", "NgayHoanTuc", "NgaySinh", "NgayXuatGia", "Password", "PhapDanh", "Role", "SoDienThoai", "Ten", "TenDem", "UserName", "isActive", "otp", "status" },
                values: new object[] { 1, null, null, null, "duy@gmail.com", null, "duy", null, null, null, new DateTime(2000, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "5DC6DA3ADFE8CCF1287A98C0A8F74496", "duy", "User", null, "duy", null, "duy", true, "", 1 });

            migrationBuilder.InsertData(
                table: "phatTus",
                columns: new[] { "PhatTuId", "AnhChup", "ChuaId", "DaHoanTuc", "Email", "GioiTinh", "Ho", "KieuThanhVienId", "NgayCapNhat", "NgayHoanTuc", "NgaySinh", "NgayXuatGia", "Password", "PhapDanh", "Role", "SoDienThoai", "Ten", "TenDem", "UserName", "isActive", "otp", "status" },
                values: new object[] { 2, null, null, null, "admin@gmail.com", null, "admin", null, null, null, new DateTime(2000, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "75D23AF433E0CEA4C0E45A56DBA18B30", "admin", "Admin", null, "admin", null, "admin@gmail.com", true, "", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_daoTrangs_NguoiChuTriId",
                table: "daoTrangs",
                column: "NguoiChuTriId");

            migrationBuilder.CreateIndex(
                name: "IX_donDangKies_DaoTrangId",
                table: "donDangKies",
                column: "DaoTrangId");

            migrationBuilder.CreateIndex(
                name: "IX_donDangKies_PhatTuId",
                table: "donDangKies",
                column: "PhatTuId");

            migrationBuilder.CreateIndex(
                name: "IX_phatTuDaoTrangs_DaoTrangId",
                table: "phatTuDaoTrangs",
                column: "DaoTrangId");

            migrationBuilder.CreateIndex(
                name: "IX_phatTuDaoTrangs_PhatTuId",
                table: "phatTuDaoTrangs",
                column: "PhatTuId");

            migrationBuilder.CreateIndex(
                name: "IX_phatTus_ChuaId",
                table: "phatTus",
                column: "ChuaId");

            migrationBuilder.CreateIndex(
                name: "IX_phatTus_KieuThanhVienId",
                table: "phatTus",
                column: "KieuThanhVienId");

            migrationBuilder.CreateIndex(
                name: "IX_Token_PhatTuId",
                table: "Token",
                column: "PhatTuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "donDangKies");

            migrationBuilder.DropTable(
                name: "phatTuDaoTrangs");

            migrationBuilder.DropTable(
                name: "Token");

            migrationBuilder.DropTable(
                name: "daoTrangs");

            migrationBuilder.DropTable(
                name: "phatTus");

            migrationBuilder.DropTable(
                name: "chuas");

            migrationBuilder.DropTable(
                name: "kieuThanhViens");
        }
    }
}
