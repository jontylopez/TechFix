using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TechFix
{
    public partial class WebForm20 : System.Web.UI.Page
    {
        localhostUser.UserManagementService ums = new localhostUser.UserManagementService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUserDetails();
            }
        }
        protected void LoadUserDetails()
        {
            int userId = GetLoggedInUserID();
            DataSet ds = ums.FindUser(userId);

            if (ds.Tables[0].Rows.Count > 0)
            {
                var row = ds.Tables[0].Rows[0];
                txtFName.Text = row["fName"].ToString();
                txtUMail.Text = row["uMail"].ToString();
            }
        }
        private int GetLoggedInUserID()
        {
            return Convert.ToInt32(Session["UserID"]);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ValidatePasswordChange())
            {
                try
                {
                    int userId = GetLoggedInUserID();
                    string newFName = txtFName.Text;
                    string newUMail = txtUMail.Text;
                    string newPassword = txtNewPassword.Text;

                    int result = ums.UpdateUserProfile(userId, newFName, newUMail, newPassword);
                    if (result > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "requestSuccess", "alert('Profile Update successfully.');window.location.href='AccountantHome.aspx';", true);

                        lblMessage.Text = "Profile updated successfully.";
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "requestError", "alert('Error Profile Update.');window.location.href='AccountantHome.aspx';", true);

                        lblMessage.Text = "Error updating profile.";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = $"Error updating profile: {ex.Message}"; 
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
        protected bool ValidatePasswordChange()
        {
            if (!string.IsNullOrEmpty(txtNewPassword.Text))
            {
                if (txtNewPassword.Text != txtConfirmPassword.Text)
                {
                    lblMessage.Text = "Passwords do not match.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    return false;
                }
            }
            return true;
        }
        protected void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = chkShowPassword.Checked;
            txtCurrentPassword.TextMode = isChecked ? TextBoxMode.SingleLine : TextBoxMode.Password;
            txtNewPassword.TextMode = isChecked ? TextBoxMode.SingleLine : TextBoxMode.Password;
            txtConfirmPassword.TextMode = isChecked ? TextBoxMode.SingleLine : TextBoxMode.Password;
        }
    }
}