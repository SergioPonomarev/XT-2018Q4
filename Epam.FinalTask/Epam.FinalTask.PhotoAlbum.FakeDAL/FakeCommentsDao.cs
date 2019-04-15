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

        public IEnumerable<Comment> GetCommentsForImage(int imageId)
        {
            return this.comments.Where(c => c.CommentImageId == imageId).ToArray();
        }
    }
}
