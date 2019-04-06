using System.Web.Http;
using WebAPI2_Test.Filters;
using WebAPI2_Test.Models;

namespace WebAPI2_Test.Controllers
{
    public class ModelValidationController : ApiController
    {
        [MyValidate]
        [HttpPost]
        public BaseResponse<string> Demo1(InputValidate input)
        {
            var response = new BaseResponse<string>
            {
                Status = true,
                ErrorMessage = string.Empty,
                Data = "Success"
            };

            return response;
        }
    }
}