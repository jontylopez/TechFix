using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace TechFix
{
    /// <summary>
    /// Summary description for InventoryManageService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class InventoryManageService : System.Web.Services.WebService
    {

        [WebMethod]
        public int InsertInventory(int userID, string itemName, string brand, string serialNo, int quantity, double unitPrice, string supplier)
        {
            Inventory inv = new Inventory();
            return inv.InsertInv(userID, itemName, brand, serialNo, quantity, unitPrice, supplier);
        }

        
        [WebMethod]
        public int UpdateInventory(int id, int userID, string itemName, string brand, string serialNo, int quantity, double unitPrice, string supplier)
        {
            Inventory inv = new Inventory();
            return inv.UpdateInv(id, itemName, brand, serialNo, quantity, unitPrice, supplier);
        }
        [WebMethod]
        public int UpdateInvFrmQuotation(int id, int quantity, double unitPrice) {
            Inventory inv = new Inventory();
            return inv.UpdateInvFromQuotation(id, quantity, unitPrice);
        }
        
        [WebMethod]
        public int DeleteInventory(int id)
        {
            Inventory inv = new Inventory();
            return inv.DeleteInv(id);
        }

        
        [WebMethod]
        public DataSet FindInventory(int id)
        {
            Inventory inv = new Inventory();
            return inv.Find(id);
        }

        
        [WebMethod]
        public DataSet ViewAllInventory()
        {
            Inventory inv = new Inventory();
            return inv.ViewAll();
        }
        [WebMethod]
        public DataSet GetItemsToRestock()
        {
            Inventory inv = new Inventory();
            return inv.GetItemsToRestock();
        }


    }
}
