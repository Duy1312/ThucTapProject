using ThucTapQuanLyPhatTu.Seeder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using Npgsql;
using System.Collections.Generic;
using System;
using ThucTapQuanLyPhatTu.Entity;

namespace ThucTapQuanLyPhatTu.Models
{
    public class AppDbContext : DbContext 
    {
        private readonly IConfiguration _configuration;
        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Chuas> chuas { get; set; }
        public DbSet<Token> Token { get; set; }
        public DbSet<PhatTu> phatTus { get; set; }
  

        public DbSet<DaoTrangs> daoTrangs { get; set; }

        public DbSet<DonDangKy> donDangKies { get; set; }
    
        public DbSet<KieuThanhVien> kieuThanhViens { get; set; }
      

        public DbSet<PhatTuDaoTrang> phatTuDaoTrangs { get; set; }



        public static void UpdateDatabase(AppDbContext context)
        {
            context.Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var sqlConnection = "Server=localhost;Port=3306;Database=QuanLyPhatTu;Uid=root;Pwd=1234!;MaximumPoolSize=500;";
                optionsBuilder.UseMySql(sqlConnection,
                    MySqlServerVersion.LatestSupportedServerVersion);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region User
            new UserSeeder(modelBuilder).SeedData();
            #endregion
     
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}