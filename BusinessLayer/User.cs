using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
    public class User
    {
        public int ID { get; set; }
        public string FName { get; set; }
        public string UserName { get; set; }
        public string UPassword { get; set; }
        public string Email { get; set; }
        public string UserRole { get; set; }

        public static string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

            public int InsertUser(string fName, string userName, string password, string uMail, string userRole)
            {
                string hashedPassword = HashPassword(password);
                string sql = "INSERT INTO tblUser (fName, uName, pWord,uMail, uRole) VALUES (@fName, @uName, @pWord,@uMail, @uRole)";
                using (SqlConnection con = new SqlConnection(DatabaseOperations.ConString))
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@fName", fName);
                    cmd.Parameters.AddWithValue("@uName", userName);
                    cmd.Parameters.AddWithValue("@pWord", hashedPassword);
                    cmd.Parameters.AddWithValue("@uMail", uMail);
                    cmd.Parameters.AddWithValue("@uRole", userRole ?? (object)DBNull.Value); 

                    con.Open();
                    return cmd.ExecuteNonQuery(); 
                }
            }

        public int UpdateUser(int id, string fName, string uMail, string userRole)
        {
            string sql = "UPDATE tblUser SET fName=@fName, uMail=@uMail, uRole=@uRole WHERE id=@id";
            using (SqlConnection con = new SqlConnection(DatabaseOperations.ConString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@fName", fName);
                cmd.Parameters.AddWithValue("@uMail", uMail);
                cmd.Parameters.AddWithValue("@uRole", userRole ?? (object)DBNull.Value); 

                con.Open();
                return cmd.ExecuteNonQuery(); 
            }
        }


        public int DeleteUser(int id)
            {
                string sql = "DELETE FROM tblUser WHERE id=@id";
                using (SqlConnection con = new SqlConnection(DatabaseOperations.ConString))
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    con.Open();
                    return cmd.ExecuteNonQuery(); 
                }
            }

            public string IsValidUser(string uName, string pWord)
            {
            string hashedPassword = User.HashPassword(pWord);
            using (SqlConnection con = new SqlConnection(DatabaseOperations.ConString))
            {
                con.Open();
                string query = "SELECT uRole FROM tblUser WHERE uName = @Username AND pWord = @Password";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Username", uName);
                    cmd.Parameters.AddWithValue("@Password", hashedPassword);
                    object result = cmd.ExecuteScalar();
                    return result?.ToString();
                }
            }
        }
        public int GetUserID(string uName, string pWord)
        {
            string hashedPassword = User.HashPassword(pWord);
            using (SqlConnection con = new SqlConnection(DatabaseOperations.ConString))
            {
                con.Open();
                string query = "SELECT id FROM tblUser WHERE uName = @Username AND pWord = @Password";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Username", uName);
                    cmd.Parameters.AddWithValue("@Password", hashedPassword);
                    object result = cmd.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int userId))
                    {
                        return userId;
                    }
                    else
                    {
                        return -1; 
                    }
                }
            }
        }

        public string GetUserRole(string uName, string pWord)
            {
                string hashedPassword = HashPassword(pWord);
                string sql = "SELECT uRole FROM tblUser WHERE uName=@uName AND pWord=@hashedPassword";
                using (SqlConnection con = new SqlConnection(DatabaseOperations.ConString))
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@uName", uName);
                    cmd.Parameters.AddWithValue("@hashedPassword", hashedPassword);
                    con.Open();
                    object result = cmd.ExecuteScalar();
                    return result?.ToString();
                }
            }

        public DataSet FindUser(int id)
        {
            string sql = "SELECT fName, uName, uMail, uRole FROM tblUser WHERE id=@id";
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


        public DataSet ViewAllUsers()
        {
            string sql = "SELECT * FROM tblUser";
            return DatabaseOperations.SelectQuery(sql);
        }

        public int UpdateProfile(int id, string fName, string uMail, string password)
        {
            string hashedPassword = HashPassword(password);
            string sql = "UPDATE tblUser SET fName=@fName, uMail=@uMail, pWord=@password WHERE id=@id";
            using (SqlConnection con = new SqlConnection(DatabaseOperations.ConString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@fName", fName);
                cmd.Parameters.AddWithValue("@uMail", uMail);
                cmd.Parameters.AddWithValue("@password", hashedPassword);

                con.Open();
                try
                {
                    return cmd.ExecuteNonQuery();
                }
                catch (SqlException sqlEx)
                {
                    Console.WriteLine($"SQL Error: {sqlEx.Message}");
                    throw new Exception($"SQL Error: {sqlEx.Message}");
                }
            }
        }
    }

    }

