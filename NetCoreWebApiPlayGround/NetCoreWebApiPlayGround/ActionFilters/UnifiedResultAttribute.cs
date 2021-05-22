using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NetCoreWebApiPlayGround.Models;

namespace NetCoreWebApiPlayGround.ActionFilters
{
    public class UnifiedResultAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is ObjectResult objectResult)
            {
                ApiResult apiResult;
                if (!context.ModelState.IsValid)
                {
                    var error = context.ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage)
                        .Aggregate((
                            result,
                            next) => $"{result};{next}");
                    apiResult = new ApiResult(ResultCode.ModelInvalid,
                        message: error);
                }
                else
                {
                    apiResult = new ApiResult(ResultCode.Success,
                        result: objectResult.Value);
                }

                context.Result = new ObjectResult(apiResult);
            }
        }
    }
}