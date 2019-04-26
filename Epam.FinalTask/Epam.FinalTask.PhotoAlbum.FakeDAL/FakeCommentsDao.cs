using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.FinalTask.PhotoAlbum.DAL.Contracts;
using Epam.FinalTask.PhotoAlbum.Entities;

namespace Epam.FinalTask.PhotoAlbum.FakeDAL
{
    public class FakeCommentsDao : ICommentsDao
    {
        private static int id = 1;

        private List<Comment> comments;

        public FakeCommentsDao()
        {
            this.comments = new List<Comment>();
        }

        public bool Add(Comment comment)
        {
            try
            {
                comment.CommentId = id++;
                this.comments.Add(comment);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool BanComment(Comment comment)
        {
            this.comments.Remove(comment);

            comment.Banned = true;

            this.comments.Add(comment);

            return true;
        }

        public Comment GetCommentById(int commentId)
        {
            return this.comments.FirstOrDefault(c => c.CommentId == commentId);
        }

        public IEnumerable<Comment> GetCommentsForImage(int imageId)
        {
            return this.comments.Where(c => c.CommentImageId == imageId).ToArray();
        }

        public bool Remove(Comment comment)
        {
            return this.comments.Remove(comment);
        }

        public bool UnbanComment(Comment comment)
        {
            this.comments.Remove(comment);

            comment.Banned = false;

            this.comments.Add(comment);

            return true;
        }
    }
}
