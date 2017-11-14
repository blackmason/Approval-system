using System.Collections.Generic;
using Approval.Models;
using Approval.Services;
using Microsoft.AspNetCore.Mvc;

namespace Approval.Controllers
{
    public class Approval : Controller
    {
        public IActionResult Summary()
        {
            return View("Summary");
        }

        public IActionResult Write()
        {
            // string selector = null;
            
            // if (id != null)
            // {
            //     selector = string.Format("Write/{0}", id);
            // }
            // else 
            // {
            //     selector = string.Format("Write/{0}", "WD001");
            // }

            // return View(selector);

            FormService service = new FormService();
            var result = service.GetFormList();

            return View("Write/WD001", result);
        }

        public IActionResult GetEmployees()
        {
            EmployeeService service = new EmployeeService();
            List<Employee> listEmp = service.GetEmployees();

            return View("Working/List", listEmp);
        }
    }
}