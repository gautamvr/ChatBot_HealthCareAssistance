using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Data.Common;
using System.Configuration;



namespace DataLayer
{

    class AccessDataBase
    {
        public static void GetSerialName()
        {
            string provider = ConfigurationManager.AppSettings["provider"];
            string connectionString = ConfigurationManager.AppSettings["connectionString"];
            DbProviderFactory factory = DbProviderFactories.GetFactory(provider);
            using (DbConnection connection = factory.CreateConnection())
            {
                if (connection == null)
                {
                    Console.WriteLine("Connection Error");
                    Console.ReadLine();
                    return;
                }

                connection.ConnectionString = connectionString;
                connection.Open();
                DbCommand command = factory.CreateCommand();
                if (command == null)
                {
                    Console.WriteLine("Command Error");
                    Console.ReadLine();
                    return;
                }

                command.Connection = connection;
                command.CommandText = "Select * from Monitors";
                using (DbDataReader dataReader = command.ExecuteReader())
                {
                    Console.WriteLine("CPU:Categories and serial Names are mentioned below:\n");
                    bool flag = false;
                    while (dataReader.Read())
                    {
                        if (!flag)
                            Console.Write("CPU: category: {0}\n     serial Name: {1}", dataReader["Category"],
                                dataReader["SerialNo"]);
                        else
                        {
                            Console.Write("     category: {0}     serial Name: {1}", dataReader["Category"],
                                dataReader["SerialNo"]);
                        }

                        Console.WriteLine("\n");
                        flag = true;
                    }


                }
            }
        }

        public static void GetModels(string s) //******************************************************************
        {
            string provider = ConfigurationManager.AppSettings["provider"];
            string connectionString = ConfigurationManager.AppSettings["connectionString"];
            DbProviderFactory factory = DbProviderFactories.GetFactory(provider);
            using (DbConnection connection = factory.CreateConnection())
            {
                if (connection == null)
                {
                    Console.WriteLine("Connection Error");
                    Console.ReadLine();
                    return;
                }

                connection.ConnectionString = connectionString;
                connection.Open();
                DbCommand command = factory.CreateCommand();
                if (command == null)
                {
                    Console.WriteLine("Command Error");
                    Console.ReadLine();
                    return;
                }

                command.Connection = connection;
                command.CommandText = "Select * from ModelNo";
                using (DbDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    { 
                        if(string.Equals(dataReader["category"].ToString(),s))
                        Console.WriteLine(dataReader["Models"]);
                    }
                }

            }
        } //***************************************************************************************************
    }
}



namespace BusinessLayer
{
    using DataLayer;



}

namespace UILayer
{
    using DataLayer;
    using BusinessLayer;

    class program
    {
        public static void Main(string[] args)
        {
            string cpu = "CPU:";
            string you = "YOU:";
            Console.WriteLine(cpu + "Hi, you are talking to Philips Helpline" + "\n");
            string t = Console.ReadLine();
            Console.WriteLine(you + t);
            Console.WriteLine("Do you want information about purchasing monitor or solutions?\n");
            t = Console.ReadLine();
            Console.WriteLine("YOU:{0}\n",t);
            if (t.Contains("monitor")|| t.Contains("monitors"))
            {
            
               AccessDataBase.GetSerialName();
               Console.WriteLine("CPU: Select the Category you want to purchase?");//***************************
               String s=Console.ReadLine();
               AccessDataBase.GetModels(s);
                Console.ReadLine();


            }

            if (t.Contains("solution")|| t.Contains("solutions"))
            {
         
                Console.WriteLine("Solution information to be given from database");
                Console.ReadLine();
            }


        }
    }
}
