using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TechFix.localhostSupAction;

namespace TechFix
{
    public partial class WebForm16 : System.Web.UI.Page
    {localhostRequest.RequestManagementService rms = new localhostRequest.RequestManagementService();
        localhostSupAction.SupplierActionService supp = new localhostSupAction.SupplierActionService();
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
            DataSet ds = rms.FindRequestById(requestId); 

            if (ds.Tables[0].Rows.Count > 0)
            {
                var row = ds.Tables[0].Rows[0];
                txtItemName.Text = row["itemName"].ToString();
                txtBrand.Text = row["brand"].ToString();
                txtSerialNo.Text = row["serialNo"].ToString();
                txtQuantity.Text = row["quantity"].ToString();
            }
        }
        protected void btnReject_Click(object sender, EventArgs e)
        {
            SupplierMaserPage masterPage = (SupplierMaserPage)this.Master;
            int supplierID = masterPage.UserID;
            int requestId = Convert.ToInt32(Request.QueryString["requestId"]);

            int result = supp.InsertSupplierAction(supplierID, requestId, "rejected");

            if (result > 0)
            {
                lblMessage.Text = "Request rejected successfully.";
                ClientScript.RegisterStartupScript(this.GetType(), "requestSuccess", "alert('Quotation rejected successfully.');window.location.href='SupplierHome.aspx';", true);
                lblMessage.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMessage.Text = "Error rejecting request. Please try again.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnSendQuotation_Click(object sender, EventArgs e)
        {
            int requestId = Convert.ToInt32(Request.QueryString["requestId"]);
            Response.Redirect($"SupplierQuotationForReqForm.aspx?requestId={requestId}");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("SupplierHome.aspx");
        }
    }
}