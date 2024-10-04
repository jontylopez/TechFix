using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using BusinessLayer;

namespace TechFix
{
    /// <summary>
    /// Summary description for RequestManagementService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class RequestManagementService : System.Web.Services.WebService
    {
        [WebMethod]
        public int InsertRequest(int? invID, string itemName, string brand, string serialNo, int quantity, string reqStatus)
        {
            Request req = new Request
            {
                InvID = invID,
                ItemName = itemName,
                Brand = brand,
                SerialNo = serialNo,
                Quantity = quantity,
                ReqStat = reqStatus
            };

            return req.InsertReq();
        }

        [WebMethod]
        public int UpdateRequestStatus(int id, string reqStatus)
        {
            Request req = new Request
            {
                ID = id,
                ReqStat = reqStatus
            };

            return req.UpdateRequest();
        }

        [WebMethod]
        public int DeleteRequest(int id)
        {
            Request req = new Request();
            return req.DeleteRequest(id);
        }

        [WebMethod]
        public DataSet ViewAllRequests()
        {
            Request req = new Request();
            return req.ViewAll();
        }
        [WebMethod]
        public DataSet GetRequestsForManager()
        {
            Request req = new Request();
            return req.ReqForManager("pending"); 
        }

        [WebMethod]
        public DataSet GetRequestsForSupplier(int supplierID)
        {
            Request req = new Request();
            return req.ReqForSupplier(supplierID, "approved");
        }
        [WebMethod]
        public DataSet FindRequestById(int requestId)
        {
            Request req = new Request();
            return req.FindRequestById(requestId);
        }
        [WebMethod]
        public DataSet FindRequestQuantityById(int requestId)
        {
            try
            {
                Request req = new Request();
                return req.FindRequestQuantityById(requestId);
            }
            catch (Exception ex)
            {
            
                Console.WriteLine($"Error fetching request quantity: {ex.Message}");

            
                return new DataSet();
            }
        }
       
    }
}
