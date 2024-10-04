using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TechFix
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        localhostQuotations.QuotationsManagementService qs = new localhostQuotations.QuotationsManagementService();
        localhostInventory.InventoryManageService ims = new localhostInventory.InventoryManageService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadApprovedQuotations();
                LoadItemsToRestock();
            }
        }
        protected void LoadApprovedQuotations()
        {
            DataSet ds = qs.GetQuotationsByStatus("managerapproved");
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvApprovedQuotations.DataSource = ds;
                gvApprovedQuotations.DataBind();
            }
            else
            {
                lblMessage.Text = "No approved quotations found.";
            }
        }
        protected void gvApprovedQuotations_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewQuotation")
            {
                int quotationId = Convert.ToInt32(e.CommandArgument);
                Response.Redirect($"AccountantViewQuotation.aspx?quotationId={quotationId}");
            }
        }

        protected void LoadItemsToRestock()
        {
            try
            {
                DataSet ds = ims.GetItemsToRestock();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    gvItemsToRestock.DataSource = ds;
                    gvItemsToRestock.DataBind();
                }
                else
                {
                    lblMessage.Text = "No items to restock.";
                    gvItemsToRestock.DataSource = null;
                    gvItemsToRestock.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = $"Error loading items to restock: {ex.Message}";
            }
        }
    }
}