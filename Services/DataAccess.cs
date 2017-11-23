using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace Approval.Services 
{
    public class DataAccess
    {
        protected SqlConnection connection;
        protected SqlCommand command;
        protected SqlDataReader reader;
        protected SqlDataAdapter adapter;
        

        public DataAccess()
        { }
        
        protected string SetConnString(string connType)
        {
            string connString = string.Empty;

            if (connType == "mssql")
            {
                return connString = "workstation id=APPROVAL.mssql.somee.com;packet size=4096;user id=peakpanda;pwd=wpfhznf21;data source=APPROVAL.mssql.somee.com;persist security info=False;initial catalog=APPROVAL";
            }
            else if (connType == "sqlite")
            {
                return connString = "Data Source=d:/Source/Visual Studio Code/Approval/APPROVAL.DB;Version=3;";
            }
            else
            {
                return connString = "";
            }
        }
    }
}