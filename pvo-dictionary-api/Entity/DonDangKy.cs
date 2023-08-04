using System.ComponentModel.DataAnnotations;
using ThucTapQuanLyPhatTu.Common.Enum;

namespace ThucTapQuanLyPhatTu.Entity
{
    public class DonDangKy
    {
        [Key]
        public int DonDangKyId { get; set; }
        public int? PhatTuId { get; set; }
        public PhatTu? PhatTu { get; set; }
        public TrangThaiDon? TrangThaiDon { get; set; }
        public DateTime? NgayGuiDon { get; set; }
        public DateTime? NgaySuLy { get; set; }
        public int? NguoiXuLyId { get; set; }
        public int? DaoTrangId { get; set; }
        public DaoTrangs? DaoTrang { get; set; }
    }
}
