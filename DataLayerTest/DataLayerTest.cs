using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Configuration;
namespace DataLayerTest
{
    using DataLayer;
    [TestFixture]
    public class DataLayerTest
    {
        [Test]
        public void TestSQLDataExtractor()
        {
            string TestData1 = "MX400     \n";

            string TestSQLquery = "Select ModelNo from Monitors where ModelNo ='MX400'";
            Assert.AreEqual(AccessDataBase.SetupSqlConnection(TestSQLquery,0),TestData1);
        }

    }
}
