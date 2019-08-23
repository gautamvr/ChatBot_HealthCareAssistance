using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;// For DataSet(Data Structure)
using System.Data.SqlClient;

namespace SampleWebService
{
    /// <summary>
    /// Summary description for EmpDataService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class EmpDataService : System.Web.Services.WebService
    {
        [WebMethod]
        public List<string> GetAllEmployees()
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
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=PhilipsDB;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT * FROM EMPTABLE", con);
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
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
    }
    // Advantages of Web Services:
    /*
     * Accessible across multiple platforms.
     * A .NET Web service can be consumed by a Java app and a JSP Web service can be consumed by .NET App.
     * True platform independent technology as data is transferred internally as XML.
     */
      
    /*
     * Disadvantages of Web services:
     * Only SOAP and HTTP, not usable for TCP.
     * Only XML, or any data representable as XML, can be used in Web services.
     * Later improvisations in Web technology could not be upgraded in Web services.
     * Multi Service Oriented Technologies like Web services and .NET Remoting needed a common Framework for all kinds of Service based Apps leading to a new Framework called Windows Communication Foundation(WCF).
     */
}
