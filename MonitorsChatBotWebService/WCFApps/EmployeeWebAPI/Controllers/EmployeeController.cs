using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeDataAccess;

namespace EmployeeWebAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        public IEnumerable<EmpTable> Get()
        {
            using (PhilipsDBEntities entities = new PhilipsDBEntities())
            {
                return entities.EmpTables.ToList();
            }
        }

        public EmpTable Get(char id)
        {
            using (PhilipsDBEntities entities = new PhilipsDBEntities())
            {
                return entities.EmpTables.FirstOrDefault(e => e.EmpID == id);
            }
        }

    }



    public class MonitorController : ApiController
    {
        //[HttpGet]
        //public IEnumerable<Monitor> Get()
        //{
        //    using (ChatBotDBEntities entities1 = new ChatBotDBEntities())
        //    {
        //        return entities1.Monitors.ToList();
        //    }
        //}

        //[HttpGet]
        //public Monitor Get(string model)
        //{
        //    using (ChatBotDBEntities entities1 = new ChatBotDBEntities())
        //    {
        //        return entities1.Monitors.FirstOrDefault(e => (e.ModelNo).ToString().Equals(model));
        //    }
        //}

        [Route("api/Monitor/GetSeries")]
        [HttpGet]
        public HttpResponseMessage GetSeries(string name = "All")
        {
            using (ChatBotDBEntities entities = new ChatBotDBEntities())
            {
                switch (name.ToLower())
                {
                    case "all":
                        return Request.CreateResponse(HttpStatusCode.OK, entities.Monitors.ToList());
                    case "intellivue":
                        return Request.CreateResponse(HttpStatusCode.OK, entities.Monitors.Where(e => e.SeriesName.ToLower() == "intellivue").ToList());
                    case "avalon":
                        return Request.CreateResponse(HttpStatusCode.OK, entities.Monitors.Where(e => e.SeriesName.ToLower() == "avalon").ToList());
                    case "efficia":
                        return Request.CreateResponse(HttpStatusCode.OK, entities.Monitors.Where(e => e.SeriesName.ToLower() == "efficia").ToList());
                    case "suresigns":
                        return Request.CreateResponse(HttpStatusCode.OK, entities.Monitors.Where(e => e.SeriesName.ToLower() == "suresigns").ToList());
                    default:
                        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Please enter a valid name" + name + "is invalid");

                }
            }
        }

        [Route("api/Monitor/GetModel")]
        [HttpGet]
        public HttpResponseMessage GetModel(string model = "All")
        {
            using (ChatBotDBEntities entities = new ChatBotDBEntities())
            {
                switch (model.ToLower())
                {
                    case "all":
                        return Request.CreateResponse(HttpStatusCode.OK, entities.Monitors.ToList());
                    case "mx400":
                        return Request.CreateResponse(HttpStatusCode.OK, entities.Monitors.Where(e => e.ModelNo.ToLower() == "mx400").ToList());
                    case "mx450":
                        return Request.CreateResponse(HttpStatusCode.OK, entities.Monitors.Where(e => e.ModelNo.ToLower() == "mx450").ToList());
                    case "mp5":
                        return Request.CreateResponse(HttpStatusCode.OK, entities.Monitors.Where(e => e.ModelNo.ToLower() == "mp5").ToList());
                    case "suresigns":
                        return Request.CreateResponse(HttpStatusCode.OK, entities.Monitors.Where(e => e.ModelNo.ToLower() == "suresigns").ToList());
                    default:
                        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Please enter a valid name" + model + "is invalid");

                }
            }
        }



    }
}
