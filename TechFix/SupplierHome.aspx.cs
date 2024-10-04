using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TechFix
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        localhostRequest.RequestManagementService rms = new localhostRequest.RequestManagementService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SupplierMaserPage masterPage = (SupplierMaserPage)this.Master;
                int supplierID = masterPage.UserID;

                if (supplierID > 0)
                {
                    LoadPendingRequests(supplierID);
                }
                else
                {
                    lblMessage.Text = "Session expired. Please log in again.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
        protected void LoadPendingRequests(int supplierID)
        {
            DataSet ds = rms.GetRequestsForSupplier(supplierID);
            gvPendingRequests.DataSource = ds;
            gvPendingRequests.DataBind();
        }
        protected void btnView_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int requestId = Convert.ToInt32(btn.CommandArgument);
            Response.Redirect($"SupplierReqViewForm.aspx?requestId={requestId}");
        }
    }
}