using System.ComponentModel.DataAnnotations;

namespace Validation.Models
{
    public class RequestBase
    {
        [Required]
        [MinLength(10)]
        public string MainAccountID { get; set; }

        [Required]
        [MinLength(10)]
        public string TransactionNumber { get; set; }
    }
}