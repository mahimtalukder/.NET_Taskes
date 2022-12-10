using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PostComment.Controllers
{
    [EnableCors("*","*","*")]
    public class PostController : ApiController
    {
        [HttpGet]
        [Route("api/post/all")]
        public HttpResponseMessage Get()
        {
            var data = PostServices.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost]
        [Route("api/post/add")]
        public HttpResponseMessage Add(PostDTO data)
        {
            var res = PostServices.Add(data);
            if(res != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
