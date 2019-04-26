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
    public class SqlCommentsDao : ICommentsDao
    {
        private readonly string conStr;

        public SqlCommentsDao(string connectionString)
        {
            this.conStr = connectionString;
        }

        public bool Add(Comment comment)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(this.conStr))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "Comments_Add";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CommentText", comment.CommentText);
                    cmd.Parameters.AddWithValue("@CommentDate", comment.CommentDate);
                    cmd.Parameters.AddWithValue("@CommentAuthorId", comment.CommentAuthorId);
                    cmd.Parameters.AddWithValue("@Banned", comment.Banned);
                    cmd.Parameters.AddWithValue("@CommentImageId", comment.CommentImageId);

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

        public bool BanComment(Comment comment)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(this.conStr))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "Comments_CommentBan";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CommentId", comment.CommentId);

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

        public Comment GetCommentById(int commentId)
        {
            try
            {
                Comment comment = new Comment();

                using (SqlConnection con = new SqlConnection(this.conStr))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "Comments_GetCommentById";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CommentId", commentId);

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        comment.CommentId = (int)reader["CommentId"];
                        comment.CommentText = (string)reader["CommentText"];
                        comment.CommentDate = (DateTime)reader["CommentDate"];
                        comment.CommentAuthorId = (int)reader["CommentAuthorId"];
                        comment.Banned = (bool)reader["Banned"];
                        comment.CommentImageId = (int)reader["CommentImageId"];
                    }
                }

                if (comment.CommentId == 0)
                {
                    return null;
                }

                return comment;
            }
            catch (SqlException ex)
            {
                Logger.Log.Error("Connection with DB error.", ex);
                throw;
            }
        }

        public IEnumerable<Comment> GetCommentsForImage(int imageId)
        {
            try
            {
                List<Comment> comments = new List<Comment>();

                using (SqlConnection con = new SqlConnection(this.conStr))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "Comments_GetCommentsForImage";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ImageId", imageId);

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        comments.Add(new Comment
                        {
                            CommentId = (int)reader["CommentId"],
                            CommentText = (string)reader["CommentText"],
                            CommentDate = (DateTime)reader["CommentDate"],
                            CommentAuthorId = (int)reader["CommentAuthorId"],
                            Banned = (bool)reader["Banned"],
                            CommentImageId = (int)reader["CommentImageId"],
                        });
                    }
                }

                return comments;
            }
            catch (SqlException ex)
            {
                Logger.Log.Error("Connection with DB error.", ex);
                throw;
            }
        }

        public bool Remove(Comment comment)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(this.conStr))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "Comments_Remove";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CommentId", comment.CommentId);

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

        public bool UnbanComment(Comment comment)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(this.conStr))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "Comments_CommentUnban";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CommentId", comment.CommentId);

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
