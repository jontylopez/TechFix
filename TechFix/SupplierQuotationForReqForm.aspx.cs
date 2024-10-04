using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TechFix
{
    public partial class WebForm17 : System.Web.UI.Page
    {
        localhostRequest.RequestManagementService rms = new localhostRequest.RequestManagementService();
        localhostQuotations.QuotationsManagementService qs = new localhostQuotations.QuotationsManagementService();
        localhostSupAction.SupplierActionService sas = new localhostSupAction.SupplierActionService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int requestId = Convert.ToInt32(Request.QueryString["requestId"]);

                int? inventoryId = null;
                if (Request.QueryString["inventoryId"] != null)
                {
                    inventoryId = Convert.ToInt32(Request.QueryString["inventoryId"]);
                }

                LoadRequestDetails(requestId, inventoryId);
            }
        }

        protected void LoadRequestDetails(int requestId, int? inventoryId)
        {

            DataSet ds = rms.FindRequestById(requestId); 
            if (ds.Tables[0].Rows.Count > 0)
            {
                var row = ds.Tables[0].Rows[0];
                txtItemName.Text = row["itemName"].ToString();
                txtBrand.Text = row["brand"].ToString();
                txtSerialNo.Text = row["serialNo"].ToString();
                txtQuantity.Text = row["quantity"].ToString();
                txtRequestID.Text = requestId.ToString();

                if (inventoryId.HasValue)
                {
                    txtInventoryID.Text = inventoryId.ToString();
                }
                else
                {
                    txtInventoryID.Text = row["invID"] != DBNull.Value ? row["invID"].ToString() : "";
                }
            }
        }

        protected void txtUnitPrice_TextChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        protected void chkApplyDiscount_CheckedChanged(object sender, EventArgs e)
        {
            txtDiscount.Enabled = chkApplyDiscount.Checked;
            CalculateTotalAfterDiscount();
        }

        protected void CalculateTotal()
        {
            if (decimal.TryParse(txtUnitPrice.Text, out decimal unitPrice) && int.TryParse(txtQuantity.Text, out int quantity))
            {
                decimal totalPrice = unitPrice * quantity;
                txtTotalPrice.Text = totalPrice.ToString("0.00");
                CalculateTotalAfterDiscount();
            }
        }

        protected void CalculateTotalAfterDiscount()
        {
            if (decimal.TryParse(txtTotalPrice.Text, out decimal totalPrice))
            {
                decimal totalAfterDiscount = totalPrice;

                if (chkApplyDiscount.Checked && decimal.TryParse(txtDiscount.Text, out decimal discountPercentage))
                {
                    decimal discountAmount = (totalPrice * discountPercentage) / 100;
                    totalAfterDiscount -= discountAmount;
                }

                txtTotalAfterDiscount.Text = totalAfterDiscount.ToString("0.00");
            }
        }

        protected void btnSendQuotation_Click(object sender, EventArgs e)
        {
            try
            {
                int? invID = !string.IsNullOrEmpty(txtInventoryID.Text) ? Convert.ToInt32(txtInventoryID.Text) : (int?)null;
                int requestId = Convert.ToInt32(txtRequestID.Text);
                decimal unitPrice = Convert.ToDecimal(txtUnitPrice.Text);
                decimal totalPrice = Convert.ToDecimal(txtTotalPrice.Text);

                decimal? discount = !string.IsNullOrEmpty(txtDiscount.Text) ? (decimal?)Convert.ToDecimal(txtDiscount.Text) / 100 : (decimal?)null;

                decimal totalAfterDiscount = Convert.ToDecimal(txtTotalAfterDiscount.Text);
                string description = txtDescription.Text;
                string quotationStatus = "pending";

                SupplierMaserPage masterPage = (SupplierMaserPage)this.Master;
                int supplierID = masterPage.UserID;

                int result = qs.InsertQuotation(invID, requestId, supplierID, unitPrice, totalPrice, discount, totalAfterDiscount, quotationStatus, description);

                if (result > 0)
                {
                    int actionResult = sas.InsertSupplierAction(supplierID, requestId, "approved");

                    if (actionResult > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "requestSuccess", "alert('Quotation submitted successfully.');window.location.href='SupplierViewQuotations.aspx';", true);
                        
                    }
                    else
                    {
                        lblMessage.Text = "Error inserting supplier action.";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                    lblMessage.Text = "Error inserting quotation.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = $"Error: {ex.Message}";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("SupplierReqViewForm.aspx");
        }
        private int GetLoggedInSupplierID()
        {
            return Convert.ToInt32(Session["SupplierID"]);
        }
    }
}
