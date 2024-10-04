using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TechFix
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        localhostUser.UserManagementService ums = new localhostUser.UserManagementService();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        

        protected void AddUser_Click(object sender, EventArgs e)
        {
            string fName = txtFName.Text.Trim();
            string uName = txtUName.Text.Trim();
            string pWord = txtPWord.Text.Trim();
            string uMail = txtUMail.Text.Trim();
            string uRole = ddlURole.SelectedValue;
            
            if (!string.IsNullOrEmpty(fName) && !string.IsNullOrEmpty(uName) && !string.IsNullOrEmpty(pWord) && !string.IsNullOrEmpty(uMail))
            {
                try
                {
                    int result = ums.InsertUser(fName, uName, pWord, uMail, uRole);

                    if (result > 0)
                    {
                        lblMessage.Text = "User added successfully!";
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                        ClientScript.RegisterStartupScript(this.GetType(), "requestSuccess", "alert('User added successfully.');window.location.href='ManagerAddUser.aspx';", true);
                        ClearFields();
                        txtFName.Focus();
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "requestError", "alert('User not added successfully.');window.location.href='ManagerAddUser.aspx';", true);
                        lblMessage.Text = "Failed to add user. Please try again.";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = $"Error: {ex.Message}";
                }
            }
            else
            {
                lblMessage.Text = "Please fill in all required fields.";
            }
        }
        private void ClearFields()
        {
            txtFName.Text = string.Empty;
            txtUName.Text = string.Empty;
            txtPWord.Text = string.Empty;
            txtUMail.Text = string.Empty;
            ddlURole.SelectedIndex = 0;
        }
    }
    }
