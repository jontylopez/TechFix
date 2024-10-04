using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using BusinessLayer;
using DataLayer;

namespace TechFix
{
    /// <summary>
    /// Web service for managing quotations.
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class QuotationsManagementService : System.Web.Services.WebService
    {
        [WebMethod]
        public int InsertQuotation(int? invID, int? requestID, int supID, decimal unitPrice, decimal totalPrice, decimal? discount, decimal finalPrice, string status, string description)
        {
            try
            {
                Quotations quotation = new Quotations
                {
                    InvID = invID,
                    RequestID = requestID,
                    SupID = supID,
                    UnitPrice = unitPrice,
                    TotalPrice = totalPrice,
                    Discount = discount,
                    FinalPrice = finalPrice,
                    Status = status,
                    Description = description
                };

                return quotation.InsertQuotation();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inserting quotation: {ex.Message}");
                return -1;
            }
        }

        [WebMethod]
        public int UpdateQuotationStatus(int id, string status)
        {
            try
            {
                Quotations quotation = new Quotations();
                return quotation.UpdateQuotationStatus(id, status);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating quotation status: {ex.Message}");
                return -1;
            }
        }

        [WebMethod]
        public DataSet GetQuotationByID(int id)
        {
            try
            {
                Quotations quotation = new Quotations();
                return quotation.GetQuotationByID(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving quotation: {ex.Message}");
                return new DataSet();
            }
        }

        [WebMethod]
        public DataSet ViewAllQuotations()
        {
            try
            {
                Quotations quotation = new Quotations();
                return quotation.ViewAllQuotations();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving all quotations: {ex.Message}");
                return new DataSet();
            }
        }
        [WebMethod]
        public DataSet GetQuotationsBySupplier(int supID)
        {
            try
            {
                Quotations quotation = new Quotations();
                return quotation.GetQuotationsBySupplier(supID);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching quotations: {ex.Message}");
                return new DataSet();
            }
        }

        [WebMethod]
        public DataSet GetQuotationsByStatus(string status)
        {
            try
            {
                Quotations quotation = new Quotations();

                return quotation.GetQuotationsByStatus(status);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching quotations: {ex.Message}");
                return new DataSet();
            }
        }

    }
}
