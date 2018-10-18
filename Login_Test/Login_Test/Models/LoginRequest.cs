using System.ComponentModel.DataAnnotations;

namespace Login_Test.Models
{
    public class LoginRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string PassWord { get; set; }
    }
}