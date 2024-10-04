using DataLayer;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLayer
{
    public class SupplierRequest
    {
        public int ID { get; set; }
        public int? SupID { get; set; }
        public int? InvID { get; set; }
        public string ActionStat { get; set; }
        public DateTime ActionDate { get; set; }

        public int InsertAction(int? supplierID, int? requestID, string actionStatus)
        {
            int rowsAffected = 0;
            string sql = "INSERT INTO tblSupplierRequestActions (supplierID, requestID, actionStatus) VALUES (@supplierID, @requestID, @actionStatus)";

            using (SqlConnection con = new SqlConnection(DatabaseOperations.ConString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {

                    cmd.Parameters.AddWithValue("@supplierID", supplierID ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@requestID", requestID ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@actionStatus", actionStatus ?? (object)DBNull.Value);


                    con.Open();
                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }

            return rowsAffected;
        }

        public int UpdateAction()
        {
            int rowsAffected = 0;
            string sql = "UPDATE tblSupplierRequestActions SET actionStatus = @actionStatus WHERE id = @id";

            using (SqlConnection con = new SqlConnection(DatabaseOperations.ConString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@actionStatus", ActionStat ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@id", ID);

                    con.Open();
                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }

            return rowsAffected;
        }

        public DataSet GetRequestByUserID(int userID)
        {
            string sql = @"
                SELECT 
                    r.itemName, 
                    r.brand, 
                    r.serialNo, 
                    r.quantity, 
                    r.reqStatus,
                    inv.itemName AS InventoryItemName,
                    inv.brand AS InventoryBrand,
                    inv.serialNo AS InventorySerialNo,
                    sra.actionStatus, 
                    sra.actionDate
                FROM 
                    tblSupplierRequestActions sra
                LEFT JOIN 
                    tblRequests r ON sra.requestID = r.id
                LEFT JOIN 
                    tblInventory inv ON r.invID = inv.id
                WHERE 
                    sra.supplierID = @userID";

            using (SqlConnection con = new SqlConnection(DatabaseOperations.ConString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@userID", userID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                con.Open();
                da.Fill(ds);
                return ds;
            }
        }
    }
}
