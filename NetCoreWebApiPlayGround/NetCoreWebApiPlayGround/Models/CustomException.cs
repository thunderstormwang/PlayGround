using System;
using System.Net;
using NetCoreWebApiPlayGround.Extensions;

namespace NetCoreWebApiPlayGround.Models
{
    public class CustomException : Exception
    {
        /// <summary>
        /// Origin http status code
        /// </summary>
        public HttpStatusCode HttpStatusCode { get; set; }

        /// <summary>
        /// system status code
        /// </summary>
        public ResultCode ResultCode { get; }

        /// <summary>
        /// 自定義的 Result Code
        /// </summary>
        public string CustomResultCode { get; set; }

        /// <summary>
        /// 自定義 Exception Message
        /// </summary>
        public string CustomMessage { get; set; }

        public bool HasCustomObjet { get; set; }

        /// <summary>
        /// 自定義 Exception object
        /// </summary>
        public object CustomObjet { get; set; }

        /// <summary>
        /// The exception
        /// </summary>
        private readonly Exception _exception;

        public CustomException(ResultCode resultCode,
            string exMessage,
            Exception ex = null)
            : base(exMessage,
                ex)
        {
            _exception = ex;
            CustomResultCode = resultCode.GetEnumDescription();
            CustomMessage = exMessage;
        }

        public CustomException(string exResultCode,
            string exMessage,
            Exception ex = null)
            : base(string.Empty,
                ex)
        {
            _exception = ex;
            CustomResultCode = exResultCode;
            CustomMessage = exMessage;
        }

        public CustomException(string exResultCode,
            string exMessage,
            object obj,
            Exception ex = null)
            : base(string.Empty,
                ex)
        {
            _exception = ex;
            CustomResultCode = exResultCode;
            CustomMessage = exMessage;
            HasCustomObjet = true;
            CustomObjet = obj;
        }

        /// <summary>
        /// Gets the real exception.
        /// </summary>
        /// <returns></returns>
        public Exception GetRealException()
        {
            if (_exception == null)
            {
                return this;
            }

            return _exception;
        }
    }
}