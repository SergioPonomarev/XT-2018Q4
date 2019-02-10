using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Epam.Task11_12.UsersAndAwards.DAL.Interfaces;
using Epam.Task11_12.UsersAndAwards.Entities;

namespace Epam.Task11_12.UsersAndAwards.SqlDAL
{
    public class SqlAwardsDao : IAwardsDao
    {
        private readonly string conStr;

        public SqlAwardsDao(string connectionString)
        {
            this.conStr = connectionString;
        }

        public bool Add(Award award)
        {
            using (var con = new SqlConnection(conStr))
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = "Awards_Add";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AwardTitle", award.AwardTitle);

                con.Open();
                return cmd.ExecuteNonQuery() == 1;
            }
        }

        public IEnumerable<Award> GetAll()
        {
            var result = new List<Award>();
            using (var con = new SqlConnection(conStr))
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = "Awards_GetAll";
                cmd.CommandType = CommandType.StoredProcedure;

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

        public Award GetAwardById(int awardId)
        {
            Award award = new Award();
            using (var con = new SqlConnection(conStr))
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = "Awards_GetAwardById";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@AwardId", awardId);

                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    award.AwardId = (int)reader["AwardId"];
                    award.AwardTitle = (string)reader["AwardTitle"];
                    award.AwardImageId = (int)reader["AwardImageId"];
                }
            }

            if (award.AwardId == 0)
            {
                return null;
            }

            return award;
        }

        public Award GetAwardByAwardTitle(string awardTitle)
        {
            Award award = new Award();
            using (var con = new SqlConnection(conStr))
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = "Awards_GetAwardByTitle";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@AwardTitle", awardTitle);

                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    award.AwardId = (int)reader["AwardId"];
                    award.AwardTitle = (string)reader["AwardTitle"];
                    award.AwardImageId = (int)reader["AwardImageId"];
                }
            }

            if (award.AwardId == 0)
            {
                return null;
            }

            return award;
        }

        public bool Remove(int awardId)
        {
            using (var con = new SqlConnection(conStr))
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = "Awards_RemoveAwardsById";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AwardId", awardId);

                con.Open();
                return cmd.ExecuteNonQuery() == 1;
            }
        }

        public bool Update(Award award)
        {
            using (var con = new SqlConnection(conStr))
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = "Awards_Update";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@AwardId", award.AwardId);
                cmd.Parameters.AddWithValue("@AwardTitle", award.AwardTitle);

                con.Open();
                return cmd.ExecuteNonQuery() == 1;
            }
        }

        public bool AddImageToAward(Image image, Award award)
        {
            int imageId = this.AddAwardImage(image);

            if (imageId == 0)
            {
                return false;
            }

            using (var con = new SqlConnection(conStr))
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = "Awards_AddImageToAward";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@AwardId", award.AwardId);
                cmd.Parameters.AddWithValue("@ImageId", imageId);

                con.Open();
                return cmd.ExecuteNonQuery() == 1;
            }
        }

        public int AddAwardImage(Image image)
        {
            int imageId = 0;

            using (var con = new SqlConnection(conStr))
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = "AwardsImages_Add";
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

        public bool AddDefaultAwardImage(Image image)
        {
            using (var con = new SqlConnection(conStr))
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = "AwardsImage_AddDefault";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MimeType", image.MimeType);
                cmd.Parameters.AddWithValue("@ImageData", image.ImageData);

                con.Open();
                return cmd.ExecuteNonQuery() == 1;
            }
        }
    }
}
