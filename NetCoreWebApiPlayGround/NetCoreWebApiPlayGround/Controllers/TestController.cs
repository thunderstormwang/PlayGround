using System.Threading;
using Microsoft.AspNetCore.Mvc;
using NetCoreWebApiPlayGround.ActionFilters;
using NetCoreWebApiPlayGround.Models;

namespace NetCoreWebApiPlayGround.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : Controller
    {
        [HttpGet("Echo")]
        public string Echo()
        {
            Thread.Sleep(500);
            return "Hello World";
        }

        [HttpPost("Receive")]
        public Output Receive(Input input)
        {
            return new Output()
            {
                Info = $"AccountId: {input.AccountId}, Age: {input.Age}",
                Area = input.Long * input.Width
            };
        }
        
        [HttpPost("ThrowException")]
        public Output ThrowException(Input input)
        {
            throw new CustomException(ResultCode.OtherException, $"My Custom Error Message.");
        }
        
        [ServiceFilter(typeof(OtpValidationAttribute))]
        [HttpPost("SimulateOtpValidation")]
        public Output SimulateOtpValidation(LoginRequest input)
        {
            return new Output()
            {
                Info = $"AccountId: {input.AccountId}, Password: {input.Password}"
            };
        }
    }
}