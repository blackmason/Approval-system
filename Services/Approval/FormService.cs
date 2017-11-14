using System.Collections.Generic;
using System.Data.SqlClient;
using Approval.Models;
using Microsoft.AspNetCore.Mvc;

namespace Approval.Services
{
    public class FormService : DataAccess
    {
        public List<Preform> GetFormList()
        {
            string sql = "SELECT Seq, Subject, Explain FROM TB_APPROVAL_FORM WHERE Enabled = '1'";
            List<Preform> preformList;

            using(connection = new SqlConnection(SetConnString("mssql")))
            {
                connection.Open();

                command = new SqlCommand(sql, connection);
                reader = command.ExecuteReader();

                Preform form;
                preformList = new List<Preform>();

                while(reader.Read())
                {
                    form = new Preform();
                    form.Seq = reader["Seq"].ToString();
                    //form.FormId = reader["FormId"].ToString();
                    //form.FormGroup = reader["FormGroup"].ToString();
                    form.Subject = reader["Subject"].ToString();
                    form.Explain = reader["Explain"].ToString();
                    //form.Content = reader["Content"].ToString();
                    //form.Author = reader["Author"].ToString();
                    //form.Enabled = reader["Enabled"].ToString();
                    //form.Modified = reader["Modified"].ToString();
                    //form.Created = reader["Created"].ToString();
                    preformList.Add(form);
                }

                connection.Close();
            }

            return preformList;
        }
    }
}