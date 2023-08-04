using System.ComponentModel.DataAnnotations;

namespace ThucTapQuanLyPhatTu.Entity
{
    public class Chuas
    {
        [Key]
        public int ChuaId { get; set; }
        public DateTime? NgayCapNhat { get; set; } 
        public string TenChua { get; set; }
        public DateTime NgayThanhLap { get; set; }
        public string DiaChi { get; set; }
        public int TruTriId { get; set; }
    }
}
