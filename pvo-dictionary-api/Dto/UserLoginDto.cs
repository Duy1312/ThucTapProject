using ThucTapQuanLyPhatTu.Entity;
using ThucTapQuanLyPhatTu.Models;

namespace ThucTapQuanLyPhatTu.Dto
{
    public class UserLoginDto
    {
        public string token { get; set; }
        public PhatTu user { get; set; }
    }
}
