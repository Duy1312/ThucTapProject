using System.ComponentModel.DataAnnotations;

namespace ThucTapQuanLyPhatTu.Request
{
    public class AdminLoginRequest
    {
        [Required, EmailAddress]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
