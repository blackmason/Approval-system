using System.Collections.Generic;
using System.Linq;
using Approval.Models;
using Approval.Services;
using Microsoft.AspNetCore.Mvc;

namespace Approval.Controllers
{
    public class Approval : Controller
    {
        FormService formService;

        public IActionResult Summary()
        {
            return View("Summary");
        }

        public IActionResult Write(string id)
        {
            formService = new FormService();
            var result = formService.GetFormList();

            if ("WD001" == id)
            {
                return View("Write/WD001");
            }
            else 
            {
                return View("Write/Front", result);
            }
        }

        public IActionResult SetApproval(string id)
        {
            return View("Write/SetApproval");
        }

        public List<Employee> GetEmployees()
        {
            EmployeeService service = new EmployeeService();
            List<Employee> listEmp = service.GetEmployees();

            return listEmp;
        }
    }
}