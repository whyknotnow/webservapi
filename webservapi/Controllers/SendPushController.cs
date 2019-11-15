using System;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using webservapi.Models;

namespace webservapi.Controllers
{
    [ApiController]
    [Route("Push")]
    public class PushController : ControllerBase
    {

        [HttpPost]
        public PushResponseModel sendPush([FromBody]PushRequestModel pushRequest)
        {

            PushResponseModel response = new PushResponseModel();
            try
            {
                var re = Request;
                var headers = re.Headers;

                if (!headers.ContainsKey("api_key"))
                {
                    Response.StatusCode = 403;
                    response.STATUS = "API key bulunamadı";
                    return response;
                }
                else
                {
                    //TODO CHECK API KEY

                }

                if (pushRequest.platform == null)
                {
                    Response.StatusCode = 400;
                    response.STATUS = "Lütfen platform belirtin";
                    return response;
                }
                else
                {
                    //TODO check platform
                }

                if (pushRequest.deviceToken == null)
                {
                    Response.StatusCode = 400;
                    response.STATUS = "Lütfen deviceToken belirtin";
                    return response;
                }

                if (pushRequest.title == null)
                {
                    Response.StatusCode = 400;
                    response.STATUS = "Lütfen title belirtin";
                    return response;
                }

                if (pushRequest.body == null)
                {
                    Response.StatusCode = 400;
                    response.STATUS = "Lütfen body belirtin";
                    return response;
                }


                response.STATUS = "SUCCESS";
                return response;
            }
            catch(Exception e)
            {
                Response.StatusCode = 500;
                response.STATUS = "Sunucu hatası, lütfen daha sonra deneyiniz.";
                return response;
            }
        }
    }
}
