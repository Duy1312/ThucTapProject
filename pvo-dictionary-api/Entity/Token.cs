using OfficeOpenXml.FormulaParsing.LexicalAnalysis;
using System.ComponentModel.DataAnnotations;
using ThucTapQuanLyPhatTu.Common.Enum;

namespace ThucTapQuanLyPhatTu.Entity
{
    public class Token
    {
        [Key]
        public int Id { get; set; }
        public string Stoken { get; set; }
        public bool Expired { get; set; }
        public bool Revoked { get; set; }
        public TypeToken Token_type { get; set; }
        public DateTime RefreshTokenExpiry { get; set; }
        public int PhatTuId { get; set; }
        public PhatTu? PhatTu { get; set; }
    }
}
