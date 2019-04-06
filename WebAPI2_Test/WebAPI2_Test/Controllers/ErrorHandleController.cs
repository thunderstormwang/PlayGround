using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI2_Test.Filters;
using WebAPI2_Test.Models;

namespace WebAPI2_Test.Controllers
{
    public class ErrorHandleController : ApiController
    {
        [HttpGet]
        public BaseResponse<string> Demo1(int id)
        {
            if (id > 10)
            {
                throw new Exception("Parameter id too big!");
            }
            return new BaseResponse<string>() { Status = true, ErrorMessage = "Success", Data = "Hello World" };
        }

        [HttpGet]
        public HttpResponseMessage Demo2(int id)
        {
            if (id > 10)
            {
                var respMsg = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                respMsg.Content = new StringContent("Parameter id too big!");
                return respMsg;
            }

            var response = new BaseResponse<string>() { Status = true, ErrorMessage = "Success", Data = "Hello World" };
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpGet]
        public HttpResponseMessage Demo3(int id)
        {
            if (id > 10)
            {
                HttpError err = new HttpError("Parameter id too big!");
                // 可以塞一些額外錯誤資訊進去，並傳回至用戶端
                err["AdditionMsg"] = "Extra Message!!!";
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, err);
            }

            var response = new BaseResponse<string>() { Status = true, ErrorMessage = "Success", Data = "Hello World" };
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpGet]
        public BaseResponse<string> Demo4(int id)
        {
            if (id > 10)
            {
                HttpError err = new HttpError("Parameter id too big!");
                // 可以塞一些額外錯誤資訊進去，並傳回至用戶端
                err["AdditionMsg"] = "Extra Message!!!";
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.BadRequest, err));
            }

            var response = new BaseResponse<string>() { Status = true, ErrorMessage = "Success", Data = "Hello World" };
            return response;
        }

        [MyWebApiExceptionHandler]
        [HttpGet]
        public BaseResponse<string> Demo5(int id)
        {
            if (id > 10)
            {
                throw new Exception("Parameter id too big!");
            }

            var response = new BaseResponse<string>() { Status = true, ErrorMessage = "Success", Data = "Hello World" };
            return response;
        }
    }
}