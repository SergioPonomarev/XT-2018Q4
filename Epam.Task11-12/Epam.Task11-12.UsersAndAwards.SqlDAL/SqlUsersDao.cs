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
    public class SqlUsersDao : IUsersDao
    {
        private readonly string conStr;

        public SqlUsersDao(string connectionString)
        {
            this.conStr = connectionString;
        }

        public bool Add(User user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            var result = new List<User>();
            using (var con = new SqlConnection(conStr))
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = "Users_GetAll";
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(
                        new User
                        {
                            UserId = (int)reader["UserId"],
                            UserName = (string)reader["UserName"],
                            UserDateOfBirth = (DateTime)reader["UserDateOfBirth"],
                        });
                }
            }

            foreach (var user in result)
            {
                user.UserAwards = this.GetAwardsByUserId(user);
            }

            return result;
        }

        public User GetUserById(int userId)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int userId)
        {
            throw new NotImplementedException();
        }

        public bool Update(int userId, string userName, DateTime userDateOfBirth)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<Award> GetAwardsByUserId(User user)
        {
            var result = new List<Award>();
            using (var con = new SqlConnection(conStr))
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = "Awards_GetAwardsByUserId";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserId", user.UserId);

                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(
                        new Award
                        {
                            AwardId = (int)reader["AwardId"],
                            AwardTitle = (string)reader["AwardTitle"],
                        });
                }

            }

            return result;
        }
    }
}
