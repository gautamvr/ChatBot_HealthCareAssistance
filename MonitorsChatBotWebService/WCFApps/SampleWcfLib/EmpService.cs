using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace SampleWcfLib
{
    public class SportService : ISportService
    {
        const string strCon = @" Data Source=.\SQLEXPRESS;Initial Catalog=PhilipsDB;Integrated Security=True";
        const string strReg = "Insert into SportTable Values(@name,@phone)";
        public void BookCourt(Slot slot)
        {
            SqlConnection con = new SqlConnection(strCon);
            var query = string.Format("insert into SportSlotTable values('{0}',{1},{2},{3})",slot.StartTime.ToString(),slot.SlotUnits,slot.TotalAmount,slot.CustomerID);
            var cmd = new SqlCommand(query ,con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
            finally
            { con.Close(); }

        }

        public List<Slot> GetAllBookedSlots()
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAllCustomers()
        {
            var con = new SqlConnection(strCon);
            var cmd = new SqlCommand("SELECT SportTable.CstID, CustomerName, CustomerPhone, SUM(SportSlotTable.Fees) AS Fees FROM SportSlotTable INNER JOIN SportTable ON SportSlotTable.CustomerID = SportTable.CstID GROUP BY CustomerName, CustomerPhone, SportTable.CstID", con);
            try
            {
                con.Open();
                var reader = cmd.ExecuteReader();
                List<Customer> customers = new List<Customer>();
                while (reader.Read())
                {
                    Customer cst = new Customer
                    {
                        ContactNo = Convert.ToInt64(reader[2]),
                        Name = reader[1].ToString(),
                        CstID = Convert.ToInt32(reader[0]),
                        Fees = Convert.ToDouble(reader[3])
                    };
                    customers.Add(cst);
                }
                return customers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }









        public void RegisterUser(Customer customer)
        {
            var con = new SqlConnection(strCon);
            var cmd = new SqlCommand(strReg, con);
            cmd.Parameters.AddWithValue("@name", customer.Name);
            cmd.Parameters.AddWithValue("@phone", customer.ContactNo);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            { throw ex; }
            finally
            { con.Close(); }

        }
    }
}
