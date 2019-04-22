using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.FinalTask.PhotoAlbum.DAL.Contracts;

namespace Epam.FinalTask.PhotoAlbum.SqlDAL
{
    public class SqlAccountsDao : IAccountsDao
    {
        private readonly string conStr;

        public SqlAccountsDao(string connectionString)
        {
            this.conStr = connectionString;
        }

        public string GetPassByUserId(int userId)
        {
            try
            {
                string result = null;

                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "Accounts_GetPassByUserId";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserId", userId);

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        result = (string)reader["UserPassword"];
                    }
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool SetPassToUser(int userId, string hashedPass)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "Accounts_SetPassToUser";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@UserPass", hashedPass);

                    con.Open();
                    return cmd.ExecuteNonQuery() == 1;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
