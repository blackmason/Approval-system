using System.Collections.Generic;
using System.Data.SqlClient;
using Approval.Models;
using Microsoft.AspNetCore.Mvc;

namespace Approval.Services
{
    public class DepartmentService : DataAccess
    {
        public List<Department> GetDepartment()
        {
            string sql = "SELECT Seq, Code, Name, Created FROM TB_DEPARTMENT";
            List<Department> deptList;

            using(connection = new SqlConnection(SetConnString("mssql")))
            {
                connection.Open();

                command = new SqlCommand(sql, connection);
                reader = command.ExecuteReader();

                Department dept;
                deptList = new List<Department>();
                while(reader.Read())
                {
                    dept = new Department();
                    dept.Seq = reader["Seq"].ToString();
                    dept.Code = reader["Code"].ToString();
                    dept.Name = reader["Name"].ToString();
                    dept.Created = reader["Created"].ToString();
                    deptList.Add(dept);
                }

                connection.Close();
            }

            return deptList;
        }
    }
}