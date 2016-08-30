using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TrainingDiary.Controllers
{
    public class BaseController : ApiController
    {
        public IHttpActionResult HandleError(Exception exception)
        {
            return InternalServerError(exception);
        }
    }
}
