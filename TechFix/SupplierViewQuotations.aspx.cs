using System;
using System.Data;

namespace TechFix
{
    public partial class WebForm15 : System.Web.UI.Page
    {
        localhostQuotations.QuotationsManagementService qs = new localhostQuotations.QuotationsManagementService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SupplierMaserPage masterPage = (SupplierMaserPage)this.Master;
                int supplierID = masterPage.UserID;

                LoadQuotations(supplierID);
            }
        }

        protected void LoadQuotations(int supplierID)
        {
            try
            {

                DataSet ds = qs.GetQuotationsBySupplier(supplierID);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvQuotations.DataSource = ds;
                    gvQuotations.DataBind();
                }
                else
                {
                    lblMessage.Text = "No quotations found.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = $"Error loading quotations: {ex.Message}";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
