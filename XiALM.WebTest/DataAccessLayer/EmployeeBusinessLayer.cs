using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XiaLM.WebTest.Models;

namespace XiaLM.WebTest.DataAccessLayer
{
    public class EmployeeBusinessLayer
    {
        public List<Employee> GetEmployees()
        {
            SalesERPDAL salesDal = new SalesERPDAL();
            return salesDal.Employees.ToList();
        }
    }
}