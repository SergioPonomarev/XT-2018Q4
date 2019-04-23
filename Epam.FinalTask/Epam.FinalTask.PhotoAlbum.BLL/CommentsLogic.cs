using System;
using System.Collections.Generic;
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

        public void BanComment(Comment comment)
        {
            this.commentsDao.BanComment(comment);
        }

        public Comment GetCommentById(int commentId)
        {
            return this.commentsDao.GetCommentById(commentId);
        }

        public IEnumerable<Comment> GetCommentsForImage(int imageId)
        {
            return this.commentsDao.GetCommentsForImage(imageId).ToArray();
        }

        public bool Remove(Comment comment)
        {
            return this.commentsDao.Remove(comment);
        }

        public void UnbanComment(Comment comment)
        {
            this.commentsDao.UnbanComment(comment);
        }
    }
}
