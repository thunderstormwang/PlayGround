using System.ComponentModel.DataAnnotations;

namespace NetCoreWebApiPlayGround.Models
{
    public class LoginRequest : IOtpCode
    {
        [Required]
        public string AccountId { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string OtpCode { get; set; }
    }
}