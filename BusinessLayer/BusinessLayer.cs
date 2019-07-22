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
            return AccessDataBase.SetupSqlConnection("Select Distinct Category from Monitors");
            

        }

        public static string GetModels(string s)
        {
            return AccessDataBase.SetupSqlConnection("Select ModelNo from Monitors where Category='"+s+"'");
        }
    }
    

}