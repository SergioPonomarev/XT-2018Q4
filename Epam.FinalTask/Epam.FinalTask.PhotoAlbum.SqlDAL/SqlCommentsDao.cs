using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.FinalTask.PhotoAlbum.DAL.Contracts;
using Epam.FinalTask.PhotoAlbum.Entities;

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
            throw new NotImplementedException();
        }

        public void BanComment(Comment comment)
        {
            throw new NotImplementedException();
        }

        public Comment GetCommentById(int commentId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Comment> GetCommentsForImage(int imageId)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Comment comment)
        {
            throw new NotImplementedException();
        }

        public void UnbanComment(Comment comment)
        {
            throw new NotImplementedException();
        }
    }
}
