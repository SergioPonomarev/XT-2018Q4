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
    public class SqlImagesDao : IImagesDao
    {
        private static readonly int bannedImageId = 1;
        private readonly string conStr;

        public SqlImagesDao(string connectionString)
        {
            this.conStr = connectionString;
        }

        public bool Add(Image image)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "Images_Add";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@MimeType", image.MimeType);
                    cmd.Parameters.AddWithValue("@ImageData", image.ImageData);
                    cmd.Parameters.AddWithValue("@ImageDateOfUpload", image.ImageDateOfUpload);
                    if (!string.IsNullOrWhiteSpace(image.Description))
                    {
                        cmd.Parameters.AddWithValue("@Description", image.Description);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    }
                    cmd.Parameters.AddWithValue("@ImageOwnerId", image.ImageOwnerId);
                    cmd.Parameters.AddWithValue("@Banned", image.Banned);

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

        public bool AddLikeToImage(Image image, int userId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "Images_AddLikeToImage";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@ImageId", image.ImageId);

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

        public bool BanImage(Image image)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "Images_ImageBan";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ImageId", image.ImageId);

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

        public IEnumerable<Image> GetAllImages()
        {
            try
            {
                List<Image> images = new List<Image>();

                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "Images_GetAllImages";
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        images.Add(new Image
                        {
                            ImageId = (int)reader["ImageId"],
                            MimeType = (string)reader["MimeType"],
                            ImageData = (string)reader["ImageData"],
                            ImageDateOfUpload = (DateTime)reader["ImageDateOfUpload"],
                            Description = reader["Description"] as string,
                            ImageOwnerId = (int)reader["ImageOwnerId"],
                            Banned = (bool)reader["Banned"],
                        });
                    }
                }

                return images;
            }
            catch (SqlException ex)
            {
                Logger.Log.Error("Connection with DB error.", ex);
                throw;
            }
        }

        public Image GetBannedImage()
        {
            try
            {
                Image image = new Image();

                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "Images_GetBannedImage";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ImageId", bannedImageId);

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        image.ImageId = (int)reader["ImageId"];
                        image.MimeType = (string)reader["MimeType"];
                        image.ImageData = (string)reader["ImageData"];
                        image.ImageDateOfUpload = (DateTime)reader["ImageDateOfUpload"];
                        image.Description = reader["Description"] as string;
                        image.ImageOwnerId = (int)reader["ImageOwnerId"];
                        image.Banned = (bool)reader["Banned"];
                    }
                }

                return image;
            }
            catch (SqlException ex)
            {
                Logger.Log.Error("Connection with DB error.", ex);
                throw;
            }
        }

        public Image GetImageById(int imageId)
        {
            try
            {
                Image image = new Image();

                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "Images_GetImageById";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ImageId", imageId);

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        image.ImageId = (int)reader["ImageId"];
                        image.MimeType = (string)reader["MimeType"];
                        image.ImageData = (string)reader["ImageData"];
                        image.ImageDateOfUpload = (DateTime)reader["ImageDateOfUpload"];
                        image.Description = reader["Description"] as string;
                        image.ImageOwnerId = (int)reader["ImageOwnerId"];
                        image.Banned = (bool)reader["Banned"];
                    }
                }

                if (image.ImageId == 0)
                {
                    return null;
                }

                return image;
            }
            catch (SqlException ex)
            {
                Logger.Log.Error("Connection with DB error.", ex);
                throw;
            }
        }

        public IEnumerable<int> GetLikesForImage(int imageId)
        {
            try
            {
                List<int> likes = new List<int>();

                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "Images_GetLikesForImage";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ImageId", imageId);

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        likes.Add((int)reader["UserId"]);
                    }
                }

                return likes;
            }
            catch (SqlException ex)
            {
                Logger.Log.Error("Connection with DB error.", ex);
                throw;
            }
        }

        public IEnumerable<Image> GetUserImages(int userId)
        {
            try
            {
                List<Image> images = new List<Image>();

                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "Images_GetUserImages";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserId", userId);

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        images.Add(new Image
                        {
                            ImageId = (int)reader["ImageId"],
                            MimeType = (string)reader["MimeType"],
                            ImageData = (string)reader["ImageData"],
                            ImageDateOfUpload = (DateTime)reader["ImageDateOfUpload"],
                            Description = reader["Description"] as string,
                            ImageOwnerId = (int)reader["ImageOwnerId"],
                            Banned = (bool)reader["Banned"],
                        });
                    }
                }

                return images;
            }
            catch (SqlException ex)
            {
                Logger.Log.Error("Connection with DB error.", ex);
                throw;
            }
        }

        public bool Remove(Image image)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "Images_Remove";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ImageId", image.ImageId);

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

        public bool RemoveLikeFromImage(Image image, int userId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "Images_RemoveLikeFromImage";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@ImageId", image.ImageId);

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

        public bool SetBannedImage(Image image)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "Images_SetBannedImage";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ImageId", bannedImageId);
                    cmd.Parameters.AddWithValue("@MimeType", image.MimeType);
                    cmd.Parameters.AddWithValue("@ImageData", image.ImageData);
                    cmd.Parameters.AddWithValue("@ImageDateOfUpload", image.ImageDateOfUpload);
                    cmd.Parameters.AddWithValue("@ImageOwnerId", image.ImageOwnerId);

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

        public bool UnbanImage(Image image)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "Images_ImageUnban";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ImageId", image.ImageId);

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
