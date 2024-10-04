using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TechFix
{
    public partial class WebForm13 : System.Web.UI.Page
    {
        localhostRequest.RequestManagementService rms = new localhostRequest.RequestManagementService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int requestId = Convert.ToInt32(Request.QueryString["requestId"]);
                LoadRequestDetails(requestId);
            }
        }
        protected void LoadRequestDetails(int requestId)
        {
            var ds = rms.GetRequestsForManager();
            if (ds.Tables[0].Rows.Count > 0)
            {
                var row = ds.Tables[0].Rows[0];
                txtItemName.Text = row["itemName"].ToString();
                txtBrand.Text = row["brand"].ToString();
                txtSerialNo.Text = row["serialNo"].ToString();
                txtQuantity.Text = row["quantity"].ToString();
                txtStatus.Text = row["reqStatus"].ToString();
            }
        }
        protected void btnApprove_Click(object sender, EventArgs e)
        {
            int requestId = Convert.ToInt32(Request.QueryString["requestId"]);
            rms.UpdateRequestStatus(requestId, "approved");
            ClientScript.RegisterStartupScript(this.GetType(), "requestSuccess", "alert('Request approved successfully.');window.location.href='ManagerHome.aspx';", true);
           
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            int requestId = Convert.ToInt32(Request.QueryString["requestId"]);
            rms.UpdateRequestStatus(requestId, "rejected");
            ClientScript.RegisterStartupScript(this.GetType(), "requestSuccess", "alert('Request Rejected successfully.');window.location.href='ManagerHome.aspx';", true);
            
        }


        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManagerHome.aspx");
        }
    }
}