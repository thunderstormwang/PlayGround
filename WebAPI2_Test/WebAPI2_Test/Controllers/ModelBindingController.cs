using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI2_Test.Models;

namespace WebAPI2_Test.Controllers
{
    public class ModelBindingController : ApiController
    {
        [Route("api/ModelBinding/Demo1/{id2}/{id}")]
        [HttpGet]
        public string Demo1(int id, int id2)
        {
            return id.ToString();
        }

        [HttpGet]
        public string Demo2(int? id = null)
        {
            if (id == null)
            {
                return "id, please!";
            }
            return id.ToString();
        }

        [HttpGet, HttpPost]
        public string Demo3([FromBody]int id)
        {
            return id.ToString();
        }

        [HttpPost]
        public string Demo4([FromBody]BaseRequest request)
        {
            return request.TransactionNumber;
        }
    }
}
