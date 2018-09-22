using System.ComponentModel.DataAnnotations;

namespace InputValidation.Models
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