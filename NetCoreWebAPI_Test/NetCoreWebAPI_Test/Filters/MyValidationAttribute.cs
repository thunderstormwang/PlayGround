using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NetCoreWebAPI_Test.Models;
using System;
using System.Linq;

namespace NetCoreWebAPI_Test.Filters
{
    public class MyValidationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            // 判斷 model 是不是 null
            if (actionContext.ActionArguments.Any(kv => kv.Value == null))
            {
                var errorResponse = new BaseResponse<string>
                {
                    Status = false,
                    ErrorMessage = "Arguments cannot be null",
                    Data = "Error"
                };

                actionContext.Result = new JsonResult(errorResponse);
                return;
            }

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
                Data = "Error"
            };

            actionContext.Result = new JsonResult(response);
            return;
        }
    }
}