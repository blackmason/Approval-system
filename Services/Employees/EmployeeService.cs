using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Approval.Models;
using System.Collections.Generic;

namespace Approval.Services
{
    public class EmployeeService : DataAccess
    {
        public List<Employee> GetEmployees()
        {
            string sql = "select TOP 100 * from TB_USERS";
            List<Employee> listEmp;

            using (connection = new SqlConnection(SetConnString("mssql")))
            {
                connection.Open();
                command = new SqlCommand(sql, connection);
                reader = command.ExecuteReader();

                Employee emp;
                listEmp = new List<Employee>();
                
                while(reader.Read())
                {
                    emp = new Employee();
                    emp.Code = reader["Code"].ToString();
                    emp.Name = reader["Name"].ToString();
                    emp.Email = reader["Email"].ToString();
                    emp.Gender = reader["Gender"].ToString();
                    emp.Department = reader["DepartmentCode"].ToString();
                    emp.Comment = reader["Comment"].ToString();
                    emp.Created = reader["Created"].ToString();
                    listEmp.Add(emp);
                }

                connection.Close();
            }

            return listEmp;
        }
    }
}