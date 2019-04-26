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
    public class SqlAvatarsDao : IAvatarsDao
    {
        private static readonly int defaultAvatarId = 1;
        private readonly string conStr;

        public SqlAvatarsDao(string connectionString)
        {
            this.conStr = connectionString;
        }

        public Avatar GetDefaultAvatar()
        {
            try
            {
                Avatar avatar = new Avatar();

                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "Avatars_GetDefaultAvatar";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@AvatarId", defaultAvatarId);

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        avatar.AvatarId = (int)reader["AvatarId"];
                        avatar.MimeType = (string)reader["MimeType"];
                        avatar.AvatarData = (string)reader["AvatarData"];
                    }
                }

                if (avatar.AvatarId == 0)
                {
                    return null;
                }

                return avatar;
            }
            catch (SqlException ex)
            {
                Logger.Log.Error("Connection with DB error.", ex);
                throw;
            }
        }

        public Avatar GetUserAvatar(int avatarId)
        {
            try
            {
                Avatar avatar = new Avatar();

                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "Avatars_GetUserAvatar";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@AvatarId", avatarId);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        avatar.AvatarId = (int)reader["AvatarId"];
                        avatar.MimeType = (string)reader["MimeType"];
                        avatar.AvatarData = (string)reader["AvatarData"];
                    }
                }

                if (avatar.AvatarId == 0)
                {
                    return null;
                }

                return avatar;
            }
            catch (SqlException ex)
            {
                Logger.Log.Error("Connection with DB error.", ex);
                throw;
            }
        }

        public bool SetAvatarToUser(Avatar newAvatar, User user)
        {
            try
            {
                int oldAvatarId = user.UserAvatarId;
                int newAvatarId = this.Add(newAvatar);
                bool check = false;

                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "Avatars_SetAvatarToUser";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserId", user.UserId);
                    cmd.Parameters.AddWithValue("@AvatarId", newAvatarId);

                    con.Open();
                    check = cmd.ExecuteNonQuery() == 1;
                }

                if (oldAvatarId != defaultAvatarId)
                {
                    if (!this.Remove(oldAvatarId))
                    {
                        return false;
                    }
                }

                return check;
            }
            catch (SqlException ex)
            {
                Logger.Log.Error("Connection with DB error.", ex);
                return false;
            }
        }

        public int Add(Avatar avatar)
        {
            try
            {
                int avatarId;

                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "Avatars_Add";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@MimeType", avatar.MimeType);
                    cmd.Parameters.AddWithValue("@AvatarData", avatar.AvatarData);
                    cmd.Parameters.Add(new SqlParameter("@AvatarId", SqlDbType.Int) { Direction = ParameterDirection.Output });

                    con.Open();
                    cmd.ExecuteNonQuery();
                    avatarId = (int)cmd.Parameters["@AvatarId"].Value;
                }

                return avatarId;
            }
            catch (SqlException ex)
            {
                Logger.Log.Error("Connection with DB error.", ex);
                throw;
            }
        }

        public bool Remove(int avatarId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "Avatars_Remove";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@AvatarId", avatarId);

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

        public bool SetDefaultAvatar(Avatar avatar)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "Avatars_SetDefaultAvatar";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@AvatarId", defaultAvatarId);
                    cmd.Parameters.AddWithValue("@MimeType", avatar.MimeType);
                    cmd.Parameters.AddWithValue("@AvatarData", avatar.AvatarData);

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
