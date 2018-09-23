using InputValidation.DataAnnotations;

namespace InputValidation.Models
{
    public class Person
    {
        [AtLeastOneRequired("Email", "Fax", "Phone", ErrorMessage = "At least Email, Fax or Phone is required")]
        public string Email { get; set; }

        public string Fax { get; set; }

        public string Phone { get; set; }
    }
}