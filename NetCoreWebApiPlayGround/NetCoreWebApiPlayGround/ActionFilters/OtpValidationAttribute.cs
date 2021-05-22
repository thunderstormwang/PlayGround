using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using NetCoreWebApiPlayGround.Models;

namespace NetCoreWebApiPlayGround.ActionFilters
{
    public class OtpValidationAttribute : ActionFilterAttribute
    {
        private readonly ILogger<OtpValidationAttribute> _logger;

        public OtpValidationAttribute(ILogger<OtpValidationAttribute> logger) => _logger = logger;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var otpCode = string.Empty;
            foreach (var model in context.ActionArguments.Values)
            {
                if (!(model is IOtpCode modelWithOtpCode))
                {
                    continue;
                }

                otpCode = modelWithOtpCode.OtpCode;

                var logStr = $"Retrieve OTPCode: {otpCode}";
                Debug.WriteLine(logStr);
                _logger.LogInformation(logStr);
            }

            if (otpCode != "123456")
            {
                throw new CustomException(ResultCode.CheckOtpFailed,
                    $"{ResultCode.CheckOtpFailed.ToString()}");
            }
        }
    }
}