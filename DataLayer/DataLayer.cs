using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class AccessDataBase
    {
        
        
        public static string SetupSqlConnection(string query)
        {
            string str=null;
            string provider = ConfigurationManager.AppSettings["provider"];
            string connectionString = ConfigurationManager.AppSettings["connectionString"];
            DbProviderFactory factory = DbProviderFactories.GetFactory(provider);
            using (DbConnection connection = factory.CreateConnection())
            {
                if (connection == null)
                {
                    throw new Exception("Connection Error");
                }

                connection.ConnectionString = connectionString;
                connection.Open();
                DbCommand command = factory.CreateCommand();
                if (command == null)
                {
                    throw new Exception("Command Error");
                }


                command.Connection = connection;
                command.CommandText = query;
                DbDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (dataReader.Read())
                {

                    str = str + dataReader.GetString(0);
                    str = str + "\n";
                }

                return str;
            }


        }

        
    }
}

