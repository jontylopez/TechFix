using System;
using System.Web.UI;

namespace TechFix
{
    public partial class WebForm11 : System.Web.UI.Page
    {
        localhostRequest.RequestManagementService rms = new localhostRequest.RequestManagementService();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        
        protected void btnSendRequest_Click(object sender, EventArgs e)
        {
            string itemName = txtItemName.Text;
            string brand = txtBrand.Text;
            string serialNo = txtSerialNo.Text;
            int quantity;

            if (!string.IsNullOrEmpty(itemName) && int.TryParse(txtQuantity.Text, out quantity))
            {
                try
                {
                    
                    int result = rms.InsertRequest(null, itemName, brand, serialNo, quantity, "pending");

                    if (result > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "requestSuccess", "alert('Request submitted successfully.');window.location.href = 'AccountantInventoryRequest.aspx';", true);

                        lblMessage.Text = "Request submitted successfully!";
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "requestError", "alert('Request submit failed.');window.location.href = 'AccountantInventoryRequest.aspx';", true);
                        lblMessage.Text = "Error occurred while submitting the request.";
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = $"Error: {ex.Message}";
                }
            }
            else
            {
                lblMessage.Text = "Please enter the required fields.";
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("AccountantInventoryRequest.aspx");
        }
    }
}
