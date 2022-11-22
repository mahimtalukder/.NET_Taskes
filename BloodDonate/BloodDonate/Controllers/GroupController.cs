using BLL;
using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BloodDonate.Controllers
{
    public class GroupController : ApiController
    {
        [Route("api/groups")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = GroupServices.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/groups/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int Id)
        {
            var data = GroupServices.Get(Id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/groups/add")]
        [HttpPost]
        public HttpResponseMessage Add(GroupDTO group)
        {
            bool response = GroupServices.Add(group);
            if(response)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Inserted", data = group});

            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }
    }
}
