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
        string connString = null;

        public DataAccess()
        { }
        
        protected string SetConnString(string connType)
        {
            if (connType == "mssql")
            {
                return connString = "workstation id=LSSOLUTION.mssql.somee.com;packet size=4096;user id=peakpanda;pwd=wpfhznf21;data source=LSSOLUTION.mssql.somee.com;persist security info=False;initial catalog=LSSOLUTION";
            }
            else
            {
                return connString = "";
            }
        }
    }
}