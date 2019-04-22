using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.FinalTask.PhotoAlbum.DAL.Contracts;
using Epam.FinalTask.PhotoAlbum.Entities;

namespace Epam.FinalTask.PhotoAlbum.SqlDAL
{
    public class SqlAvatarsDao : IAvatarsDao
    {
        private readonly string conStr;

        public SqlAvatarsDao(string connectionString)
        {
            this.conStr = connectionString;
        }

        public Avatar GetDefaultAvatar()
        {
            throw new NotImplementedException();
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

                return avatar;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SetAvatarToUser(Avatar newAvatar, User user)
        {
            throw new NotImplementedException();
        }

        public void SetDefaultAvatar(Avatar avatar)
        {
            throw new NotImplementedException();
        }
    }
}
