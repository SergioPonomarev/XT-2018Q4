using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.FinalTask.PhotoAlbum.DAL.Contracts;
using Epam.FinalTask.PhotoAlbum.Entities;
using Epam.FinalTask.PhotoAlbum.Log;

namespace Epam.FinalTask.PhotoAlbum.SqlDAL
{
    public class SqlUsersDao : IUsersDao
    {
        private readonly string conStr;
        private readonly IImagesDao imagesDao;

        public SqlUsersDao(string connectionString, IImagesDao imagesDao)
        {
            this.conStr = connectionString;
            this.imagesDao = imagesDao;
        }

        public bool Add(User user)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(this.conStr))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "Users_Add";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserName", user.UserName);
                    cmd.Parameters.AddWithValue("@UserRole", user.UserRole);
                    cmd.Parameters.AddWithValue("@UserAvatarId", user.UserAvatarId);
                    cmd.Parameters.AddWithValue("@Banned", user.Banned);

                    con.Open();
                    return cmd.ExecuteNonQuery() == 1;
                }
            }
            catch (SqlException ex)
            {
                Logger.Log.Error("Connection with DB error.", ex);
                return false;
            }
        }

        public bool BanUser(User user)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(this.conStr))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "Users_UserBan";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserId", user.UserId);

                    con.Open();
                    return cmd.ExecuteNonQuery() == 1;
                }
            }
            catch (SqlException ex)
            {
                Logger.Log.Error("Connection with DB error.", ex);
                return false;
            }
        }

        public bool DemoteToUser(User user)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(this.conStr))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "Users_DemoteToUser";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserId", user.UserId);

                    con.Open();
                    return cmd.ExecuteNonQuery() == 1;
                }
            }
            catch (SqlException ex)
            {
                Logger.Log.Error("Connection with DB error.", ex);
                return false;
            }
        }

        public User GetUserById(int userId)
        {
            try
            {
                User user = new User();

                using (SqlConnection con = new SqlConnection(this.conStr))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "Users_GetUserById";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserId", userId);

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        user.UserId = (int)reader["UserId"];
                        user.UserName = (string)reader["UserName"];
                        user.UserRole = (string)reader["UserRole"];
                        user.UserAvatarId = (int)reader["UserAvatarId"];
                        user.Banned = (bool)reader["Banned"];
                    }
                }

                if (user.UserId == 0)
                {
                    return null;
                }

                user.UserImages = this.imagesDao.GetUserImages(user.UserId);

                return user;
            }
            catch (SqlException ex)
            {
                Logger.Log.Error("Connection with DB error.", ex);
                throw;
            }
        }

        public User GetUserByUserName(string userName)
        {
            try
            {
                User user = new User();

                using (SqlConnection con = new SqlConnection(this.conStr))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "Users_GetUserByUserName";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserName", userName);

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        user.UserId = (int)reader["UserId"];
                        user.UserName = (string)reader["UserName"];
                        user.UserRole = (string)reader["UserRole"];
                        user.UserAvatarId = (int)reader["UserAvatarId"];
                        user.Banned = (bool)reader["Banned"];
                    }
                }

                if (user.UserId == 0)
                {
                    return null;
                }

                user.UserImages = this.imagesDao.GetUserImages(user.UserId);

                return user;
            }
            catch (SqlException ex)
            {
                Logger.Log.Error("Connection with DB error.", ex);
                throw;
            }
        }

        public bool PromoteToAdmin(User user)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(this.conStr))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "Users_PromoteToAdmin";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserId", user.UserId);

                    con.Open();
                    return cmd.ExecuteNonQuery() == 1;
                }
            }
            catch (SqlException ex)
            {
                Logger.Log.Error("Connection with DB error.", ex);
                return false;
            }
        }

        public bool Remove(User user)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(this.conStr))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "Users_Remove";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserId", user.UserId);

                    con.Open();
                    return cmd.ExecuteNonQuery() == 1;
                }
            }
            catch (SqlException ex)
            {
                Logger.Log.Error("Connection with DB error.", ex);
                return false;
            }
        }

        public bool UnbanUser(User user)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(this.conStr))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "Users_UserUnban";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserId", user.UserId);

                    con.Open();
                    return cmd.ExecuteNonQuery() == 1;
                }
            }
            catch (SqlException ex)
            {
                Logger.Log.Error("Connection with DB error.", ex);
                return false;
            }
        }
    }
}
