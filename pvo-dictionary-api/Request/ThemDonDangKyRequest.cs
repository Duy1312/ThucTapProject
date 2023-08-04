using System.ComponentModel.DataAnnotations;
using ThucTapQuanLyPhatTu.Common.Enum;
using ThucTapQuanLyPhatTu.Entity;

namespace ThucTapQuanLyPhatTu.Request
{
    public class ThemDonDangKyRequest
    {

        public TrangThaiDon? TrangThaiDon { get; set; }
        public DateTime? NgayGuiDon { get; set; }
        public int? DaoTrangId { get; set; }
  
    }
}
