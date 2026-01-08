using miniProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace miniProject
{
    public partial class ViewBill : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnRetrieve_Click(object sender, EventArgs e)
        {
            int n = int.Parse(txtN.Text);
            ElectricityBoard board = new ElectricityBoard();
            gvBills.DataSource = board.Generate_N_BillDetails(n);
            gvBills.DataBind();
        }
    }
}