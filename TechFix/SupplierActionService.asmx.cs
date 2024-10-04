using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace TechFix
{
    /// <summary>
    /// Summary description for SupplierActionService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SupplierActionService : System.Web.Services.WebService
    {
        [WebMethod]
        public int InsertSupplierAction(int? supplierID, int? requestID, string actionStatus)
        {
            try
            {
                SupplierRequest supplierRequest = new SupplierRequest();
                return supplierRequest.InsertAction(supplierID, requestID, actionStatus);
            }
            catch (Exception)
            {
                return -1;
            }
        }


        [WebMethod]
        public int UpdateSupplierAction(int actionID, string actionStatus)
        {
            try
            {
                SupplierRequest supplierRequest = new SupplierRequest
                {
                    ID = actionID,
                    ActionStat = actionStatus
                };

                return supplierRequest.UpdateAction();
            }
            catch (Exception)
            {

                return -1;
            }
        }

        [WebMethod]
        public DataSet GetRequestByUserID(int userID)
        {
            SupplierRequest req = new SupplierRequest();
            return req.GetRequestByUserID(userID);
        }
    }
}
