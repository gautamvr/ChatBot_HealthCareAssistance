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
            //sent = sent.ToLower();
            //data = data.ToLower();
            ////HashSet<string> hashset = ParseToHashSet(sent);
            //string[] strBase = data.Split('\n');
            
            //HashSet<string> emptySet = new HashSet<string>();
            //Console.WriteLine(strBase.Length);
            //int oldHashLength = hashset.Count();
            //foreach (var str in strBase)
            //{
            //    hashset.Add(str);
            //}

            //int newHashLength = hashset.Count();
            //if (newHashLength == oldHashLength)
            //{

            //}


            return sent;
        }

    }
    public class MonitorLogic
    {
        //------------------Queries to Access the Monitor Table------------------------
        public static string GetSerialName()
        {
            return AccessDataBase.SetupSqlConnection("Select Distinct Category from Monitors", 0);
        }

        public static string GetDistinctModelNames()
        {
            string allModelNames = AccessDataBase.SetupSqlConnection("Select Distinct ModelNo from Monitors", 0);
            return allModelNames;
        }

        public static string GetDistinctSpecs()
        {
            string totalSpecs;
            totalSpecs = AccessDataBase.SetupSqlConnection("Select Distinct Spec1 from Monitors", 0) +
                         AccessDataBase.SetupSqlConnection("Select Distinct Spec2 from Monitors", 0) +
                         AccessDataBase.SetupSqlConnection("Select Distinct Spec3 from Monitors", 0);
            return totalSpecs;

        }

        public static string GetModels(string s)
        {
            return AccessDataBase.SetupSqlConnection("Select ModelNo from Monitors where Category='" + s + "'", 0);
        }

        public static string GetSpecification(string m)
        {
            return AccessDataBase.SetupSqlConnection(
                "Select ModelNo,Spec1,Spec2,Spec3 from Monitors where ModelNo='" + m + "'", 3);
        }

        public static string GetModelOnSpecifications(string UserQuery)
        {
            //portability and touch screen
            if (UserQuery.Contains("non-portable"))
            {
                if (UserQuery.Contains("4.5'") && UserQuery.Contains("touch screen"))
                    return AccessDataBase.SetupSqlConnection(
                        "Select ModelNo from Monitors where Spec1='Non-Portable' and Spec2='4.5'' Touch Screen'", 0);
                if (UserQuery.Contains("5.5'") && UserQuery.Contains("touch screen"))
                    return AccessDataBase.SetupSqlConnection(
                        "Select ModelNo from Monitors where Spec1='Non-Portable' and Spec2='5.5'' Touch Screen'", 0);
                if (UserQuery.Contains("9'") && UserQuery.Contains("touch screen"))
                    return AccessDataBase.SetupSqlConnection(
                        "Select ModelNo from Monitors where Spec1='Non-Portable' and Spec2='9'' Touch Screen'", 0);
                if (UserQuery.Contains("12'") && UserQuery.Contains("touch screen"))
                    return AccessDataBase.SetupSqlConnection(
                        "Select ModelNo from Monitors where Spec1='Non-Portable' and Spec2='12'' Touch Screen'", 0);
                if (UserQuery.Contains("15'") && UserQuery.Contains("touch screen"))
                    return AccessDataBase.SetupSqlConnection(
                        "Select ModelNo from Monitors where Spec1='Non-Portable' and Spec2='15'' Touch Screen'", 0);
            }

            else if (UserQuery.Contains("portable") && !(UserQuery.Contains("touch screen")))
            {
                if (UserQuery.Contains("4.5'") && UserQuery.Contains("touch screen"))
                    return AccessDataBase.SetupSqlConnection(
                        "Select ModelNo from Monitors where Spec1='Portable' and Spec2='4.5'' Touch Screen'", 0);
                if (UserQuery.Contains("5.5'") && UserQuery.Contains("touch screen"))
                    return AccessDataBase.SetupSqlConnection(
                        "Select ModelNo from Monitors where Spec1='Non-Portable' and Spec2='5.5'' Touch Screen'", 0);
                if (UserQuery.Contains("9'") && UserQuery.Contains("touch screen"))
                    return AccessDataBase.SetupSqlConnection(
                        "Select ModelNo from Monitors where Spec1='Portable' and Spec2='9'' Touch Screen'", 0);
                if (UserQuery.Contains("12'") && UserQuery.Contains("touch screen"))
                    return AccessDataBase.SetupSqlConnection(
                        "Select ModelNo from Monitors where Spec1='Portable' and Spec2='12'' Touch Screen'", 0);
                if (UserQuery.Contains("15'") && UserQuery.Contains("touch screen"))
                    return AccessDataBase.SetupSqlConnection(
                        "Select ModelNo from Monitors where Spec1='Portable' and Spec2='15'' Touch Screen'", 0);
            }

            //portability only
            if (UserQuery.Contains("non-portable") && !(UserQuery.Contains("touch screen")))
                return AccessDataBase.SetupSqlConnection("Select ModelNo from Monitors where Spec1='Non-Portable'", 0);
            else if (UserQuery.Contains("portable") && !(UserQuery.Contains("touch screen")))
                return AccessDataBase.SetupSqlConnection("Select ModelNo from Monitors where Spec1='Portable'", 0);


            //touch screen only
            if (UserQuery.Contains("4.5'") && UserQuery.Contains("touch screen") && !(UserQuery.Contains("portable")) &&
                !(UserQuery.Contains("non-portable")))
                return AccessDataBase.SetupSqlConnection(
                    "Select ModelNo from Monitors where Spec2='4.5'' Touch Screen'", 0);
            if (UserQuery.Contains("5.5'") && UserQuery.Contains("touch screen") && !(UserQuery.Contains("portable")) &&
                !(UserQuery.Contains("non-portable")))
                return AccessDataBase.SetupSqlConnection(
                    "Select ModelNo from Monitors where Spec1='Non-Portable' and Spec2='5.5'' Touch Screen'", 0);
            if (UserQuery.Contains("9'") && UserQuery.Contains("touch screen") && !(UserQuery.Contains("portable")) &&
                !(UserQuery.Contains("non-portable")))
                return AccessDataBase.SetupSqlConnection("Select ModelNo from Monitors where Spec2='9'' Touch Screen'",
                    0);
            if (UserQuery.Contains("12'") && UserQuery.Contains("touch screen") && !(UserQuery.Contains("portable")) &&
                !(UserQuery.Contains("non-portable")))
                return AccessDataBase.SetupSqlConnection("Select ModelNo from Monitors where Spec2='12'' Touch Screen'",
                    0);
            if (UserQuery.Contains("15'") && UserQuery.Contains("touch screen") && !(UserQuery.Contains("portable")) &&
                !(UserQuery.Contains("non-portable")))
                return AccessDataBase.SetupSqlConnection("Select ModelNo from Monitors where Spec2='15'' Touch Screen'",
                    0);

            return "not available.";
        }
    }

    public class SolutionLogic
    {
        // -----------Queries to access the solutions table-----------------------------------------
        public static string GetSolutionName()
        {
            return AccessDataBase.SetupSqlConnection("Select Distinct Category from Solutions", 0);
        }

        public static string GetSolution(string s)
        {

            return AccessDataBase.SetupSqlConnection("Select Name from Solutions where Category ='" + s + "'", 0);
        }

        public static string GetDescription(string s)
        {
            return AccessDataBase.SetupSqlConnection(
                "Select Description,Spec1,Spec3,url from Solutions where Name ='" + s + "'", 3);
        }

        public static string GetPurpose(string UserQuery)
        {
            //Find out the soln that matches user purpose
            if (UserQuery.Contains("decision") || (UserQuery.Contains("support")) || (UserQuery.Contains("help")))
            {
                return AccessDataBase.SetupSqlConnection(
                    "Select Name,Description,url from Solutions where Category = 'Clinical Decision Support' ", 3);

            }

            else if (UserQuery.Contains((" surveillance")) || (UserQuery.Contains("surveillancing")) ||
                     UserQuery.Contains("alarming") || UserQuery.Contains("alarm"))
            {
                return AccessDataBase.SetupSqlConnection(
                    "Select Name,Description,url from Solutions where Category = 'CSA' ", 2);
            }

            else if (UserQuery.Contains((" emergency")) || (UserQuery.Contains("warning")) ||
                     UserQuery.Contains("score") || UserQuery.Contains("early"))
            {
                return AccessDataBase.SetupSqlConnection(
                    "Select Name,Description,url from Solutions where Category = 'EWES' ", 2);
            }


            else
            {
                return "null";
            }


        }


    }
}