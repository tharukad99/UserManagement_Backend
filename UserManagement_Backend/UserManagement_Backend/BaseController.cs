using BusinessObjects.Base;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace Finap_Test_Backend.Controllers
{
    [EnableCors("AllowSpecificOrigin")]
    public class BaseController : ControllerBase
    {
        public BaseController()
        {

        }

        public APIResponce GenerateSucessMessage(object result)
        {
            APIResponce responce = new APIResponce(result, HttpStatusCode.OK, null);
            return responce;
        }

        public APIResponce GenerateExceptionMessage(object result, Exception ex)
        {
            HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;
            APIResponce responce = new APIResponce(result, httpStatusCode, ex.Message.ToString());
            return responce;
        }
    }
}