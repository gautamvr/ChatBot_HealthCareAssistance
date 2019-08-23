using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SampleWebAPI.Models;

namespace SampleWebAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        [HttpGet]
        public List<Employee> AllEmployees()
        {
            var context = new PhilipsDBEntities();
            var records = context.EmpTables.ToList();
            var employees = new List<Employee>();
            foreach (var emp in records)
            {
                var temp = new Employee();
                temp.Convert(emp);
                employees.Add(temp);
            }
            //}
            //var employees = context.EmpTables.ToList().Select((e) => new Employee { ID = e.EmpID, Name = e.EmpName, Address = e.EmpAddress, Salary = e.EmpSalary }).ToList();
            return employees;

        }

        [HttpGet]
        public Employee Find(char id)
        {
            var context = new PhilipsDBEntities();
            var selected = context.EmpTables.FirstOrDefault((e) => e.EmpID.Equals( id));
            if (selected == null) throw new Exception("Employee not found");
            var emp = new Employee();
            emp.Convert(selected);
            return emp;
        }

        [HttpPost]//Adding 
        public bool AddNewEmployee(Employee emp)
        {
            var context = new PhilipsDBEntities();
            var empTable = emp.Convert();
            context.EmpTables.Add(empTable);
            context.SaveChanges();//Commit the transaction and save to the DB...
            return true;
        }

        [HttpPut]
        public bool UpdateEmployee(Employee emp)
        {
            if (emp == null)
            {
                throw new Exception("Emp Details are not set");
            }
            var context = new PhilipsDBEntities();
            var selected = context.EmpTables.FirstOrDefault(e => e.EmpID == emp.ID);
            if (selected == null) throw new Exception("Not found to update");
            selected.EmpName = emp.Name;
            selected.EmpAddress = emp.Address;
            selected.EmpSalary = emp.Salary;
            context.SaveChanges();
            return true;
        }
    }
}
