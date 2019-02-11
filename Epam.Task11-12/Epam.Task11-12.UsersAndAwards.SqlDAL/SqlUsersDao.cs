using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Epam.Task11_12.UsersAndAwards.DAL.Interfaces;
using Epam.Task11_12.UsersAndAwards.Entities;

namespace Epam.Task11_12.UsersAndAwards.SqlDAL
{
    public class SqlUsersDao : IUsersDao
    {
        private const int defaultImageId = 1;
        private const string defaultRole = "User";
        private const string adminRole = "Admin";
        private readonly string conStr;

        public SqlUsersDao(string connectionString)
        {
            this.conStr = connectionString;
        }

        public bool Add(User user)
        {
            using (var con = new SqlConnection(conStr))
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = "Users_Add";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", user.UserName);
                cmd.Parameters.AddWithValue("@UserDateOfBirth", user.UserDateOfBirth);
                cmd.Parameters.AddWithValue("@UserImageId", defaultImageId);
                cmd.Parameters.AddWithValue("@UserRole", defaultRole);

                con.Open();
                return cmd.ExecuteNonQuery() == 1;
            }
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
                            UserImageId = (int)reader["UserImageId"],
                            UserRole = (string)reader["UserRole"],
                        });
                }
            }

            foreach (var user in result)
            {
                user.UserAwards = this.GetAwardsByUserId(user.UserId);
            }

            return result;
        }

        public User GetUserById(int userId)
        {
            User user = new User();
            using (var con = new SqlConnection(conStr))
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = "Users_GetUserById";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserId", userId);

                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    user.UserId = (int)reader["UserId"];
                    user.UserName = (string)reader["UserName"];
                    user.UserDateOfBirth = (DateTime)reader["UserDateOfBirth"];
                    user.UserImageId = (int)reader["UserImageId"];
                    user.UserRole = (string)reader["UserRole"];
                }
            }

            if (user.UserId == 0)
            {
                return null;
            }

            user.UserAwards = this.GetAwardsByUserId(userId);

            return user;
        }

        public User GetUserByUserName(string userName)
        {
            User user = new User();
            using (var con = new SqlConnection(conStr))
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = "Users_GetUserByUserName";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserName", userName);

                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    user.UserId = (int)reader["UserId"];
                    user.UserName = (string)reader["UserName"];
                    user.UserDateOfBirth = (DateTime)reader["UserDateOfBirth"];
                    user.UserImageId = (int)reader["UserImageId"];
                    user.UserRole = (string)reader["UserRole"];
                }
            }

            if (user.UserId == 0)
            {
                return null;
            }

            user.UserAwards = this.GetAwardsByUserId(user.UserId);

            return user;
        }

        public bool Remove(int userId)
        {
            using (var con = new SqlConnection(conStr))
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = "Users_RemoveUserById";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", userId);

                con.Open();
                return cmd.ExecuteNonQuery() == 1;
            }
        }

        public bool Update(User user)
        {
            using (var con = new SqlConnection(conStr))
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = "Users_Update";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", user.UserId);
                cmd.Parameters.AddWithValue("@UserDateOfBirth", user.UserDateOfBirth);

                con.Open();
                return cmd.ExecuteNonQuery() == 1;
            }
        }

        public IEnumerable<Award> GetAwardsByUserId(int userId)
        {
            var result = new List<Award>();
            using (var con = new SqlConnection(conStr))
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = "Awards_GetAwardsByUserId";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserId", userId);

                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(
                        new Award
                        {
                            AwardId = (int)reader["AwardId"],
                            AwardTitle = (string)reader["AwardTitle"],
                            AwardImageId = (int)reader["AwardImageId"],
                        });
                }
            }

            return result;
        }

        public bool AddImageToUser(Image image, User user)
        {
            int imageId = this.AddUserImage(image);

            if (imageId == 0)
            {
                return false;
            }

            using (var con = new SqlConnection(conStr))
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = "Users_AddImageToUser";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserId", user.UserId);
                cmd.Parameters.AddWithValue("@ImageId", imageId);

                con.Open();
                return cmd.ExecuteNonQuery() == 1;
            }
        }

        public int AddUserImage(Image image)
        {
            int imageId = 0;

            using (var con = new SqlConnection(conStr))
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = "UsersImages_Add";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MimeType", image.MimeType);
                cmd.Parameters.AddWithValue("@ImageData", image.ImageData);
                cmd.Parameters.Add(new SqlParameter("@ImageId", SqlDbType.Int) { Direction = ParameterDirection.Output });

                con.Open();

                if (cmd.ExecuteNonQuery() > 0)
                {
                    imageId = (int)cmd.Parameters["@ImageId"].Value;
                }
            }

            return imageId;
        }

        public bool AddDefaultUserImage(Image image)
        {
            using (var con = new SqlConnection(conStr))
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = "UsersImages_AddDefault";
                cmd.CommandType = CommandType.StoredProcedure;

                //cmd.Parameters.AddWithValue("@ImageId", defaultImageId);
                cmd.Parameters.AddWithValue("@MimeType", image.MimeType);
                cmd.Parameters.AddWithValue("@ImageData", image.ImageData);

                con.Open();
                return cmd.ExecuteNonQuery() == 1;
            }
        }

        public bool PromoteToAdmin(string userName)
        {
            using (var con = new SqlConnection(conStr))
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = "Users_PromoteToAdmin";

                cmd.Parameters.AddWithValue("@UserName", userName);
                cmd.Parameters.AddWithValue("@UserRole", adminRole);

                con.Open();
                return cmd.ExecuteNonQuery() == 1;
            }
        }
    }
}
