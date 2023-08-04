using ThucTapQuanLyPhatTu.Entity;

namespace ThucTapQuanLyPhatTu.Request
{
    public class ThemDaoTrangRequest
    {
        public string NoiToChuc { get; set; }
        public int SoThanhVienThamGia { get; set; }
        public int NguoiChuTriId { get; set; }
       
        public DateTime ThoiGianToChuc { get; set; }
        public string NoiDung { get; set; }
        public bool DaKetThuc { get; set; }
    }
}
