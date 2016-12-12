using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Architecture.Web.Areas.Intranet.Controllers
{
    public class HomeController : ApiController
    {
        [HttpGet]
        public ExpandoObject Index()
        {
            dynamic employee = new ExpandoObject();
            employee.Name = "John Smith";
            employee.Age = 33;

            return employee;
        }
    }
}
