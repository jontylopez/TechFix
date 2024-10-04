using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TechFix
{
    public partial class TechFixManager : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserID"] != null && Session["LoggedInUser"] != null && Session["UserRole"] != null)
                {
                    lblUserId.Text = Session["UserID"].ToString();
                    lblWelcome.Text = Session["LoggedInUser"].ToString();
                    lblUserRole.Text = Session["UserRole"].ToString();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }
    }
}