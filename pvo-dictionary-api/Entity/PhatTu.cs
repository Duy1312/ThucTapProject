using System.ComponentModel.DataAnnotations;
using ThucTapQuanLyPhatTu.Common.Enum;

namespace ThucTapQuanLyPhatTu.Entity
{
    public class PhatTu
    {
        [Key]
        public int PhatTuId { get; set; }
        public string? Ho { get; set; }
        public string? TenDem { get; set; }
        public string? Ten { get; set; }
        public string? PhapDanh { get; set; }
        public byte[]? AnhChup { get; set; }
        public string? SoDienThoai { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime? NgaySinh { get; set; }
        public DateTime? NgayXuatGia { get; set; }
        public bool? DaHoanTuc { get; set; }
        public int? status { get; set; }
        public bool? isActive { get; set; } = true;
        public DateTime? NgayHoanTuc { get; set; }
        public string? otp { get; set; } = "";
        public DateTime? otpExpirationTime { get; set; }
        public GioiTinh? GioiTinh { get; set; }
        public int? KieuThanhVienId { get; set; }
        public KieuThanhVien? KieuThanhVien { get; set; }
        public DateTime? NgayCapNhat { get; set; }
        public string? Role { get; set; } 
        public int? ChuaId { get; set; }
        public Chuas? Chua { get; set; }
    }
}
