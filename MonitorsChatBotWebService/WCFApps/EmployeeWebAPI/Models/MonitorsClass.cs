using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeWebAPI.Models
{
    public class MonitorsClass
    {
        public int Id { get; set; }
        public string SeriesName { get; set; }
        public string Category { get; set; }
        public string ModelNo { get; set; }
        public string Spec1 { get; set; }
        public string Spec2 { get; set; }
        public string Spec3 { get; set; }
        public string url { get; set; }
    }
}