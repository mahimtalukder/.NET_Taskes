using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WEB_API.Controllers
{
    public class StudentController : ApiController
    {

        public HttpResponseMessage Get()
        {
            var student = new { Id = 1, Name = "Mahim", Cgpa = "3.99" };

            return Request.CreateResponse(HttpStatusCode.OK ,student);
        }

        public HttpResponseMessage Post()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Post");
        }
    }
}
