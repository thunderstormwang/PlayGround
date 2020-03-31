using System.Diagnostics;
using DI_ActionFilter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DI_ActionFilter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Config2Controller : Controller
    {
        private Member Member { get; set; }

        public Config2Controller(IOptions<Member> member)
        {
            Member = member.Value;
        }

        [HttpGet]
        [Route("Test")]
        public string Test()
        {
            Debug.WriteLine($"ID: {Member.Id}");
            Debug.WriteLine($"Password: {Member.Password}");
            Debug.WriteLine($"Url0: {Member.Url[0]}");
            Debug.WriteLine($"Url1: {Member.Url[1]}");
            Debug.WriteLine($"Salary: {Member.Salary}");

            return "Hello World";
        }
    }
}