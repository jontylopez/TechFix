using System;
using System.Data;
using System.Web.UI;

namespace TechFix
{
    public partial class WebForm18 : System.Web.UI.Page
    {
        localhostQuotations.QuotationsManagementService qs = new localhostQuotations.QuotationsManagementService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int quotationId = Convert.ToInt32(Request.QueryString["quotationId"]);
                LoadQuotationDetails(quotationId);
            }
        }

        protected void LoadQuotationDetails(int quotationId)
        {
            DataSet ds = qs.GetQuotationByID(quotationId);
            if (ds.Tables[0].Rows.Count > 0)
            {
                var row = ds.Tables[0].Rows[0];
                txtItemName.Text = row["itemName"].ToString();
                txtBrand.Text = row["brand"].ToString();
                txtUnitPrice.Text = row["unitPrice"].ToString();
                txtTotalPrice.Text = row["totalPrice"].ToString();
                txtFinalPrice.Text = row["finalPrice"].ToString();
                txtDiscount.Text = row["discount"].ToString();
                txtDescription.Text = row["qDescription"].ToString();
                txtQuotationStatus.Text = row["quotStat"].ToString();
                txtDateCreated.Text = row["dateCreated"].ToString();

                ViewState["quotationId"] = quotationId;
            }
        }

        protected void btnAccept_Click(object sender, EventArgs e)
        {
            int quotationId = (int)ViewState["quotationId"];

            int result = qs.UpdateQuotationStatus(quotationId, "managerapproved");

            if (result > 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "requestSuccess", "alert('Quotation Accepted Successfully.');window.location.href='ManagerHome.aspx';", true);
                lblMessage.Text = "Quotation accepted successfully.";
                lblMessage.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMessage.Text = "Error accepting quotation. Please try again.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            int quotationId = (int)ViewState["quotationId"];

            int result = qs.UpdateQuotationStatus(quotationId, "rejected");

            if (result > 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "requestSuccess", "alert('Quotation Rejected.');window.location.href='ManagerHome.aspx';", true);
                lblMessage.Text = "Quotation rejected successfully.";
                lblMessage.ForeColor = System.Drawing.Color.Green;

            }
            else
            {
                lblMessage.Text = "Error rejecting quotation. Please try again.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {

            Response.Redirect("ManagerHome.aspx");
        }
    }
}
