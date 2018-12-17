using System.Web.Http;
using WebAPI2_Test.Models;
using WebApiContrib.ModelBinders;

namespace WebAPI2_Test.Controllers
{
    [MvcStyleBinding]
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
            return string.Format("ID: {0}, Company: {1}", id, companyName);
        }

        [HttpGet]
        public string Demo4([FromUri]BaseRequest request)
        {
            return string.Format("Name: {0}, TransactionNumber: {1}", request.Name, request.TransactionNumber);
        }

        [HttpPost]
        public string Demo5(BaseRequest request)
        {
            return string.Format("Name: {0}, TransactionNumber: {1}", request.Name, request.TransactionNumber);
        }

        [HttpGet, HttpPost]
        public string Demo6(int id, BaseRequest request)
        {
            return string.Format("Name: {0}, TransactionNumber: {1}", request.Name, request.TransactionNumber);
        }

        public string Demo7(int id, BaseRequest request)
        {
            return string.Format("Name: {0}, TransactionNumber: {1}", request.Name, request.TransactionNumber);
        }

    }
}