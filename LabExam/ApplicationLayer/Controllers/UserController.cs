using ApplicationLayer.Auth;
using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApplicationLayer.Controllers
{
    public class UserController : ApiController
    {
        [Route("api/user/add")]
        [HttpPost]
        public HttpResponseMessage Add(UserDTO user)
        {
            user.Type = 2;
            var data = UserService.Add(user);
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }
        [Route("api/user/getAll")]
        [HttpGet]
        [IsLoggedAdmin]
        public HttpResponseMessage Get()
        {
            var data = UserService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }

        [Route("api/user/get/{id}")]
        [HttpGet]
        [IsLogged]
        public HttpResponseMessage Get(int Id)
        {
            var data = UserService.Get(Id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
