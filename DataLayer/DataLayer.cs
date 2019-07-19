using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{

    public class AccessDataBase
    {
        public static void SetupConnection()
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

                SetupCommandConnection(factory, connection,connectionString);
                
            }

        }

        private static void SetupCommandConnection(DbProviderFactory factory, DbConnection connection,string connectionString)
        {
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

        public static void GetSerialName()
        {

           
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
                        if (string.Equals(dataReader["category"].ToString(), s))
                            Console.WriteLine(dataReader["Models"]);
                    }
                }

            }
        } //***************************************************************************************************
    }
}

