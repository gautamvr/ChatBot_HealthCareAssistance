using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    using DataLayer;
    public class MonitorAccessor
    {
        static DAL da = new DAL();
        //------------------Queries to Access the Monitor Table------------------------
        public static string GetSerialName()
        {
            return da.Execute("Select Distinct Category from Monitors");
        }

        public static string GetDistinctModelNames()
        {
            return da.Execute("Select Distinct ModelNo from Monitors");

        }

        public static string GetDistinctSpecs()
        {
            string totalSpecs = da.Execute("Select Distinct Spec1 from Monitors") +"\n"+
                                da.Execute("Select Distinct Spec2 from Monitors");

            return totalSpecs;

        }

        public static string GetModels(string s)
        {
            return da.Execute("Select ModelNo from Monitors where Category='" + s + "'");
        }

        public static string GetSpecification(string m)
        {
            return da.Execute("Select ModelNo,Spec1,Spec2,Spec3,url from Monitors where ModelNo='" + m + "'");

        }

        public static string GetModelOnSpecifications(string spec1, string spec2)
        {
            return da.Execute(
                        "Select ModelNo from Monitors where Spec1='"+spec1+"' and Spec2='"+spec2+"'");
        }
    }
}
