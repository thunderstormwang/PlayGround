using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DI_ActionFilter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConfigController : Controller
    {
        private IConfiguration Configuration { get; set; }

        public ConfigController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [HttpGet]
        [Route("Test")]
        public string Test()
        {
            Debug.WriteLine($"ID: {Configuration.GetValue<string>("Member:ID")}");
            Debug.WriteLine($"Password: {Configuration.GetValue<string>("Member:Password")}");
            Debug.WriteLine($"Url: {Configuration.GetValue<string>("Member:Url")}");
            Debug.WriteLine($"Salary: {Configuration.GetValue<string>("Member:Salary")}");

            return "Hello World";
        }
    }
}