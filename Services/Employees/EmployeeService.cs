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
            string sql = @"SELECT
                             A.Code
                            ,A.Name
                            ,A.Email
                            ,(CASE WHEN A.Gender = 'M' THEN 'Male' ELSE 'Female' END) Gender
                            ,B.Name AS Department
                            ,A.Created
                        FROM 
                            TB_USER A
                        INNER JOIN TB_DEPARTMENT B ON A.DepartmentCode = B.Code";
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
                    emp.Department = reader["Department"].ToString();
                    // emp.Comment = reader["Comment"].ToString();
                    emp.Created = reader["Created"].ToString();
                    listEmp.Add(emp);
                }

                connection.Close();
            }

            return listEmp;
        }
    }
}