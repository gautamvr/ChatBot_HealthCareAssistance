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
        private static string _connectionString = string.Empty;
        public string ConnectionString
        {
            get
            {
                if (_connectionString == string.Empty)
                {
                    _connectionString = ConfigurationManager.AppSettings["connectionString"];
                }
                return _connectionString;
            }
        }

        public SqlCommand GetCommand(string sql)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            if (conn == null)
            {
                throw new Exception("Connection Error");
            }
            SqlCommand sqlCmd = new SqlCommand(sql, conn);
            if (sqlCmd == null)
            {
                throw new Exception("Command Error");
            }
            return sqlCmd;
        }

        public string Execute(string sql)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = GetCommand(sql);
            cmd.Connection.Open();
            
            dt.Load(cmd.ExecuteReader());
            cmd.Connection.Close();
            string res = string.Join("\n",
                dt.Rows.OfType<DataRow>().Select(x => string.Join(" \n   ", x.ItemArray)));
            return res;
        }
    }
}

