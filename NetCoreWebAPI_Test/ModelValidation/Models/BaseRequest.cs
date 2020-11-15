using System.ComponentModel.DataAnnotations;

namespace ModelValidation.Models
{
    public class BaseRequest
    {
        [Range(0,10)]
        public int X { get; set; }

        [Range(0,10)]
        public int Y { get; set; }

        // [Required]
        // public string Name { get; set; }
    }
}