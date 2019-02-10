using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task11_12.UsersAndAwards.DAL.Interfaces;

namespace Epam.Task11_12.UsersAndAwards.SqlDAL
{
    public class SqlAccountsDao : IAccountsDao
    {
        private readonly string conStr;

        public SqlAccountsDao(string connectionString)
        {
            this.conStr = connectionString;
        }

        public string GetPassByLogin(string login)
        {
            string hashedPassFromDB = null;

            using (var con = new SqlConnection(conStr))
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = "Users_GetPassByLogin";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Login", login);

                con.Open();

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    hashedPassFromDB = reader["UserPassword"] as string;
                }
            }

            return hashedPassFromDB;
        }

        public bool SetPassToUser(string userName, string hashedPass)
        {
            using (var con = new SqlConnection(conStr))
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = "Users_SetPassToUser";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserName", userName);
                cmd.Parameters.AddWithValue("@HashedPass", hashedPass);

                con.Open();

                return cmd.ExecuteNonQuery() == 1;
            }
        }
    }
}
