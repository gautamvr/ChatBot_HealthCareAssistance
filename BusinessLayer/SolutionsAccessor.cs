using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    using DataLayer;
    public class SolutionsAccessor
    {
        static DAL da = new DAL();
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
                return GetSolution("Clinical Decision Support");
            }

            else if (UserQuery.Contains((" surveillance")) || (UserQuery.Contains("surveillancing")) ||
                     UserQuery.Contains("alarming") || UserQuery.Contains("alarm"))
            {
                return GetSolution("CSA");
            }

            else if (UserQuery.Contains((" emergency")) || (UserQuery.Contains("warning")) ||
                     UserQuery.Contains("score") || UserQuery.Contains("early"))
            {
                return GetSolution("EWES");
            }

            else
            {
                return "null";
            }
        }
    }
}
