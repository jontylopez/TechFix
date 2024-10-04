using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
    public class Inventory
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string ItemName { get; set; }
        public string Brand { get; set; }
        public string SerialNo { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public string Supplier { get; set; }
       
        
        public int InsertInv(int userID, string itemName, string brand, string serialNo, int quantity, double unitPrice, string supplier)
        {
            string sql = "INSERT INTO tblInventory (userID, itemName, brand, serialNo, quantity, unitPrice, supplier) " +
                         "VALUES (@userID, @itemName, @brand, @serialNo, @quantity, @unitPrice, @supplier)";
            using (SqlConnection con = new SqlConnection(DatabaseOperations.ConString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@userID", userID);
                cmd.Parameters.AddWithValue("@itemName", itemName);
                cmd.Parameters.AddWithValue("@brand", brand);
                cmd.Parameters.AddWithValue("@serialNo", serialNo);
                cmd.Parameters.AddWithValue("@quantity", quantity);
                cmd.Parameters.AddWithValue("@unitPrice", unitPrice);
                cmd.Parameters.AddWithValue("@supplier", supplier);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public int UpdateInv(int id, string itemName, string brand, string serialNo, int quantity, double unitPrice, string supplier)
        {
            string sql = "UPDATE tblInventory SET itemName=@itemName, brand=@brand, serialNo=@serialNo, " +
                         "quantity=@quantity, unitPrice=@unitPrice, supplier=@supplier " +
                         "WHERE id=@id";

            using (SqlConnection con = new SqlConnection(DatabaseOperations.ConString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@itemName", itemName);
                cmd.Parameters.AddWithValue("@brand", brand);
                cmd.Parameters.AddWithValue("@serialNo", serialNo);
                cmd.Parameters.AddWithValue("@quantity", quantity);
                cmd.Parameters.AddWithValue("@unitPrice", unitPrice);
                cmd.Parameters.AddWithValue("@supplier", supplier);

                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public int UpdateInvFromQuotation(int id, int quantity, double unitPrice)
        {

            string sql = "UPDATE tblInventory SET quantity = @quantity, unitPrice = @unitPrice WHERE id = @id";
            using (SqlConnection con = new SqlConnection(DatabaseOperations.ConString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@quantity", quantity);
                cmd.Parameters.AddWithValue("@unitPrice", unitPrice);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public int DeleteInv(int id)
        {
            string sql = "DELETE FROM tblInventory WHERE id=@id";
            using (SqlConnection con = new SqlConnection(DatabaseOperations.ConString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@id", id);

                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public DataSet Find(int id)
        {
            string sql = "SELECT * FROM tblInventory WHERE id=@id";
            using (SqlConnection con = new SqlConnection(DatabaseOperations.ConString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }

        public DataSet ViewAll()
        {
            string sql = "SELECT * FROM tblInventory";
            return DatabaseOperations.SelectQuery(sql);
        }
        public DataSet GetItemsToRestock()
        {
            string sql = "SELECT * FROM tblInventory WHERE quantity <= 5";
            using (SqlConnection con = new SqlConnection(DatabaseOperations.ConString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                con.Open();
                da.Fill(ds);
                return ds;
            }
        }
    }
}
