using System.ComponentModel.DataAnnotations;

namespace NetCoreWebAPI_Test.Models
{
    public class BaseRequest
    {
        public int x { get; set; }

        public int y { get; set; }

        [Required]
        public string Name { get; set; }
    }
}