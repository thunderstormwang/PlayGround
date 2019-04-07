using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Middleware_Test.Models;
using Newtonsoft.Json;

namespace Middleware_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaculateController : ControllerBase
    {
        protected ILogger _Logger;

        public CaculateController(ILogger<CaculateController> logger)
        {
            _Logger = logger;
        }

        [HttpGet("Hello")]
        public BaseResponse<string> Hello(string name)
        {
            _Logger.Log(LogLevel.Information, $"Begin Caculate/Hello, param: {name}");
            BaseResponse<string> result = new BaseResponse<string>
            {
                Status = true,
                ErrorMessage = string.Empty,
                Data = $"Hello, {name}"
            };
            _Logger.Log(LogLevel.Information, $"End Caculate/Hello, response: {JsonConvert.SerializeObject(result)}");
            return result;
        }

        [HttpGet("Add")]
        public BaseResponse<int> Add([FromQuery]BaseRequest input)
        {
            BaseResponse<int> result = new BaseResponse<int>
            {
                Status = true,
                ErrorMessage = string.Empty,
                Data = input.X + input.Y
            };

            return result;
        }

        [HttpGet("Minus")]
        public BaseResponse<int> Minus([FromQuery]BaseRequest input)
        {
            throw new NotImplementedException();
        }

        [HttpPost("Multiply")]
        //[Consumes("application/x-www-form-urlencoded")]
        public BaseResponse<int> Multiply(BaseRequest input)
        {
            BaseResponse<int> result = new BaseResponse<int>
            {
                Status = true,
                ErrorMessage = string.Empty,
                Data = input.X * input.Y
            };

            throw new NotImplementedException();
            return result;
        }
    }
}