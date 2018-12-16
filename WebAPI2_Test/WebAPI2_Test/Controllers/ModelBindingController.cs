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
        [HttpGet]
        public string Demo1(int id)
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
        public string Demo3(int id, [FromBody]string companyName)
        {
            return String.Format("ID: {0}, Company: {1}", id, companyName);
        }
    }
}
