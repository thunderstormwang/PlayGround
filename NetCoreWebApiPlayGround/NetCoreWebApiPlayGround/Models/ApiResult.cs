using System;
using NetCoreWebApiPlayGround.Extensions;

namespace NetCoreWebApiPlayGround.Models
{
    /// <summary>
    /// API回傳物件
    /// </summary>
    public class ApiResult
    {
        public bool Success { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }
        public object Result { get; set; }
        public string Timestamp { get; set; } = DateTimeOffset.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss");

        public ApiResult(ResultCode resultCode,
            string message = null,
            object result = null)
        {
            Success = resultCode == ResultCode.Success;
            Code = resultCode.GetEnumDescription();
            Message = message ?? resultCode.ToString();
            Result = result;
        }

        public ApiResult(CustomException exception)
        {
            Success = false;
            Code = exception.CustomResultCode;
            Message = exception.CustomMessage;
            Result = exception.HasCustomObjet ? exception.CustomObjet : null;
        }
    }
}