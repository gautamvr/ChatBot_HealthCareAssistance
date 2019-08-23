using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SampleWebAPI;
//All Web APIs are derived from System.Web.Http.ApiController which is internally implements an interface called IController which is the foundation for all MVC based Apps in ASP.NET
//Web APIS are improvised versions of Service based Architectures, future of WCF.
//Some applications which are migrated to Web APIs from WCF, will create ApiControllers which internally refer to WCF components.
namespace SampleWebAPI.Controllers
{
    public class FirstExampleController : ApiController
    {
        public string GetWelcomeMessage()
        {
            return "Hello Wolrd from Web API ";
        }

        public string GetEmployee(int id)
        {
            return id + "belongs to the Employee";

        }

        [Route ("api/Customers/id")]
        public string GetCustomers(int id)
        {
            return "Customer by" + id + "was found";


        }
        [Route("api/Stuents")]
        public Stuents GetStudent()
        {
            return new Stuents
            {
                StudentNo = 111,
                CurrrentClass = 7,
                StudentName = "Akashay",
                TotalMarks = 300
            };


        }
    }
}
