using System;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ValidationApp
{
    public partial class Validator : Page
    {
        protected void Page_Load(object sender, EventArgs e) { }

        protected void ValidateFamilyName(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            args.IsValid = txtName.Text.Trim() != txtFamily.Text.Trim();
        }

        protected void btnCheck_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string script = "alert('ValidationSum\\nAll fields are OK');";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessAlert", script, true);
            }
            else
            {
                StringBuilder errors = new StringBuilder("ValidationSum\\n");
                foreach (BaseValidator validator in Page.Validators)
                {
                    if (!validator.IsValid)
                    {
                        errors.AppendLine("- " + validator.ControlToValidate.Replace("txt", "").ToLower());
                    }
                }

                string script = $"alert('{errors.ToString()}');";
                ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", script, true);
            }
        }
    }
}
