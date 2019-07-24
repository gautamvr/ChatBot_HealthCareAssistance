using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;

namespace BusinessLayer
{
    using DataLayer;

    public class BusinessLogic
    {
        

        public static string GetSerialName()
        {
            return AccessDataBase.SetupSqlConnection("Select Distinct Category from Monitors",0);
            

        }

        public static string GetModels(string s)
        {
            return AccessDataBase.SetupSqlConnection("Select ModelNo from Monitors where Category='"+s+"'",0);
        }

        public static string GetSpecification(string s,string m)
        {
            return AccessDataBase.SetupSqlConnection("Select ModelNo,Spec1,Spec2,Spec3 from Monitors where Category='" + s + "' and ModelNo='"+m+"'",3);
        }

        public static string GetModelOnSpecifications(string UserQuery)
        {
            


            //portablity and touch screen
            if (UserQuery.Contains("non-portable"))
            {
                if (UserQuery.Contains("4.5'") && UserQuery.Contains("touch screen"))
                    return AccessDataBase.SetupSqlConnection("Select ModelNo from Monitors where Spec1='Non-Portable' and Spec2='4.5'' Touch Screen'", 0);
                if (UserQuery.Contains("5.5'") && UserQuery.Contains("touch screen"))
                    return AccessDataBase.SetupSqlConnection("Select ModelNo from Monitors where Spec1='Non-Portable' and Spec2='5.5'' Touch Screen'", 0);
                if (UserQuery.Contains("9'") && UserQuery.Contains("touch screen"))
                    return AccessDataBase.SetupSqlConnection("Select ModelNo from Monitors where Spec1='Non-Portable' and Spec2='9'' Touch Screen'", 0);
                if (UserQuery.Contains("12'") && UserQuery.Contains("touch screen"))
                    return AccessDataBase.SetupSqlConnection("Select ModelNo from Monitors where Spec1='Non-Portable' and Spec2='12'' Touch Screen'", 0);
                if (UserQuery.Contains("15'") && UserQuery.Contains("touch screen"))
                    return AccessDataBase.SetupSqlConnection("Select ModelNo from Monitors where Spec1='Non-Portable' and Spec2='15'' Touch Screen'", 0);
            }

            else if (UserQuery.Contains("portable") && !(UserQuery.Contains("touch screen")))
            {
                if (UserQuery.Contains("4.5'") && UserQuery.Contains("touch screen"))
                    return AccessDataBase.SetupSqlConnection("Select ModelNo from Monitors where Spec1='Portable' and Spec2='4.5'' Touch Screen'", 0);
                if (UserQuery.Contains("5.5'") && UserQuery.Contains("touch screen"))
                    return AccessDataBase.SetupSqlConnection("Select ModelNo from Monitors where Spec1='Non-Portable' and Spec2='5.5'' Touch Screen'", 0);
                if (UserQuery.Contains("9'") && UserQuery.Contains("touch screen"))
                    return AccessDataBase.SetupSqlConnection("Select ModelNo from Monitors where Spec1='Portable' and Spec2='9'' Touch Screen'", 0);
                if (UserQuery.Contains("12'") && UserQuery.Contains("touch screen"))
                    return AccessDataBase.SetupSqlConnection("Select ModelNo from Monitors where Spec1='Portable' and Spec2='12'' Touch Screen'", 0);
                if (UserQuery.Contains("15'") && UserQuery.Contains("touch screen"))
                    return AccessDataBase.SetupSqlConnection("Select ModelNo from Monitors where Spec1='Portable' and Spec2='15'' Touch Screen'", 0);
            }
            //portablity only
            if (UserQuery.Contains("non-portable") && !(UserQuery.Contains("touch screen")))
                return AccessDataBase.SetupSqlConnection("Select ModelNo from Monitors where Spec1='Non-Portable'", 0);
            else if (UserQuery.Contains("portable") && !(UserQuery.Contains("touch screen")))
                return AccessDataBase.SetupSqlConnection("Select ModelNo from Monitors where Spec1='Portable'", 0);


            //touch screen only
            if (UserQuery.Contains("4.5'") && UserQuery.Contains("touch screen")&& !(UserQuery.Contains("portable"))&& !(UserQuery.Contains("non-portable")))
                return AccessDataBase.SetupSqlConnection("Select ModelNo from Monitors where Spec2='4.5'' Touch Screen'", 0);
            if (UserQuery.Contains("5.5'") && UserQuery.Contains("touch screen") && !(UserQuery.Contains("portable")) && !(UserQuery.Contains("non-portable")))
                return AccessDataBase.SetupSqlConnection("Select ModelNo from Monitors where Spec1='Non-Portable' and Spec2='5.5'' Touch Screen'", 0);
            if (UserQuery.Contains("9'") && UserQuery.Contains("touch screen") && !(UserQuery.Contains("portable")) && !(UserQuery.Contains("non-portable")))
                return AccessDataBase.SetupSqlConnection("Select ModelNo from Monitors where Spec2='9'' Touch Screen'", 0);
            if (UserQuery.Contains("12'") && UserQuery.Contains("touch screen") && !(UserQuery.Contains("portable")) && !(UserQuery.Contains("non-portable")))
                return AccessDataBase.SetupSqlConnection("Select ModelNo from Monitors where Spec2='12'' Touch Screen'", 0);
            if (UserQuery.Contains("15'") && UserQuery.Contains("touch screen") && !(UserQuery.Contains("portable")) && !(UserQuery.Contains("non-portable")))
                return AccessDataBase.SetupSqlConnection("Select ModelNo from Monitors where Spec2='15'' Touch Screen'", 0);

            return "not available.";
        }
    }
    

}