using System.Collections.Generic;

namespace DI_ActionFilter.Models
{
    public class Member
    {
        public string Id { get; set; }
        public string Password { get; set; }
        public List<string> Url { get; set; }
        public decimal Salary { get; set; }
    }
}