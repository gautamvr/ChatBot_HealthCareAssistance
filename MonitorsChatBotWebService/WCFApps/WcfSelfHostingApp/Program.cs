using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.IO;

//The important libraries of Wcf are: System.ServiceModels and System.Runtime.Serialization. U must refrerence these libraries before u develop any WcF components inside a .NET App.
// self hosting apps are created for developing WCF components that are to be consumed by others. NET Apps within the Itranet Networks. I n other words, U will develop the code for hosting a WCF app within the Intranet Network.In other words, U will develop the code for hosting a WCF comoinent inside ur .Net app like the way we used to do it in .NET remoting kind of Apps.
//Add the refrerence of the above libraries into ur project as this is a console App.

namespace WcfSelfHostingApp
{
    //Like an other WCF component.....you need to develop the service contracts and it's implementation in form of WCF components.
    [ServiceContract]
   
    public interface ICustomerService 
    {
        [OperationContract]
        List<Customer> GetAllCustomers();
    }

    

    [DataContract]// This performs serialization of the data components..........
    public class Customer
    {
        [DataMember]
        public int CustomerID { get; set; }
        [DataMember]
        public string CustomerName { get; set; }
        [DataMember]
        public string CustomerAddress { get; set; }
        [DataMember]
        public long CustomerPhone { get; set;}


    }
    [ServiceContract]
    public  interface ICustomerAddingService
    {
        [OperationContract]
        void AddNewCustomer(Customer cst);
    }
    public class WCFComponent : ICustomerService,ICustomerAddingService
    {
        public void AddNewCustomer(Customer cst)
        {
            var list = GetAllCustomers();
            list.Add(cst);
            var content = JsonConvert.SerializeObject(list);
            using (StreamWriter writer = new StreamWriter("Customers.json"))
            {
                writer.WriteLine(content);

            }

        }



        public List<Customer> GetAllCustomers()
        {
            var reader = new StreamReader("Customers.json");
            string content = reader.ReadToEnd();
            reader.Close();
            var data = JsonConvert.DeserializeObject(content, typeof(List<Customer>));
            if (data is List<Customer>)
                return data as List<Customer>;
            else
                throw new FaultException("Failed to load data");
            
        }
    }

    class Program
    {
        //This reads the JSON file and converts it to a list
        static List<Customer> getrecords()
        {
            var reader = new StreamReader("Customers.json");
            string content = reader.ReadToEnd();
            var data = JsonConvert.DeserializeObject(content, typeof(List<Customer>));
            if (data is List<Customer>)
                return data as List<Customer>;
            else
                return null;
        }
        static void Main(string[] args)
        {
           //readallRecords();
           // writeToJson();


            //Code to host the service


            string url = "http://localhost:1234/MySelfHostingServices/";
            try
            {
                ServiceHost hostApp = new ServiceHost(typeof(WCFComponent), new Uri(url));
                WSHttpBinding binding = new WSHttpBinding();
                Type contract = typeof(ICustomerService);
                hostApp.AddServiceEndpoint(contract, binding, "");
                hostApp.Open();
                Console.WriteLine("Press Any key to exit....");
                Console.ReadKey();
                hostApp.Close();
            }
            catch (CommunicationException ex)
            {

                Console.WriteLine(ex.Message);
            }
            catch (Exception genEx)
            {
                Console.WriteLine(genEx.Message);
            }
           
        }

        private static void readallRecords()
        {
            var data = getrecords();
            foreach (var c in data)
                Console.WriteLine(c.CustomerName);
        }

        private static void writeToJson()
        {
            
            Customer cst = new Customer
            {
                CustomerID = 123,
                CustomerName = "Mahesh",
                CustomerAddress = "Tumkur",
                CustomerPhone = 123 - 334 - 444 - 44,

            };

            Customer[] customers = new Customer[]
                {
                    new Customer
                    {
                         CustomerID = 123,
                CustomerName = "Mahesh",
                CustomerAddress = "Tumkur",
                CustomerPhone = 12333444444,
                    },
                    new Customer
                    {

                CustomerID = 123,
                CustomerName = "Mahesh",
                CustomerAddress = "Tumkur",
                CustomerPhone = 12333444444,
                    }



                };

            string data = JsonConvert.SerializeObject(customers);
            Console.WriteLine(data);
            //Use stream writer to save data
            using (StreamWriter writer = new StreamWriter("data.Json"))
            {
                writer.WriteLine(data);
            }
        }
    }

}
