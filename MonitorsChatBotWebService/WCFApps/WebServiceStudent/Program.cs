using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using WebServiceStudent.StudentServices;

namespace WebServiceStudent
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentDataService studentData = new StudentDataService();
            var data = studentData.GetAllRecords();
            var table = data.Tables[0];

            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn column in table.Columns)
                    Console.WriteLine(column.ColumnName + ": " + row[column.ColumnName]);
                Console.WriteLine("==================================");
            }
        }
    }
}
