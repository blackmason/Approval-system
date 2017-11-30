using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Approval.Models;
using Approval.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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

        public JsonResult GetEmployees()
        {
            EmployeeService service = new EmployeeService();
            var empList = service.GetEmployees();

            return Json(empList);
        }

        // public List<Department> GetDepartment()
        public JsonResult GetDepartment()
        {
            DepartmentService service = new DepartmentService();
            var deptList = service.GetDepartment();

            return Json(deptList);
        }
    }
}