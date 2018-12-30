using System.ComponentModel.DataAnnotations;

namespace WebAPI2_Test.Models
{
    public class InputValidate
    {
        [MinLength(5)]
        [Required]
        public string Name { get; set; }

        [MinLength(5)]
        [Required]
        public string TransactionNumber { get; set; }
    }
}