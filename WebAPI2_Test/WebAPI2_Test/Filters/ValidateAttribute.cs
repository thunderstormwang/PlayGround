using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using WebAPI2_Test.Models;

namespace WebAPI2_Test.Filters
{
    public class ValidateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.ModelState.IsValid)
            {
                return;
            }
            String errorMessage = String.Join(";", actionContext.ModelState.Values
                .SelectMany(state => state.Errors)
                .Where(error => !String.IsNullOrEmpty(error.ErrorMessage))
                .Select(error => error.ErrorMessage));

            var response = new BaseResponse<string>
            {
                Status = false,
                ErrorMessage = errorMessage,
                Data = "Success"
            };

            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.OK, response);
            return;
        }
    }
}
