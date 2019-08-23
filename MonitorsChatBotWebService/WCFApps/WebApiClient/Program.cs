using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace WebApiClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new WebClient();
            var data = client.DownloadString("http://localhost:44362/api/FirstExample");// Download string API will download the data as JSON oject which can be used to read
            var data1 = client.DownloadString("http://localhost:44362/api/Stuents");
            Console.WriteLine(data);
            Console.WriteLine(data1);
        }
    }
}
