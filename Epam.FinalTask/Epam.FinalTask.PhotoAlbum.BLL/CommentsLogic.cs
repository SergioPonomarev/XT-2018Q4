using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.FinalTask.PhotoAlbum.BLL.Contracts;
using Epam.FinalTask.PhotoAlbum.DAL.Contracts;
using Epam.FinalTask.PhotoAlbum.Entities;

namespace Epam.FinalTask.PhotoAlbum.BLL
{
    public class CommentsLogic : ICommentsLogic
    {
        private readonly ICommentsDao commentsDao;

        public CommentsLogic(ICommentsDao commentsDao)
        {
            this.commentsDao = commentsDao;
        }

        public bool Add(string commentText, Image image, User user)
        {
            if (string.IsNullOrWhiteSpace(commentText))
            {
                return false;
            }

            Comment comment = new Comment
            {
                CommentText = commentText,
                CommentDate = DateTime.Now,
                CommentAuthorId = user.UserId,
                CommentImageId = image.ImageId,
                Banned = false,
            };

            return this.commentsDao.Add(comment);
        }

        public bool BanComment(Comment comment)
        {
            return this.commentsDao.BanComment(comment);
        }

        public Comment GetCommentById(int commentId)
        {
            try
            {
                return this.commentsDao.GetCommentById(commentId);
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public IEnumerable<Comment> GetCommentsForImage(int imageId)
        {
            try
            {
                return this.commentsDao.GetCommentsForImage(imageId).ToArray();
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public bool Remove(Comment comment)
        {
            return this.commentsDao.Remove(comment);
        }

        public bool UnbanComment(Comment comment)
        {
            return this.commentsDao.UnbanComment(comment);
        }
    }
}
