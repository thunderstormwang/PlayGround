using System.ComponentModel.DataAnnotations;

namespace NetCoreWebAPI_Test.Models
{
    public class BaseRequest
    {
        public int X { get; set; }

        public int Y { get; set; }

        [Required]
        public string Name { get; set; }
    }
}