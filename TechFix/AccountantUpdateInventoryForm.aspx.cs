using System;
using System.Web.UI;

namespace TechFix
{
    public partial class WebForm9 : System.Web.UI.Page
    {
        localhostInventory.InventoryManageService ims = new localhostInventory.InventoryManageService();

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
                hfInventoryId.Value = inventoryId.ToString();
                txtItemName.Text = row["itemName"].ToString();
                txtBrand.Text = row["brand"].ToString();
                txtSerialNo.Text = row["serialNo"].ToString();
                txtQuantity.Text = row["quantity"].ToString();
                txtUnitPrice.Text = row["unitPrice"].ToString();
                txtSupplier.Text = row["supplier"].ToString();
            }
        }

        protected void btnSaveInventory_Click(object sender, EventArgs e)
        {
            int inventoryId = Convert.ToInt32(hfInventoryId.Value);
            int quantity;
            decimal unitPrice;

            if (int.TryParse(txtQuantity.Text, out quantity) && decimal.TryParse(txtUnitPrice.Text, out unitPrice))
            {
                string itemName = txtItemName.Text;
                string brand = txtBrand.Text;
                string serialNo = txtSerialNo.Text;
                string supplier = txtSupplier.Text;

                int userID = ((TechFixAccountant)this.Master).UserID;

                if (userID == 0)
                {

                    lblMessage.Text = "User session expired. Please log in again.";
                    return;
                }

                try
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "requestSuccess", "alert('Item Updated successfully.');window.location.href = 'AccountantViewInventory.aspx';", true);
                    ims.UpdateInventory(inventoryId, userID, itemName, brand, serialNo, quantity, (double)unitPrice, supplier);
                    lblMessage.Text = "Inventory updated successfully!";
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "requestError", "alert('Item update not successful.');window.location.href = 'AccountantViewInventory.aspx';", true);
                    lblMessage.Text = $"Error updating inventory: {ex.Message}";
                }
            }
            else
            {
                lblMessage.Text = "Please enter valid values for Quantity and Unit Price.";
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("AccountantViewInventory.aspx");
        }
    }
}
