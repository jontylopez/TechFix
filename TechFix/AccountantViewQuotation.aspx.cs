using System;
using System.Data;
using System.Web.UI;

namespace TechFix
{
    public partial class WebForm19 : System.Web.UI.Page
    {
        localhostQuotations.QuotationsManagementService qs = new localhostQuotations.QuotationsManagementService();
        localhostInventory.InventoryManageService ims = new localhostInventory.InventoryManageService();
        localhostRequest.RequestManagementService rms = new localhostRequest.RequestManagementService();
        localhostUser.UserManagementService ums = new localhostUser.UserManagementService();
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

                if (row.Table.Columns.Contains("quantity") && row["quantity"] != DBNull.Value)
                {
                    txtCurrentQuantity.Text = row["quantity"].ToString();
                }
                else
                {
                    txtCurrentQuantity.Text = "N/A";
                }

                ViewState["quotationId"] = quotationId;
            }
        }

        protected void btnUpdateInventory_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["quotationId"] != null)
                {
                    int quotationId = (int)ViewState["quotationId"];
                    DataSet ds = qs.GetQuotationByID(quotationId);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        var row = ds.Tables[0].Rows[0];

                        if (row.Table.Columns.Contains("invID") && row["invID"] != DBNull.Value)
                        {
                            int invID = Convert.ToInt32(row["invID"]);
                            UpdateExistingInventory(row, invID, quotationId);
                        }
                        else
                        {
                            InsertNewInventory(row, quotationId);
                        }
                    }
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
            Response.Redirect("AccountantHome.aspx");
        }
        private void UpdateExistingInventory(DataRow row, int invID, int quotationId)
        {
            DataSet dsInventory = ims.FindInventory(invID);
            int currentQuantity = 0;
            if (dsInventory.Tables[0].Rows.Count > 0)
            {
                var rowInventory = dsInventory.Tables[0].Rows[0];
                currentQuantity = Convert.ToInt32(rowInventory["quantity"]);
            }

            int reqID = Convert.ToInt32(row["reqID"]);
            DataSet dsRequest = rms.FindRequestQuantityById(reqID);
            int requestedQuantity = 0;
            if (dsRequest.Tables[0].Rows.Count > 0)
            {
                var rowRequest = dsRequest.Tables[0].Rows[0];
                requestedQuantity = Convert.ToInt32(rowRequest["quantity"]);
            }
            int newQuantity = currentQuantity + requestedQuantity;
            double newUnitPrice = Convert.ToDouble(row["finalPrice"]) / newQuantity;

            int updateResult = ims.UpdateInvFrmQuotation(invID, newQuantity, newUnitPrice);

            if (updateResult > 0)
            {
                UpdateQuotationStatus(quotationId, "updated");
            }
            else
            {
                lblMessage.Text = "Error updating inventory.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void InsertNewInventory(DataRow row, int quotationId)
        {
            int userID = GetLoggedInUserID();
            string itemName = row["itemName"].ToString();
            string brand = row["brand"].ToString();
            string serialNo = "";

            int reqID = Convert.ToInt32(row["reqID"]);
            DataSet dsRequest = rms.FindRequestById(reqID);
            if (dsRequest.Tables[0].Rows.Count > 0)
            {
                var rowRequest = dsRequest.Tables[0].Rows[0];
                serialNo = rowRequest["serialNo"]?.ToString() ?? "";
            }

            int quantity = Convert.ToInt32(row["quantity"]);
            double unitPrice = Convert.ToDouble(row["finalPrice"]) / quantity;

            int supplierID = Convert.ToInt32(row["supID"]);
            DataSet dsSupplier = GetSupplierDetails(supplierID);
            string supplier = "";
            if (dsSupplier.Tables[0].Rows.Count > 0)
            {
                var supplierRow = dsSupplier.Tables[0].Rows[0];
                supplier = supplierRow["uName"].ToString();
            }

            int result = ims.InsertInventory(userID, itemName, brand, serialNo, quantity, unitPrice, supplier);

            if (result > 0)
            {
                UpdateQuotationStatus(quotationId, "inventory added");
            }
            else
            {
                lblMessage.Text = "Error inserting new inventory.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        private int GetLoggedInUserID()
        {
            return Convert.ToInt32(Session["UserID"]);
        }
        private void UpdateQuotationStatus(int quotationId, string status)
        {
            int statusResult = qs.UpdateQuotationStatus(quotationId, status);
            if (statusResult > 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "requestSuccess", "alert('Inventory updated successfully.');window.location.href='AccountantViewInventory.aspx';", true);
                lblMessage.Text = "Quotation status updated successfully.";
                lblMessage.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMessage.Text = "Failed to update quotation status.";
                lblMessage.ForeColor = System.Drawing.Color.Orange;
            }
        }
        private DataSet GetSupplierDetails(int supplierID)
        {

            return ums.FindUser(supplierID);
        }
    }
}
