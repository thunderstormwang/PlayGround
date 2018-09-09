using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ErrorHandle2.Models
{
    public class ViewModelError
    {
        public string Message { get; set; }

        public string StackTrace { get; set; }

        public Exception Exception { get; set; }
    }
}