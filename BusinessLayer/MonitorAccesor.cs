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
            string totalSpecs = da.Execute("Select Distinct Spec1 from Monitors") +
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

        public static string GetModelOnSpecifications(string UserQuery)
        {
            //portability and touch screen
            if (UserQuery.Contains("non-portable"))
            {
                if (UserQuery.Contains("4.5'") && UserQuery.Contains("touch screen"))
                    return da.Execute(
                        "Select ModelNo from Monitors where Spec1='Non-Portable' and Spec2='4.5'' Touch Screen'");

                if (UserQuery.Contains("5.5'") && UserQuery.Contains("touch screen"))
                    return da.Execute(
                        "Select ModelNo from Monitors where Spec1='Non-Portable' and Spec2='5.5'' Touch Screen'");
                if (UserQuery.Contains("9'") && UserQuery.Contains("touch screen"))
                    return da.Execute(
                        "Select ModelNo from Monitors where Spec1='Non-Portable' and Spec2='9'' Touch Screen'");
                if (UserQuery.Contains("12'") && UserQuery.Contains("touch screen"))
                    return da.Execute(
                        "Select ModelNo from Monitors where Spec1='Non-Portable' and Spec2='12'' Touch Screen'");
                if (UserQuery.Contains("15'") && UserQuery.Contains("touch screen"))
                    return da.Execute(
                        "Select ModelNo from Monitors where Spec1='Non-Portable' and Spec2='15'' Touch Screen'");
            }

            else if (UserQuery.Contains("portable") && (UserQuery.Contains("touch screen")))
            {
                if (UserQuery.Contains("4.5'") && UserQuery.Contains("touch screen"))
                    return da.Execute(
                        "Select ModelNo from Monitors where Spec1='Portable' and Spec2='4.5'' Touch Screen'");
                if (UserQuery.Contains("5.5'") && UserQuery.Contains("touch screen"))
                    return da.Execute(
                        "Select ModelNo from Monitors where Spec1='Non-Portable' and Spec2='5.5'' Touch Screen'");
                if (UserQuery.Contains("9'") && UserQuery.Contains("touch screen"))
                    return da.Execute(
                        "Select ModelNo from Monitors where Spec1='Portable' and Spec2='9'' Touch Screen'");
                if (UserQuery.Contains("12'") && UserQuery.Contains("touch screen"))
                    return da.Execute(
                        "Select ModelNo from Monitors where Spec1='Portable' and Spec2='12'' Touch Screen'");
                if (UserQuery.Contains("15'") && UserQuery.Contains("touch screen"))
                    return da.Execute(
                        "Select ModelNo from Monitors where Spec1='Portable' and Spec2='15'' Touch Screen'");
            }

            //portability only
            if (UserQuery.Contains("non-portable") && !(UserQuery.Contains("touch screen")))
                return da.Execute("Select ModelNo from Monitors where Spec1='Non-Portable'");
            else if (UserQuery.Contains("portable") && !(UserQuery.Contains("touch screen")))
                return da.Execute("Select ModelNo from Monitors where Spec1='Portable'");


            //touch screen only
            if (UserQuery.Contains("4.5'") && UserQuery.Contains("touch screen") && !(UserQuery.Contains("portable")) &&
                !(UserQuery.Contains("non-portable")))
                return da.Execute(
                    "Select ModelNo from Monitors where Spec2='4.5'' Touch Screen'");
            if (UserQuery.Contains("5.5'") && UserQuery.Contains("touch screen") && !(UserQuery.Contains("portable")) &&
                !(UserQuery.Contains("non-portable")))
                return da.Execute(
                    "Select ModelNo from Monitors where Spec1='Non-Portable' and Spec2='5.5'' Touch Screen'");
            if (UserQuery.Contains("9'") && UserQuery.Contains("touch screen") && !(UserQuery.Contains("portable")) &&
                !(UserQuery.Contains("non-portable")))
                return da.Execute("Select ModelNo from Monitors where Spec2='9'' Touch Screen'");
            if (UserQuery.Contains("12'") && UserQuery.Contains("touch screen") && !(UserQuery.Contains("portable")) &&
                !(UserQuery.Contains("non-portable")))
                return da.Execute("Select ModelNo from Monitors where Spec2='12'' Touch Screen'");
            if (UserQuery.Contains("15'") && UserQuery.Contains("touch screen") && !(UserQuery.Contains("portable")) &&
                !(UserQuery.Contains("non-portable")))
                return da.Execute("Select ModelNo from Monitors where Spec2='15'' Touch Screen'");

            return da.Execute("Select ModelNo from Monitors where Spec1='" + UserQuery + "' or Spec2='" + UserQuery + "' or Spec3='" + UserQuery + "'");
        }
    }
}
