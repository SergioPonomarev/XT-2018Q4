using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Epam.FinalTask.PhotoAlbum.Entities;

namespace Epam.FinalTask.PhotoAlbum.MVCWebUI.Models
{
    public class CommentModel
    {
        public int CommentId { get; set; }

        [StringLength(140, ErrorMessage = "Comment cannot be greater than 140 characters.")]
        [Required]
        public string CommentText { get; set; }

        public DateTime CommentDate { get; set; }

        public UserModel CommentAuthor { get; set; }

        public bool Banned { get; set; }

        public int CommentImageId { get; set; }

        public static implicit operator CommentModel(Comment comment)
        {
            return new CommentModel
            {
                CommentId = comment.CommentId,
                CommentText = comment.CommentText,
                CommentDate = comment.CommentDate,
                Banned = comment.Banned,
                CommentImageId = comment.CommentImageId,
            };
        }

        public static explicit operator Comment(CommentModel commentModel)
        {
            return new Comment
            {
                CommentId = commentModel.CommentId,
                CommentText = commentModel.CommentText,
                CommentDate = commentModel.CommentDate,
                CommentAuthorId = commentModel.CommentAuthor.UserId,
                Banned = commentModel.Banned,
                CommentImageId = commentModel.CommentImageId,
            };
        }
    }
}