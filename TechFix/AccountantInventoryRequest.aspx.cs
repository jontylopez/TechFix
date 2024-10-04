using BusinessLayer;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TechFix
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        localhostRequest.RequestManagementService rms = new localhostRequest.RequestManagementService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadRequests(); 
            }
        }

        protected void LoadRequests()
        {
            try
            {

                DataSet ds = rms.ViewAllRequests();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {

                    DataTable dt = ds.Tables[0];
                    dt.Columns.Add("Priority", typeof(int), "IIF(reqStatus = 'pending', 0, 1)");

                    DataView dv = dt.DefaultView;
                    dv.Sort = "Priority, reqStatus DESC";

                    gvRequests.DataSource = dv;
                    gvRequests.DataBind();
                }
                else
                {
                    lblMessage.Text = "No requests available.";
                    gvRequests.DataSource = null;
                    gvRequests.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = $"Error loading requests: {ex.Message}";
            }
        }

        protected void btnFilterRequests_Click(object sender, EventArgs e)
        {
            string supplierName = txtSupplierName.Text.Trim();
            if (!string.IsNullOrEmpty(supplierName))
            {
                try
                {
                    DataSet ds = rms.ViewAllRequests();
                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        DataView dv = ds.Tables[0].DefaultView;
                        dv.RowFilter = $"supplier LIKE '%{supplierName}%'"; 
                        dv.Sort = "CASE WHEN reqStatus = 'pending' THEN 0 ELSE 1 END, reqStatus DESC"; 

                        gvRequests.DataSource = dv;
                        gvRequests.DataBind();
                    }
                    else
                    {
                        lblMessage.Text = "No matching requests found.";
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = $"Error filtering requests: {ex.Message}";
                }
            }
            else
            {
                LoadRequests(); 
            }
        }

        
        protected void btnAddRequest_Click(object sender, EventArgs e)
        {
            Response.Redirect("AccountantItemManualReqForm.aspx");
        }
    }
}
