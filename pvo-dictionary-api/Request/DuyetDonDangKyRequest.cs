using System.ComponentModel.DataAnnotations;
using ThucTapQuanLyPhatTu.Common.Enum;
using ThucTapQuanLyPhatTu.Entity;

namespace ThucTapQuanLyPhatTu.Request
{
    public class DuyetDonDangKyRequest
    {

        public int DonDangKyId { get; set; }

 
        public TrangThaiDon TrangThaiDon { get; set; }
        public DateTime NgaySuLy { get; set; }

    }
}
