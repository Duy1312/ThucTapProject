using System.ComponentModel.DataAnnotations;

namespace ThucTapQuanLyPhatTu.Entity
{
    public class KieuThanhVien
    {
        [Key]
        public int KieuThanhVienId { get; set; }
        public string Code { get; set; }
        public string TenKieu { get; set; }
    }
}
