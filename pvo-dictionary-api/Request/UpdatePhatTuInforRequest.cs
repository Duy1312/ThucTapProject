using System.ComponentModel.DataAnnotations;
using System.Drawing;
using ThucTapQuanLyPhatTu.Common.Enum;
using ThucTapQuanLyPhatTu.Entity;

namespace ThucTapQuanLyPhatTu.Request
{
    

    public class UpdatePhatTuInforRequest
    {
        public string Ho { get; set; }
        public string TenDem { get; set; }
        public string Ten { get; set; }
        public string PhapDanh { get; set; }
        public byte[]? AnhChup { get; set; }
        public string SoDienThoai { get; set; }
        public DateTime? NgaySinh { get; set; }
        public DateTime? NgayXuatGia { get; set; }
        public bool? DaHoanTuc { get; set; }
        public int? status { get; set; }
        public bool? isActive { get; set; }
        public DateTime? NgayHoanTuc { get; set; }
        public GioiTinh? GioiTinh { get; set; }
        public int? KieuThanhVienId { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public int? ChuaId { get; set; }
    }
}
