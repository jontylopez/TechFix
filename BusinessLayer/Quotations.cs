using DataLayer;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLayer
{
    public class Quotations
    {
        public int ID { get; set; }
        public int? InvID { get; set; }
        public int? RequestID { get; set; }
        public int SupID { get; set; }  
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal? Discount { get; set; }
        public decimal FinalPrice { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public int InsertQuotation()
        {
            string sql = "INSERT INTO tblQuotation (invID, reqID, supID, unitPrice, totalPrice, discount, finalPrice, quotStat, qDescription) " +
                         "VALUES (@invID, @reqID, @supID, @unitPrice, @totalPrice, @discount, @finalPrice, @quotStat, @qDescription)";

            using (SqlConnection con = new SqlConnection(DatabaseOperations.ConString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@invID", InvID ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@reqID", RequestID ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@supID", SupID);
                cmd.Parameters.AddWithValue("@unitPrice", UnitPrice);
                cmd.Parameters.AddWithValue("@totalPrice", TotalPrice);
                cmd.Parameters.AddWithValue("@discount", Discount ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@finalPrice", FinalPrice);
                cmd.Parameters.AddWithValue("@quotStat", Status);
                cmd.Parameters.AddWithValue("@qDescription", Description ?? (object)DBNull.Value);

                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }


        public int UpdateQuotationStatus(int id, string status)
        {
            string sql = "UPDATE tblQuotation SET quotStat = @status WHERE id = @id";

            try
            {
                using (SqlConnection con = new SqlConnection(DatabaseOperations.ConString))
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@status", status);

                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error: {ex.Message}");
                return -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return -1;
            }
        }


        public DataSet GetQuotationByID(int id)
        {
            string sql = @"SELECT q.id, q.invID, q.reqID,q.supID, r.itemName, r.brand, q.unitPrice, q.totalPrice, q.finalPrice, q.discount, q.quotStat, q.qDescription, q.dateCreated, r.quantity
                   FROM tblQuotation q
                   LEFT JOIN tblRequests r ON q.reqID = r.id
                   WHERE q.id = @id";

            using (SqlConnection con = new SqlConnection(DatabaseOperations.ConString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                con.Open();
                da.Fill(ds);
                return ds;
            }
        }

        public DataSet ViewAllQuotations()
        {
            string sql = "SELECT * FROM tblQuotation";

            try
            {
                return DatabaseOperations.SelectQuery(sql);
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error: {ex.Message}");
                return new DataSet();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new DataSet();
            }
        }
        public DataSet GetQuotationsBySupplier(int supID)
        {
            string sql = "SELECT q.id, r.itemName, r.brand, q.unitPrice, q.totalPrice, q.finalPrice, q.discount, q.quotStat, q.dateCreated " +
                         "FROM tblQuotation q " +
                         "JOIN tblRequests r ON q.reqID = r.id " +
                         "WHERE q.supID = @supID";

            using (SqlConnection con = new SqlConnection(DatabaseOperations.ConString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@supID", supID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                con.Open();
                da.Fill(ds);
                return ds;
            }
        }

        public DataSet GetQuotationsByStatus(string status)
        {
            string sql = "SELECT * FROM tblQuotation q " +
             "WHERE q.quotStat = @status";

            using (SqlConnection con = new SqlConnection(DatabaseOperations.ConString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@status", status);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                con.Open();
                da.Fill(ds);
                return ds;
            }
        }
    }
}
