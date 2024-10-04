using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TechFix
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        localhostInventory.InventoryManageService ims = new localhostInventory.InventoryManageService();
        localhostRequest.RequestManagementService rms = new localhostRequest.RequestManagementService();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSaveInventory_Click(object sender, EventArgs e)
        {
            string itemName = txtItemName.Text;
            string brand = txtBrand.Text;
            string serialNo = txtSerialNo.Text;
            int quantity = 0;
            decimal unitPrice = 0;
            string supplier = txtSupplier.Text;

            
            if (!string.IsNullOrEmpty(itemName) && !string.IsNullOrEmpty(brand) &&
                !string.IsNullOrEmpty(serialNo) && int.TryParse(txtQuantity.Text, out quantity) &&
                decimal.TryParse(txtUnitPrice.Text, out unitPrice) && !string.IsNullOrEmpty(supplier))
            {
                
                try
                {
                   
                    ims.InsertInventory(1, itemName, brand, serialNo, quantity, (double)unitPrice, supplier);
                    ClientScript.RegisterStartupScript(this.GetType(), "requestSuccess", "alert('Inventory added successfully.');window.location.href = 'AccountantViewInventory.aspx';", true);
                    lblMessage.Text = "Inventory item saved successfully!";
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "requestError", "alert('Inventory not added successfully.');window.location.href = 'AccountantViewInventory.aspx';", true);
                    lblMessage.Text = $"Error saving inventory item: {ex.Message}";
                }
            }
            else
            {
                lblMessage.Text = "Please fill in all fields correctly.";
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("AccountantViewInventory.aspx");
        }
    }
}