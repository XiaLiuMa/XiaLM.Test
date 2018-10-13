using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XiaLM.WebTest.Models
{
    public class EmployeeListView
    {
        public List<EmployeeView> Employees { get; set; }
        public string UserName { get; set; }
    }
}