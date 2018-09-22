using System;

namespace ErrorHandle.Models.ViewModels
{
    public class ErrorModel
    {
        public string Message { get; set; }

        public string StackTrace { get; set; }

        public Exception Exception { get; set; }
    }
}