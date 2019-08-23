using System;
using System.ServiceModel;
using WcfClient.myTcpServices;

namespace SelfHostingClient
{
class ClientProgram
    {
        static void Main(string[] args)
        {
            // readRecords();
            addRecord();
            //http://IPAddress:1234/MySelfHostingServices/mex
        }

        private static void addRecord()
        {
            var tcpProxy = new WcfClient.myTcpServices.CustomerAddingServiceClient();
            tcpProxy.AddNewCustomer(new WcfClient.myTcpServices.Customer
            {
                CustomerID = 201,
                CustomerAddress="Bangalore", CustomerName="Ankit", CustomerPhone= 7653743185
            });
        }

        private static void readRecords()
        {
            throw new NotImplementedException();
        }
    }
}