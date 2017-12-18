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
            if (null == id || "" == id)
            {
                return View("Write/SetApproval");
            }
            else
            {
                var res = GetDepartmentList();
                return View("Write/SetApproval_2", res);
            }
            
        }

        public JsonResult GetEmployees()
        {
            EmployeeService service = new EmployeeService();
            var empList = service.GetEmployees();

            return Json(empList);
        }

        public JsonResult GetDepartment()
        {
            DepartmentService service = new DepartmentService();
            var deptList = service.GetDepartment();

            return Json(deptList);
        }

        public List<Employee> GetEmployeesList()
        {
            EmployeeService service = new EmployeeService();
            var empList = service.GetEmployees();

            return empList;
        }

        public List<Department> GetDepartmentList()
        {
            DepartmentService service = new DepartmentService();
            var deptList = service.GetDepartment();

            return deptList;
        }
    }
}