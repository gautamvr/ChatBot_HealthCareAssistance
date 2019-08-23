using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;

namespace StudentWebService
{
    /// <summary>
    /// Summary description for StudentDataService
    /// </summary>
    [WebService(Namespace = "http://tempuri1.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class StudentDataService : System.Web.Services.WebService
    {

        [WebMethod]
        public List<string> GetAllStudents()
        {
            return new List<string>
            {
                "Deepika",
                "Pooja",
                "Sharanya",
                "Navneet",
                "Jyoti",
                "Varun",
            };
        }
        [WebMethod]
        public DataSet GetAllRecords()
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=PhilipsDB;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
            SqlCommand cmd = new SqlCommand("SELECT * FROM CUSTOMERTABLE ", con);
            try
            {
                con.Open();
                var reader = cmd.ExecuteReader();
                DataSet ds = new DataSet();
                DataTable table = new DataTable("EmpRecords");
                table.Load(reader);
                ds.Tables.Add(table);
                return ds;
            }
            
            finally
            {
                con.Close();
            }
        }
    }
}
