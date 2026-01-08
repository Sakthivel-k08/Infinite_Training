using System;
using System.Configuration;   
using System.Data.SqlClient;  

namespace miniProject.DAL
{
    public class DBHandler
    {
        
        public SqlConnection GetConnection()
        {
            
            string connStr = ConfigurationManager.ConnectionStrings["ElectricityBill"].ConnectionString;

            SqlConnection con = new SqlConnection(connStr);

            try
            {
                con.Open();   
            }
            catch (Exception ex)
            {
                throw new Exception("Database connection failed: " + ex.Message);
            }

            return con;
        }
    }
}
