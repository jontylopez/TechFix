using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Request
    {
        public int ID { get; set; }
        public int? InvID { get; set; }
        public string ItemName { get; set; }
        public string Brand { get; set; }
        public string SerialNo { get; set; }
        public int Quantity { get; set; }
        public string ReqStat { get; set; }

        public int InsertReq()
        {
            int rowsAffected = 0;
            string sql = @"
    INSERT INTO tblRequests (invID, itemName, brand, serialNo, quantity, reqStatus, dateAdded)
    VALUES (@invID, @itemName, @brand, @serialNo, @quantity, @reqStatus, GETDATE())";

            using (SqlConnection con = new SqlConnection(DatabaseOperations.ConString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@invID", InvID.HasValue ? (object)InvID.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@itemName", ItemName);
                    cmd.Parameters.AddWithValue("@brand", Brand);
                    cmd.Parameters.AddWithValue("@serialNo", SerialNo);
                    cmd.Parameters.AddWithValue("@quantity", Quantity);
                    cmd.Parameters.AddWithValue("@reqStatus", ReqStat);
                    con.Open();
                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }

            return rowsAffected;
        }
        

        public int UpdateRequest()
        {
            int rowsAffected = 0;
            string sql = "UPDATE tblRequests SET reqStatus = @reqStatus WHERE id = @id";

            using (SqlConnection con = new SqlConnection(DatabaseOperations.ConString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@reqStatus", ReqStat);
                    cmd.Parameters.AddWithValue("@id", ID);
                    con.Open();
                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }

            return rowsAffected;
        }

        public int DeleteRequest(int id)
        {
            int rowsAffected = 0;
            string sql = "DELETE FROM tblRequests WHERE id=@id";

            using (SqlConnection con = new SqlConnection(DatabaseOperations.ConString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                rowsAffected = cmd.ExecuteNonQuery();
            }
            return rowsAffected;
        }

        public DataSet ViewAll()
        {
            string sql = "SELECT * FROM tblRequests";
            return DatabaseOperations.SelectQuery(sql);
        }
        public DataSet ReqForManager(string reqStat)
        {
            string sql = "SELECT * FROM tblRequests WHERE reqStatus = @reqStatus";

            using (SqlConnection con = new SqlConnection(DatabaseOperations.ConString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@reqStatus", reqStat);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                con.Open();
                da.Fill(ds);
                return ds;
            }
        }

        public DataSet ReqForSupplier(int supplierID, string reqStat)
        {
            string sql = @"
        SELECT r.*
        FROM tblRequests r
        LEFT JOIN tblSupplierRequestActions sra 
        ON r.id = sra.requestID AND sra.supplierID = @supplierID
        WHERE r.reqStatus = @reqStatus AND sra.actionStatus IS NULL";

            using (SqlConnection con = new SqlConnection(DatabaseOperations.ConString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@supplierID", supplierID);
                cmd.Parameters.AddWithValue("@reqStatus", reqStat);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                con.Open();
                da.Fill(ds);
                return ds;
            }
        }
        public DataSet FindRequestById(int requestId)
        {
            string sql = "SELECT * FROM tblRequests WHERE id = @id";

            using (SqlConnection con = new SqlConnection(DatabaseOperations.ConString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@id", requestId);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                con.Open();
                da.Fill(ds);
                return ds;
            }
        }
        public DataSet FindRequestQuantityById(int requestId)
        {
            string sql = "SELECT quantity FROM tblRequests WHERE id = @id";

            using (SqlConnection con = new SqlConnection(DatabaseOperations.ConString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@id", requestId);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                da.Fill(ds); 

                return ds;
            }
        }


        }
    }


