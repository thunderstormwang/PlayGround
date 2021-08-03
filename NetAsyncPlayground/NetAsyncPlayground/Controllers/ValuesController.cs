using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using Utility;

namespace NetAsyncPlayground.Controllers
{
    public class ValuesController : ApiController
    {
        [HttpGet]
        public string Test()
        {
            return $"Hello World";
        }
    }
}
