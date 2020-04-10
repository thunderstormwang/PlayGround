using Microsoft.AspNetCore.Mvc;
using Test_Middleware.Models;

namespace Test_Middleware.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        [HttpPost]
        [Route("Test")]
        public string Test(User user)
        {
            return $"Hello World, User: {user.ID} Password: {user.Password}";
        }
    }
}