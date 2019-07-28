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

    public class Bot
    {
        private static string botName = "Bot";

        public static string Prompt(string ques)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(botName + " : " + ques + "\n");
            Console.ResetColor();
            string reply = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("You : " + reply + "\n");
            return reply.ToLower();
        }

        public static string Prompt(string ques, string param)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(botName + " : " + ques + "\n", param);
            Console.ResetColor();
            string reply = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("You : " + reply + "\n");
            return reply.ToLower();
        }

        public static void PrintLine(string ques)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(botName + " : " + ques + "\n");
        }

        public static void PrintLine(string ques, string param)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(botName + " : " + ques + "\n", param);
        }

        public static void PrintData(string data)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(data + "\n");
        }

        public static void PrintData(string data, string param)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(data + "\n", param);
        }

    }

    public class Logic
    {
        public static HashSet<string> ParseToHashSet(string data)
        {
            HashSet<string> hashBase = new HashSet<string>();
            string[] strBase = data.Split('\n');
            foreach (var i in strBase)
            {
                hashBase.Add(i);
            }
            return hashBase;
        }

        public static string ExtractKeyword(string data, string sent)
        {
            sent = sent.ToLower();
            data = data.ToLower();
            string[] strBase = data.Split('\n');
            
            foreach (string str in strBase)
            {
                string newStr = str.TrimEnd();
                if (newStr != "")
                {
                    if (sent.Contains(newStr))
                    {
                        return newStr;
                    }
                }
            }
            return sent;
        }

    }
    public class MonitorLogic
    {
        static AccessDataBase da=new AccessDataBase();
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
                                da.Execute("Select Distinct Spec2 from Monitors") +
                                da.Execute("Select Distinct Spec3 from Monitors");
                
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

            return da.Execute("Select ModelNo from Monitors where Spec1='"+UserQuery+"' or Spec2='"+UserQuery+"' or Spec3='"+UserQuery+"'");
        }
    }

    public class SolutionLogic
    {
        static AccessDataBase da=new AccessDataBase();
        // -----------Queries to access the solutions table-----------------------------------------
        public static string GetSolutionName()
        {
            
            return da.Execute("Select Distinct Category from Solutions");
        }

        public static string GetSolution(string s)
        {

            return da.Execute("Select Name from Solutions where Category ='" + s + "'");
        }

        public static string GetDescription(string s)
        {
            return da.Execute(
                "Select Description,Spec1,Spec3,url from Solutions where Name ='" + s + "'");
        }

        public static string GetPurpose(string UserQuery)
        {
            //Find out the soln that matches user purpose
            if (UserQuery.Contains("decision") || (UserQuery.Contains("support")) || (UserQuery.Contains("help")))
            {
                return da.Execute(
                    "Select Name,Description,url from Solutions where Category = 'Clinical Decision Support' ");

            }

            else if (UserQuery.Contains((" surveillance")) || (UserQuery.Contains("surveillancing")) ||
                     UserQuery.Contains("alarming") || UserQuery.Contains("alarm"))
            {
                return da.Execute(
                    "Select Name,Description,url from Solutions where Category = 'CSA' ");
            }

            else if (UserQuery.Contains((" emergency")) || (UserQuery.Contains("warning")) ||
                     UserQuery.Contains("score") || UserQuery.Contains("early"))
            {
                return da.Execute(
                    "Select Name,Description,url from Solutions where Category = 'EWES' ");
            }

            else
            {
                return "null";
            }
        }
    }
}