using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetCoreWebAPI_Test.Filters;
using NetCoreWebAPI_Test.Models;

namespace NetCoreWebAPI_Test.Controllers
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
            BaseResponse<string> result = new BaseResponse<string>
            {
                Status = true,
                ErrorMessage = string.Empty,
                Data = $"Hello, {name}"
            };
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

        // 區域註冊
        //[MyValidation]
        // 如果希望該 Filter 可以被 DI, 要這樣寫 
        //[ServiceFilter(typeof(MyExceptionHandlerAttribute)]
        [HttpGet("Minus")]
        public BaseResponse<int> Minus([FromQuery]BaseRequest input)
        {
            throw new NotImplementedException();
        }

        [HttpPost("Multiply")]
        // 如果參數是用 form urlencoded, 要掛 attritube, 且指定參數來源, 跟 Web API2 不一樣
        [Consumes("application/x-www-form-urlencoded")]
        public BaseResponse<int> Multiply([FromForm]BaseRequest input)
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