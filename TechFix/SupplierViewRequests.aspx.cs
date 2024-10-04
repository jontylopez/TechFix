using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TechFix
{
    public partial class WebForm14 : System.Web.UI.Page
    {
        localhostSupAction.SupplierActionService supp = new localhostSupAction.SupplierActionService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadSupplierRequests(); 
            }
        }
        protected void LoadSupplierRequests()
        {
            try
            {
                int supplierID = GetLoggedInSupplierID();
                DataSet ds = supp.GetRequestByUserID(supplierID);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    gvSupplierRequests.DataSource = ds;
                    gvSupplierRequests.DataBind();
                }
                else
                {
                    lblMessage.Text = "No requests found for the supplier.";
                    gvSupplierRequests.DataSource = null;
                    gvSupplierRequests.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = $"Error loading requests: {ex.Message}";
            }
        }

        private int GetLoggedInSupplierID()
        {
            return Convert.ToInt32(Session["UserID"]); 
        }
    }
}