using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;

namespace TechFix
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        localhostInventory.InventoryManageService ims = new localhostInventory.InventoryManageService();
        localhostRequest.RequestManagementService rms = new localhostRequest.RequestManagementService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadInventory();
            }
        }

        protected void LoadInventory()
        {
            DataSet ds = ims.ViewAllInventory();
            ViewState["InventoryData"] = ds.Tables[0];
            gvInventory.DataSource = ds;
            gvInventory.DataBind();
        }

        protected void SearchInventory_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim().ToLower();

            if (ViewState["InventoryData"] != null)
            {
                DataTable dt = ViewState["InventoryData"] as DataTable;
                DataView dv = new DataView(dt);
                dv.RowFilter = $"itemName LIKE '%{searchText}%' OR brand LIKE '%{searchText}%' OR serialNo LIKE '%{searchText}%' OR supplier LIKE '%{searchText}%'";
                gvInventory.DataSource = dv;
                gvInventory.DataBind();
            }
        }
     

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            Response.Redirect("AccountantAddInventoryForm.aspx");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            HiddenField hfInventoryId = (HiddenField)row.FindControl("hfInventoryId");
            int inventoryId = Convert.ToInt32(hfInventoryId.Value);
            Response.Redirect($"AccountantUpdateInventoryForm.aspx?inventoryId={inventoryId}");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            HiddenField hfInventoryId = (HiddenField)row.FindControl("hfInventoryId");
            int inventoryId = Convert.ToInt32(hfInventoryId.Value);

            
            ims.DeleteInventory(inventoryId);
            ClientScript.RegisterStartupScript(this.GetType(), "requestSuccess", "alert('Item Deleted successfully.');", true);
            LoadInventory(); 
        }


        protected void btnOrder_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            HiddenField hfInventoryId = (HiddenField)row.FindControl("hfInventoryId");
            int inventoryId = Convert.ToInt32(hfInventoryId.Value);
            Response.Redirect($"AccountantItemreqForm.aspx?inventoryId={inventoryId}");
        }


        protected void gvInventory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
