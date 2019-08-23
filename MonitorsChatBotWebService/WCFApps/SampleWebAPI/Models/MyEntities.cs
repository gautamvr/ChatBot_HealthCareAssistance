using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleWebAPI.Models
{//This is or entity class that will be used to share among our clients.This class auto generates the EF is not recommeneded to be shared to the clients.Instrad it is good to cretae our own Entity class and do the required conversations.
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Salary { get; set; }

        public EmpTable Convert()
        {
            return new EmpTable
            {
                EmpID = this.ID,
                EmpAddress = Address,
                EmpName = Name,
                EmpSalary = Salary

            };
        }

        public void Convert(EmpTable record)
        {
            ID = record.EmpID;
            Name = record.EmpName;
            Address = record.EmpAddress;
            Salary = record.EmpSalary;
        }
    }
}