
using System.Collections.Generic;

namespace Approval.Models
{
    public class Employee
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public string Comment { get; set; }
        public string Created { get; set; }
        public List<Employee> ListEmployee { get; set; }
    }
}