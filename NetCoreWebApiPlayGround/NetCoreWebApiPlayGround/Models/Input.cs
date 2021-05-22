using System.ComponentModel.DataAnnotations;

namespace NetCoreWebApiPlayGround.Models
{
    public class Input
    {
        [Required]
        public string AccountId { get; set; }

        [Required]
        [Range(0, 120)]
        public int Age { get; set; }
        
        [Required]
        [Range(0, double.MaxValue)]
        public double Long { get; set; }
        
        [Required]
        [Range(0, double.MaxValue)]
        public double Width { get; set; }
    }
}