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

        public IEnumerable<Comment> GetCommentsForImage(int imageId)
        {
            throw new NotImplementedException();
        }
    }
}
