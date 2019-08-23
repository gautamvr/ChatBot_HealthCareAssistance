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
            var querybase = new Dictionary<string, string>()
            {
                { "decision" , "Clinical Decision Support" },
                {"support", "Clinical Decision Support"},
                {"help", "Clinical Decision Support" },
                {"surveillance","CSA" },
                {"surveillancing","CSA" },
                {"alarming","CSA" },
                {"alarm","CSA" },
                {"emergency","EWES" },
                {"score","EWES" },
                {"warning","EWES" },
                {"early","EWES" }
            };
            return GetSolution(querybase[UserQuery]);
        }
    }
}
