using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.FinalTask.PhotoAlbum.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }

        public string CommentText { get; set; }

        public DateTime CommentDate { get; set; }

        public User CommentAuthor { get; set; }

        public bool Banned { get; set; }
    }
}
