using miniProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace miniProject
{
    public partial class AddBill : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnAddBill_Click(object sender, EventArgs e)
        {
            try
            {
                ElectricityBill eb = new ElectricityBill();
                eb.ConsumerNumber = txtConsumerNumber.Text;
                eb.ConsumerName = txtConsumerName.Text;
                eb.UnitsConsumed = int.Parse(txtUnits.Text);

                ElectricityBoard board = new ElectricityBoard();
                board.CalculateBill(eb);
                board.AddBill(eb);

                lblResult.Text = $"Bill Added: {eb.ConsumerNumber} {eb.ConsumerName} {eb.UnitsConsumed} Bill Amount : {eb.BillAmount}";
            }
            catch (FormatException ex)
            {
                lblResult.Text = ex.Message;
            }
        }

        protected void btnViewBill_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewBill.aspx");
        }
    }
}