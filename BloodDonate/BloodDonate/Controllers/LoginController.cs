using BLL.DTOs;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BloodDonate.Controllers
{
    public class LoginController : ApiController
    {
        [Route("api/login")]
        [HttpPost]
        public HttpResponseMessage Login(LoginDTO login)
        {
            if(login == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Username not found");
            }
            if ( ModelState.IsValid)
            {
                var response = AuthServices.Login(login);
                if (response != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, response);

                }
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }
    }
}
