using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace GettingReal
{
    class Admin
    {
        private static string connectionsString =
            "Server=EALSQL1.eal.local; Database = DB2017_C03; User Id = user_C03; PassWord=SesamLukOp_03;";

        public string CheckUserNameAndPassword(string userName, string password)
        {
            using (SqlConnection kNumberDB = new SqlConnection(connectionsString))
            {
                try
                {
                    kNumberDB.Open();

                    SqlCommand admin = new SqlCommand("spCheckCredentials", kNumberDB);
                    admin.CommandType = CommandType.StoredProcedure;
                    admin.Parameters.Add(new SqlParameter("@SentInUserName", userName));
                    admin.Parameters.Add(new SqlParameter("@SentInPassword", password));

                    SqlDataReader receivedUsernameAndPassword = admin.ExecuteReader();
                    while (receivedUsernameAndPassword.Read())
                    {
                        userName = receivedUsernameAndPassword.GetString(0);
                        password = receivedUsernameAndPassword.GetString(1);
                    }
                    return userName + password;
                }
                catch (SqlException error)
                {
                    Console.WriteLine("Fejl: " + error.Message);
                }
                return "";
            }
        }

        public int ChangePasswordInDB(string userName, string newPassword)
        {
            string hasPasswordUpdated = "";
            using (SqlConnection kNumberDB = new SqlConnection(connectionsString))
            {
                try
                {
                    kNumberDB.Open();

                    SqlCommand changePassword = new SqlCommand("spChangeAdminPassword", kNumberDB);
                    changePassword.CommandType = CommandType.StoredProcedure;
                    changePassword.Parameters.Add(new SqlParameter("@Username", userName));
                    changePassword.Parameters.Add(new SqlParameter("@UpdatePassword", newPassword));

                    SqlDataReader updatedPassword = changePassword.ExecuteReader();

               
                    hasPasswordUpdated = updatedPassword["Pass"].ToString();

                    if (newPassword == hasPasswordUpdated)
                    {
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }

                }
                catch (SqlException error)
                {
                    Console.WriteLine("Fejl: " + error.Message);
                    return 2;
                }
            }
        }
    }
}
