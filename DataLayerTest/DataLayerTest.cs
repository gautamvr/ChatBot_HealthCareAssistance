using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Configuration;
using System.Data.SqlClient;
using NUnit.Framework.Constraints;

namespace DataLayerTest
{
    using DataLayer;
    [TestFixture]
    public class DataLayerTest
    {
        [Test]
        public void TestSqlDataExtractor()
        {
            DAL da=new DAL();
            string TestData1 = "MX400     ";
            string TestSQLquery = "Select ModelNo from Monitors where Id='1'";
            Assert.AreEqual(TestData1, da.Execute(TestSQLquery));
        }

        [Test]
        public void TestSqlConnection()
        {
             DAL da=new DAL();
             string expectedStr = ConfigurationManager.AppSettings["connectionString"];
             string actualStr = da.ConnectionString;
             Assert.AreEqual(expectedStr,actualStr);
        }

        [Test]
        public void TestSqlCommand()
        {
            string spoName = "Select * from Monitors";
            DAL da = new DAL();
            SqlCommand response = da.GetCommand(spoName);
            Assert.IsNotNull(response);
            Assert.AreEqual(spoName, response.CommandText);
        }


    }
}
