using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ErrorHandle2.Filter
{
    public class AjaxFilter : FilterAttribute
    {
        public bool ReturnPartialView { get; set; }
    }
}