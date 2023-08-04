using Microsoft.EntityFrameworkCore;
using ThucTapQuanLyPhatTu.Models;
using ThucTapQuanLyPhatTu.Common;
using ThucTapQuanLyPhatTu.Entity;

namespace ThucTapQuanLyPhatTu.Seeder
{
    class UserSeeder
    {
        private readonly ModelBuilder _modelBuilder;
        public UserSeeder(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }

        /// <summary>
        /// Excute data
        /// </summary>
        public void SeedData()
        {
            _modelBuilder.Entity<PhatTu>().HasData(
                new PhatTu
                {
                    PhatTuId = 1,
                    UserName = "duy",
                    Password = Untill.CreateMD5("duy"),
                    Email = "duy@gmail.com",
                    Ten = "duy",
                    Ho = "duy",
                    NgaySinh = new DateTime(2000, 12, 13),
                    PhapDanh = "duy",
                  Role = "User",
                    status = 1,
                }
                );
            _modelBuilder.Entity<PhatTu>().HasData(
             new PhatTu
             {
                 PhatTuId = 2,
                 UserName = "admin@gmail.com",
                 Password = Untill.CreateMD5("admin@gmail.com"),
                 Email = "admin@gmail.com",
                 Ten = "admin",
                 Ho = "admin",
                 NgaySinh = new DateTime(2000, 12, 13),
                 PhapDanh = "admin",
                 Role = "Admin",
                 status = 1,
             }
             );
        }
    }
}
