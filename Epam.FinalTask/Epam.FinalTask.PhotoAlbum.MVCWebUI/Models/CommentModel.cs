using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epam.FinalTask.PhotoAlbum.MVCWebUI.Models
{
    public class CommentModel
    {
        public int CommentId { get; set; }

        public string CommentText { get; set; }

        public DateTime CommentDate { get; set; }

        public int CommentAuthorId { get; set; }

        public bool Banned { get; set; }

        public int CommentImageId { get; set; }
    }
}