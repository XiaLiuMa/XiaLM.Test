using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XiaLM.WebTest.DataAccessLayer;
using XiaLM.WebTest.Models;

namespace XiaLM.WebTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult EnterMyHome()
        {
            EmployeeListView employeesView = new EmployeeListView();
            EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
            List<Employee> employees = empBal.GetEmployees();
            List<EmployeeView> employeeViews = new List<EmployeeView>();
            foreach (Employee emp in employees)
            {
                EmployeeView employeeView = new EmployeeView();
                employeeView.EmployeeName = emp.FirstName + " " + emp.LastName;
                employeeView.Salary = emp.Salary.ToString("C");
                if (emp.Salary > 1500)
                {
                    employeeView.SalaryColor = "yellow";
                }
                else
                {
                    employeeView.SalaryColor = "green";
                }
                employeeViews.Add(employeeView);
            }
            employeesView.Employees = employeeViews;
            employeesView.UserName = "Admin";
            return View("MyHome", employeesView);
        }
        
    }
}