using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.FinalTask.PhotoAlbum.Entities;

namespace Epam.FinalTask.PhotoAlbum.DAL.Contracts
{
    public interface ICommentsDao
    {
        IEnumerable<Comment> GetCommentsForImage(int imageId);

        bool Add(Comment comment);

        Comment GetCommentById(int commentId);

        bool Remove(Comment comment);

        bool BanComment(Comment comment);

        bool UnbanComment(Comment comment);
    }
}
