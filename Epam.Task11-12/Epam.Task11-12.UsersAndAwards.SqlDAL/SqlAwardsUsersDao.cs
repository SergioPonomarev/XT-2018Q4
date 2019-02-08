using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task11_12.UsersAndAwards.DAL.Interfaces;
using Epam.Task11_12.UsersAndAwards.Entities;

namespace Epam.Task11_12.UsersAndAwards.SqlDAL
{
    public class SqlAwardsUsersDao : IAwardsUsersDao
    {
        private readonly string conStr;

        public SqlAwardsUsersDao(string connectionString)
        {
            this.conStr = connectionString;
        }

        public bool AwardUser(AwardUser awardUser)
        {
            using (var con = new SqlConnection(conStr))
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = "AwardsUsers_Add";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserId", awardUser.UserId);
                cmd.Parameters.AddWithValue("@AwardId", awardUser.AwardId);

                con.Open();
                return cmd.ExecuteNonQuery() == 1;
            }
        }

        public bool RemoveAwardFromUser(AwardUser awardUser)
        {
            using (var con = new SqlConnection(conStr))
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = "AwardsUsers_RemoveAwardFromUser";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserId", awardUser.UserId);
                cmd.Parameters.AddWithValue("@AwardId", awardUser.AwardId);

                con.Open();
                return cmd.ExecuteNonQuery() == 1;
            }
        }
    }
}
