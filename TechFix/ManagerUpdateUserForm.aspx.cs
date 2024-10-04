using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TechFix
{
    public partial class WebForm12 : System.Web.UI.Page
    {
        localhostUser.UserManagementService ums = new localhostUser.UserManagementService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int userId = Convert.ToInt32(Request.QueryString["userId"]);
                LoadUserDetails(userId);
            }
        }
        protected void LoadUserDetails(int userId)
        {
            var ds = ums.FindUser(userId);
            if (ds.Tables[0].Rows.Count > 0)
            {
                var row = ds.Tables[0].Rows[0];
                txtFName.Text = row["fName"].ToString();
                txtUName.Text = row["uName"].ToString();
                txtUMail.Text = row["uMail"].ToString();
                ddlURole.SelectedValue = row["uRole"].ToString();
            }
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManagerManageUser.aspx");
        }

        protected void btnSaveUser_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(Request.QueryString["userId"]);
            string fName = txtFName.Text;
            string uName = txtUName.Text;
            string uMail = txtUMail.Text;
            string uRole = ddlURole.SelectedValue;
            ums.UpdateUser(userId, fName, uMail, uRole);
            ClientScript.RegisterStartupScript(this.GetType(), "requestSuccess", "alert('Profile Update successfully.');window.location.href='ManagerManageUser.aspx';", true);
        }
    }
}