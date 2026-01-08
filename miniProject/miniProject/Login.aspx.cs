using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace miniProject
{
    public partial class Login : System.Web.UI.Page 
    {
        protected void Page_Load(object sender, EventArgs e) 
        { 
        } 
        protected void btnLogin_Click(object sender, EventArgs e) 
        {
            if (txtUsername.Text == "sakthi" && txtPassword.Text == "sakthi@123") 
            {
                Response.Redirect("AddBill.aspx"); 
            } 
            else 
            { 
                lblMessage.Text = "Invalid Username or Password!";
            }
        }
    }
}