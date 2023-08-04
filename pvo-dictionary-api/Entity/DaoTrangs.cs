using System.ComponentModel.DataAnnotations;

namespace ThucTapQuanLyPhatTu.Entity
{
    public class DaoTrangs
    {
        [Key]
        public int DaoTrangId { get; set; }
        public string NoiToChuc { get; set; }
        public int SoThanhVienThamGia { get; set; }
        public int NguoiChuTriId { get; set; }
        public PhatTu NguoiChuTri { get; set; }
        public DateTime ThoiGianToChuc { get; set; }
        public string NoiDung { get; set; }
        public bool DaKetThuc { get; set; }
    }
}
