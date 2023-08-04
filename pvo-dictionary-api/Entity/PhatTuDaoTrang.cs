using System.ComponentModel.DataAnnotations;

namespace ThucTapQuanLyPhatTu.Entity
{
    public class PhatTuDaoTrang
    {
        [Key]
        public int PhatTuDaoTrangId { get; set; }
        public int? PhatTuId { get; set; }
        public PhatTu? PhatTu { get; set; }
        public int DaoTrangId { get; set; }
        public DaoTrangs DaoTrang { get; set; }
        public bool DaThamGia { get; set; }
        public string? LyDoKhongThamGia { get; set; }
    }
}
