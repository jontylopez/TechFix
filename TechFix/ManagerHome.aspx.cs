using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TechFix
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        localhostRequest.RequestManagementService rms = new localhostRequest.RequestManagementService();
        localhostQuotations.QuotationsManagementService qs = new localhostQuotations.QuotationsManagementService();
        localhostUser.UserManagementService ums = new localhostUser.UserManagementService();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPendingRequests();
                LoadPendingQuotations();
                
            }
        }
        protected void LoadPendingRequests()
        {
            var ds = rms.GetRequestsForManager(); 
            gvPendingRequests.DataSource = ds;
            gvPendingRequests.DataBind();
        }
        protected void LoadPendingQuotations()
        {
            DataSet ds = qs.GetQuotationsByStatus("pending"); 
            gvPendingQuotations.DataSource = ds;
            gvPendingQuotations.DataBind();
        }
        protected void gvPendingRequests_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                int requestId = Convert.ToInt32(e.CommandArgument);
                Response.Redirect($"ManagerReqView.aspx?requestId={requestId}");
            }
        }

        protected void gvPendingQuotations_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewQuotation")
            {
                int quotationId = Convert.ToInt32(e.CommandArgument);
                Response.Redirect($"ManagerViewQuotation.aspx?quotationId={quotationId}");
            }
        }

        
    }
}