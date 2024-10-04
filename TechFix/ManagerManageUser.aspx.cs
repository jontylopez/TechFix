using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TechFix
{
    
    public partial class WebForm5 : System.Web.UI.Page
    {
        localhostUser.UserManagementService ums = new localhostUser.UserManagementService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUsers();
            }
        }
        protected void LoadUsers()
        {
            DataSet ds = ums.ViewAllUsers();
            gvUsers.DataSource = ds;
            gvUsers.DataBind();
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            HiddenField hfUserId = (HiddenField)row.FindControl("hfUserId");
            int userId = Convert.ToInt32(hfUserId.Value);
            Response.Redirect($"ManagerUpdateUserForm.aspx?userId={userId}");
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            HiddenField hfUserId = (HiddenField)row.FindControl("hfUserId");
            int userId = Convert.ToInt32(hfUserId.Value);
            ums.DeleteUser(userId);
            ClientScript.RegisterStartupScript(this.GetType(), "requestSuccess", "alert('Profile Removed successfully.');window.location.href='ManagerManageUser.aspx';", true);
        }
    }
}