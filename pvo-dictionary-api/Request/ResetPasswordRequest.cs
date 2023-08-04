using System.ComponentModel.DataAnnotations;

namespace ThucTapQuanLyPhatTu.Request
{
    public class ResetPasswordRequest
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Otp { get; set; }
        public string NewPassword{ get; set; }
    }
}
