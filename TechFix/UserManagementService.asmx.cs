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
    /// Summary description for UserManagementService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class UserManagementService : System.Web.Services.WebService
    {

        [WebMethod]
        public int InsertUser(string fName, string userName, string password,string uMail, string userRole)
        {
            User user = new User();
            return user.InsertUser(fName, userName, password,uMail, userRole);
        }

        [WebMethod]
        public int UpdateUser(int id, string fName, string uMail, string userRole)
        {
            User user = new User();
            return user.UpdateUser(id, fName, uMail, userRole);
        }

        [WebMethod]
        public int DeleteUser(int id)
        {
            User user = new User();
            return user.DeleteUser(id);
        }

        [WebMethod]
        public string IsValidUser(string uName, string pWord)
        {
            User user = new User();
            return user.IsValidUser(uName, pWord);
        }
        [WebMethod]
        public int GetUserID(string uName, string pWord)
        {
            User user = new User();
            return user.GetUserID(uName, pWord);
        }

        [WebMethod]
        public string GetUserRole(string uName, string pWord)
        {
            User user = new User();
            return user.GetUserRole(uName, pWord);
        }
        [WebMethod]
        public DataSet FindUser(int id)
        {
            User user = new User();
            return user.FindUser(id);
        }
        [WebMethod]
        public DataSet ViewAllUsers()
        {
            User user = new User();
            return user.ViewAllUsers();
        }
        [WebMethod]
        public int UpdateUserProfile(int id, string fName, string uMail, string password)
        {
            try
            {
                User user = new User();
                return user.UpdateProfile(id, fName, uMail, password);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating user profile: {ex.Message}");
                throw new Exception($"Error updating user profile: {ex.Message}");
            }
        }

    }
}
