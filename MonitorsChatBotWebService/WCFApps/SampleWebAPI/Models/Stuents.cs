using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleWebAPI.Controllers
{
    public class Stuents
    {
        public int StudentNo { get; set; }
        public int CurrrentClass { get; set; }
        public string StudentName{ get; set; }
        public int TotalMarks { get; set; }
    }
}