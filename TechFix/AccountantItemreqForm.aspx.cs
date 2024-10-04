using System;
using System.Web.UI;

namespace TechFix
{
    public partial class WebForm10 : System.Web.UI.Page
    {
        localhostInventory.InventoryManageService ims = new localhostInventory.InventoryManageService();
        localhostRequest.RequestManagementService rms = new localhostRequest.RequestManagementService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int inventoryId = Convert.ToInt32(Request.QueryString["inventoryId"]);
                LoadInventoryItem(inventoryId);
            }
        }
        protected void LoadInventoryItem(int inventoryId)
        {
            var ds = ims.FindInventory(inventoryId);
            if (ds.Tables[0].Rows.Count > 0)
            {
                var row = ds.Tables[0].Rows[0];
                txtItemId.Text = inventoryId.ToString();
                txtItemName.Text = row["itemName"].ToString();
                txtBrand.Text = row["brand"].ToString();
                txtSerialNo.Text = row["serialNo"].ToString();
            }
        }

        protected void btnSendRequest_Click(object sender, EventArgs e)
        {
            int inventoryId = Convert.ToInt32(txtItemId.Text);
            string itemName = txtItemName.Text;
            string brand = txtBrand.Text;
            string serialNo = txtSerialNo.Text;
            int quantity;

            if (int.TryParse(txtQuantity.Text, out quantity) && quantity > 0)
            {
                try
                {
                    rms.InsertRequest(inventoryId, itemName, brand, serialNo, quantity, "pending");
                    ClientScript.RegisterStartupScript(this.GetType(), "requestSuccess", "alert('Request submitted successfully.');window.location.href = 'AccountantViewInventory.aspx';", true);
                    lblMessage.Text = "Request submitted successfully!";
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "requestError", "alert('Request not submitted successfully.');window.location.href = 'AccountantViewInventory.aspx';", true);
                    lblMessage.Text = $"Error submitting request: {ex.Message}";
                }
            }
            else
            {
                lblMessage.Text = "Please enter a valid quantity.";
            }
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("AccountantViewInventory.aspx");
        }
    }
}
