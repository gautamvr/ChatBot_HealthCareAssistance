using WcfClient.myHostingService;
using System;
using System.ServiceModel;



namespace SelfHostingClient
{
    class ClientProgram
    {
        static void Main(string[] args)
        {
            //readRecords();
            AddRecords();
        }

        private static void AddRecords()
        {
            var tcpProxy = new WcfClient.myTcpServices.CustomerAddingServiceClient();
            tcpProxy.AddNewCustomer(new WcfClient.myTcpServices.Customer
            {
                CustomerID = 5050,
                CustomerName = "Raghav",
                CustomerAddress = "Bangalore",
                CustomerPhone = 9676292294
            }
                );
        }

        private static void readRecords()
        {
            var proxy = new CustomerServiceClient();
            var data = proxy.GetAllCustomers();
            foreach (var cst in data)
                Console.WriteLine($"{cst.CustomerName} is from {cst.CustomerAddress}");
        }
    }
}

