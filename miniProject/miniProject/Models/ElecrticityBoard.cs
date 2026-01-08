using miniProject.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace miniProject.Models
{
    public class ElectricityBoard
    {
        public void CalculateBill(ElectricityBill eb)
        {
            int units = eb.UnitsConsumed;
            double amount = 0;

            if (units <= 100) amount = 0;
            else if (units <= 300) amount = (units - 100) * 1.5;
            else if (units <= 600) amount = 200 * 1.5 + (units - 300) * 3.5;
            else if (units <= 1000) amount = 200 * 1.5 + 300 * 3.5 + (units - 600) * 5.5;
            else amount = 200 * 1.5 + 300 * 3.5 + 400 * 5.5 + (units - 1000) * 7.5;

            eb.BillAmount = amount;
        }

        public void AddBill(ElectricityBill eb)
        {
            using (SqlConnection con = new DBHandler().GetConnection())
            {
                string query = "INSERT INTO ElectricityBill VALUES(@num,@name,@units,@amount)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@num", eb.ConsumerNumber);
                cmd.Parameters.AddWithValue("@name", eb.ConsumerName);
                cmd.Parameters.AddWithValue("@units", eb.UnitsConsumed);
                cmd.Parameters.AddWithValue("@amount", eb.BillAmount);
                cmd.ExecuteNonQuery();
            }
        }

        public List<ElectricityBill> Generate_N_BillDetails(int num)
        {
            List<ElectricityBill> bills = new List<ElectricityBill>();

            using (SqlConnection con = new DBHandler().GetConnection())
            {
                string query = "SELECT TOP (@num) ConsumerNumber, ConsumerName, UnitsConsumed, BillAmount FROM ElectricityBill ORDER BY ConsumerNumber DESC";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@num", num);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ElectricityBill eb = new ElectricityBill
                        {
                            ConsumerNumber = reader["ConsumerNumber"].ToString(),
                            ConsumerName = reader["ConsumerName"].ToString(),
                            UnitsConsumed = Convert.ToInt32(reader["UnitsConsumed"]),
                            BillAmount = Convert.ToDouble(reader["BillAmount"])
                        };
                        bills.Add(eb);
                    }
                }
            }

            return bills;
        }

    }
}