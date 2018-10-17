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
    public class TestResponseController : ApiController
    {
        [HttpGet, HttpPost]
        public HttpResponseMessage ReturnDictByXml()
        {
            var data = new Dictionary<string, string>()
            {
                { "Name", "Boyu" },
                { "Company", "Gamble" },
            };

            var httpResponse = new HttpResponseMessage(HttpStatusCode.OK);
            httpResponse.Content = new ObjectContent<Dictionary<string, string>>(data, new XmlMediaTypeFormatter());

            return httpResponse;
        }

        [HttpGet, HttpPost]
        public HttpResponseMessage ReturnObjectByXml()
        {
            BaseResponse<Output> response = new BaseResponse<Output>
            {
                Status = true,
                Data = new Output
                {
                    Name = "HiHi",
                    TransactionNumber = "1234567"
                }
            };

            var httpResponse = new HttpResponseMessage(HttpStatusCode.OK);
            httpResponse.Content = new ObjectContent<BaseResponse<Output>>(response, new XmlMediaTypeFormatter());

            return httpResponse;
        }

        [HttpGet, HttpPost]
        public HttpResponseMessage ReturnDictByJson()
        {
            var data = new Dictionary<string, string>()
            {
                { "Name", "Boyu" },
                { "Company", "Gamble" },
            };

            var httpResponse = new HttpResponseMessage(HttpStatusCode.OK);
            httpResponse.Content = new ObjectContent<Dictionary<string, string>>(data, new JsonMediaTypeFormatter());

            return httpResponse;
        }

        [HttpGet, HttpPost]
        public HttpResponseMessage ReturnObjectByJson()
        {
            BaseResponse<Output> response = new BaseResponse<Output>
            {
                Status = true,
                Data = new Output
                {
                    Name = "HiHi",
                    TransactionNumber = "1234567"
                }
            };

            var httpResponse = new HttpResponseMessage(HttpStatusCode.OK);
            httpResponse.Content = new ObjectContent<BaseResponse<Output>>(response, new JsonMediaTypeFormatter());

            return httpResponse;
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
        public BaseResponse<object> ReturnObject()
        {
            BaseResponse<object> response = new BaseResponse<object>
            {
                Status = true,
                Data = new Output
                {
                    Name = "HiHi",
                    TransactionNumber = "1234567"
                }
            };

            return response;
        }
    }
}
