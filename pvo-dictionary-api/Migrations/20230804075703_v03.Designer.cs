﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ThucTapQuanLyPhatTu.Models;

#nullable disable

namespace ThucTapQuanLyPhatTu.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230804075703_v03")]
    partial class v03
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ThucTapQuanLyPhatTu.Entity.Chuas", b =>
                {
                    b.Property<int>("ChuaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("NgayCapNhat")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("NgayThanhLap")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("TenChua")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("TruTriId")
                        .HasColumnType("int");

                    b.HasKey("ChuaId");

                    b.ToTable("chuas");
                });

            modelBuilder.Entity("ThucTapQuanLyPhatTu.Entity.DaoTrangs", b =>
                {
                    b.Property<int>("DaoTrangId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("DaKetThuc")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("NguoiChuTriId")
                        .HasColumnType("int");

                    b.Property<string>("NoiDung")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NoiToChuc")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("SoThanhVienThamGia")
                        .HasColumnType("int");

                    b.Property<DateTime>("ThoiGianToChuc")
                        .HasColumnType("datetime(6)");

                    b.HasKey("DaoTrangId");

                    b.HasIndex("NguoiChuTriId");

                    b.ToTable("daoTrangs");
                });

            modelBuilder.Entity("ThucTapQuanLyPhatTu.Entity.DonDangKy", b =>
                {
                    b.Property<int>("DonDangKyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("DaoTrangId")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayGuiDon")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("NgaySuLy")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("NguoiXuLyId")
                        .HasColumnType("int");

                    b.Property<int>("PhatTuId")
                        .HasColumnType("int");

                    b.Property<int>("TrangThaiDon")
                        .HasColumnType("int");

                    b.HasKey("DonDangKyId");

                    b.HasIndex("DaoTrangId");

                    b.HasIndex("PhatTuId");

                    b.ToTable("donDangKies");
                });

            modelBuilder.Entity("ThucTapQuanLyPhatTu.Entity.KieuThanhVien", b =>
                {
                    b.Property<int>("KieuThanhVienId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TenKieu")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("KieuThanhVienId");

                    b.ToTable("kieuThanhViens");
                });

            modelBuilder.Entity("ThucTapQuanLyPhatTu.Entity.PhatTu", b =>
                {
                    b.Property<int>("PhatTuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<byte[]>("AnhChup")
                        .HasColumnType("longblob");

                    b.Property<int?>("ChuaId")
                        .HasColumnType("int");

                    b.Property<bool?>("DaHoanTuc")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<int?>("GioiTinh")
                        .HasColumnType("int");

                    b.Property<string>("Ho")
                        .HasColumnType("longtext");

                    b.Property<int?>("KieuThanhVienId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("NgayCapNhat")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("NgayHoanTuc")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("NgaySinh")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("NgayXuatGia")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<string>("PhapDanh")
                        .HasColumnType("longtext");

                    b.Property<string>("Role")
                        .HasColumnType("longtext");

                    b.Property<string>("SoDienThoai")
                        .HasColumnType("longtext");

                    b.Property<string>("Ten")
                        .HasColumnType("longtext");

                    b.Property<string>("TenDem")
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext");

                    b.Property<bool?>("isActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("otp")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("otpExpirationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("status")
                        .HasColumnType("int");

                    b.HasKey("PhatTuId");

                    b.HasIndex("ChuaId");

                    b.HasIndex("KieuThanhVienId");

                    b.ToTable("phatTus");

                    b.HasData(
                        new
                        {
                            PhatTuId = 1,
                            Email = "duy@gmail.com",
                            Ho = "duy",
                            NgaySinh = new DateTime(2000, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Password = "5DC6DA3ADFE8CCF1287A98C0A8F74496",
                            PhapDanh = "duy",
                            Role = "User",
                            Ten = "duy",
                            UserName = "duy",
                            isActive = true,
                            otp = "",
                            status = 1
                        },
                        new
                        {
                            PhatTuId = 2,
                            Email = "admin@gmail.com",
                            Ho = "admin",
                            NgaySinh = new DateTime(2000, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Password = "75D23AF433E0CEA4C0E45A56DBA18B30",
                            PhapDanh = "admin",
                            Role = "Admin",
                            Ten = "admin",
                            UserName = "admin@gmail.com",
                            isActive = true,
                            otp = "",
                            status = 1
                        });
                });

            modelBuilder.Entity("ThucTapQuanLyPhatTu.Entity.PhatTuDaoTrang", b =>
                {
                    b.Property<int>("PhatTuDaoTrangId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("DaThamGia")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("DaoTrangId")
                        .HasColumnType("int");

                    b.Property<string>("LyDoKhongThamGia")
                        .HasColumnType("longtext");

                    b.Property<int?>("PhatTuId")
                        .HasColumnType("int");

                    b.HasKey("PhatTuDaoTrangId");

                    b.HasIndex("DaoTrangId");

                    b.HasIndex("PhatTuId");

                    b.ToTable("phatTuDaoTrangs");
                });

            modelBuilder.Entity("ThucTapQuanLyPhatTu.Entity.Token", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Expired")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("PhatTuId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RefreshTokenExpiry")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Revoked")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Stoken")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Token_type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PhatTuId");

                    b.ToTable("Token");
                });

            modelBuilder.Entity("ThucTapQuanLyPhatTu.Entity.DaoTrangs", b =>
                {
                    b.HasOne("ThucTapQuanLyPhatTu.Entity.PhatTu", "NguoiChuTri")
                        .WithMany()
                        .HasForeignKey("NguoiChuTriId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NguoiChuTri");
                });

            modelBuilder.Entity("ThucTapQuanLyPhatTu.Entity.DonDangKy", b =>
                {
                    b.HasOne("ThucTapQuanLyPhatTu.Entity.DaoTrangs", "DaoTrang")
                        .WithMany()
                        .HasForeignKey("DaoTrangId");

                    b.HasOne("ThucTapQuanLyPhatTu.Entity.PhatTu", "PhatTu")
                        .WithMany()
                        .HasForeignKey("PhatTuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DaoTrang");

                    b.Navigation("PhatTu");
                });

            modelBuilder.Entity("ThucTapQuanLyPhatTu.Entity.PhatTu", b =>
                {
                    b.HasOne("ThucTapQuanLyPhatTu.Entity.Chuas", "Chua")
                        .WithMany()
                        .HasForeignKey("ChuaId");

                    b.HasOne("ThucTapQuanLyPhatTu.Entity.KieuThanhVien", "KieuThanhVien")
                        .WithMany()
                        .HasForeignKey("KieuThanhVienId");

                    b.Navigation("Chua");

                    b.Navigation("KieuThanhVien");
                });

            modelBuilder.Entity("ThucTapQuanLyPhatTu.Entity.PhatTuDaoTrang", b =>
                {
                    b.HasOne("ThucTapQuanLyPhatTu.Entity.DaoTrangs", "DaoTrang")
                        .WithMany()
                        .HasForeignKey("DaoTrangId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ThucTapQuanLyPhatTu.Entity.PhatTu", "PhatTu")
                        .WithMany()
                        .HasForeignKey("PhatTuId");

                    b.Navigation("DaoTrang");

                    b.Navigation("PhatTu");
                });

            modelBuilder.Entity("ThucTapQuanLyPhatTu.Entity.Token", b =>
                {
                    b.HasOne("ThucTapQuanLyPhatTu.Entity.PhatTu", "PhatTu")
                        .WithMany()
                        .HasForeignKey("PhatTuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PhatTu");
                });
#pragma warning restore 612, 618
        }
    }
}
