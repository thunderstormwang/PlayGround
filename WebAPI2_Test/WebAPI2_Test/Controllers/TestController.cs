using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using WebAPI2_Test.Models;

namespace WebAPI2_Test.Controllers
{
    public class TestController : ApiController
    {
        [HttpGet, HttpPost]
        public HttpResponseMessage ReturnDictByXml()
        {
            var data = new Dictionary<string, string>()
            {
                { "Name", "Boyu" },
                { "Company", "Gamble" },
            };

            var resp = new HttpResponseMessage(HttpStatusCode.OK);
            resp.Content = new ObjectContent<Dictionary<string, string>>(data, new XmlMediaTypeFormatter());

            return resp;
        }

        [HttpGet, HttpPost]
        public HttpResponseMessage ReturnObjectByXml()
        {
            Output output = new Output
            {
                Name = "HiHi",
                TransactionNumber = "1234567"
            };

            var resp = new HttpResponseMessage(HttpStatusCode.OK);
            resp.Content = new ObjectContent<Output>(output, new XmlMediaTypeFormatter());

            return resp;
        }

        [HttpGet, HttpPost]
        public HttpResponseMessage ReturnDictByJson()
        {
            var data = new Dictionary<string, string>()
            {
                { "Name", "Boyu" },
                { "Company", "Gamble" },
            };

            var resp = new HttpResponseMessage(HttpStatusCode.OK);
            resp.Content = new ObjectContent<Dictionary<string, string>>(data, new JsonMediaTypeFormatter());

            return resp;
        }

        [HttpGet, HttpPost]
        public HttpResponseMessage ReturnObjectByJson()
        {
            Output output = new Output
            {
                Name = "HiHi",
                TransactionNumber = "1234567"
            };

            var resp = new HttpResponseMessage(HttpStatusCode.OK);
            resp.Content = new ObjectContent<Output>(output, new JsonMediaTypeFormatter());

            return resp;
        }

        [HttpGet, HttpPost]
        public Dictionary<string, string> ReturnDict()
        {
            var data = new Dictionary<string, string>()
            {
                { "Name", "Boyu" },
                { "Company", "Gamble" },
            };

            return data;
        }

        [HttpGet, HttpPost]
        public Output ReturnObject()
        {
            Output output = new Output
            {
                Name = "HiHi",
                TransactionNumber = "1234567"
            };

            return output;
        }
    }
}
