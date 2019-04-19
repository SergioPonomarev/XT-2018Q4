using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.FinalTask.PhotoAlbum.Entities;

namespace Epam.FinalTask.PhotoAlbum.BLL.Contracts
{
    public interface ICommentsLogic
    {
        bool Add(string commentText, Image image, User visitor);

        IEnumerable<Comment> GetCommentsForImage(int imageId);

        Comment GetCommentById(int commentId);

        bool Remove(Comment comment);

        void BanComment(Comment comment);

        void UnbanComment(Comment comment);
    }
}
