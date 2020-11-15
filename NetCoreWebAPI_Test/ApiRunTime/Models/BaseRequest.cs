using System.ComponentModel.DataAnnotations;

namespace ApiRunTime.Models
{
    public class BaseRequest
    {
        public int X { get; set; }

        public int Y { get; set; }

        [Required]
        public string Name { get; set; }
    }
}