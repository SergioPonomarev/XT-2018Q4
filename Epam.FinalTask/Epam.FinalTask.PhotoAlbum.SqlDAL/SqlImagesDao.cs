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
    public class SqlImagesDao : IImagesDao
    {
        private readonly string conStr;

        public SqlImagesDao(string connectionString)
        {
            this.conStr = connectionString;
        }

        public bool Add(Image image)
        {
            throw new NotImplementedException();
        }

        public void AddLikeToImage(Image image, int visitorId)
        {
            throw new NotImplementedException();
        }

        public void BanImage(Image image)
        {
            throw new NotImplementedException();
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
            catch (Exception)
            {
                throw;
            }
        }

        public Image GetBannedImage()
        {
            throw new NotImplementedException();
        }

        public Image GetImageById(int imageId)
        {
            throw new NotImplementedException();
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
            catch (Exception)
            {
                throw;
            }
        }

        public void Remove(Image image)
        {
            throw new NotImplementedException();
        }

        public void RemoveLikeFromImage(Image image, int visitorId)
        {
            throw new NotImplementedException();
        }

        public void SetBannedImage(Image image)
        {
            throw new NotImplementedException();
        }

        public void UnbanImage(Image image)
        {
            throw new NotImplementedException();
        }
    }
}
