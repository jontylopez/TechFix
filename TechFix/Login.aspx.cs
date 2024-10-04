using System;
using System.Web.UI;
using BusinessLayer;

namespace TechFix
{
    public partial class Login : System.Web.UI.Page
    {

        localhostUser.UserManagementService ums = new localhostUser.UserManagementService();
        protected void Page_Load(object sender, EventArgs e)
        {


        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string userName = txtUName.Text;
            string password = txtPWord.Text;

            int userID = ums.GetUserID(userName, password);
            string userRole = ums.IsValidUser(userName, password);

            if (userRole != null)
            {

                Session["LoggedInUser"] = userName;
                Session["UserRole"] = userRole;
                Session["UserID"] = userID;


                switch (userRole.ToLower())
                {
                    case "mgr":
                        Response.Redirect("ManagerHome.aspx");
                        break;
                    case "acc":
                        Response.Redirect("AccountantHome.aspx");
                        break;
                    case "sup":
                        Response.Redirect("SupplierHome.aspx");
                        break;
                    default:
                        lblMessage.Visible = true;
                        lblMessage.Text = "Unauthorized access.";
                        break;
                }
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Invalid username or password.";
            }
        }
    }

}
