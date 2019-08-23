using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using WebServiceClient.myWebServices;//use the namespace...
namespace WebServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create the instance of the service object
            EmpDataService empData = new EmpDataService();
            var data = empData.GetAllRecords();//Call the method
            var table = data.Tables[0];
            foreach (DataRow row in table.Rows)
                Console.WriteLine(row["EmpID"]);
            //Iterate thro the collection...
        }
    }
}

