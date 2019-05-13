using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Epam.FinalTask.PhotoAlbum.Entities;

namespace Epam.FinalTask.PhotoAlbum.MVCWebUI.Models
{
    public class ImageModel
    {
        public int ImageId { get; set; }

        public string MimeType { get; set; }

        public string ImageData { get; set; }

        public DateTime ImageDateOfUpload { get; set; }

        public string Description { get; set; }

        public int ImageOwnerId { get; set; }

        public bool Banned { get; set; }

        public IEnumerable<CommentModel> Comments { get; set; }

        public IEnumerable<int> Likes { get; set; }

        public static implicit operator ImageModel(Image image)
        {
            return new ImageModel
            {
                ImageId = image.ImageId,
                MimeType = image.MimeType,
                ImageData = image.ImageData,
                ImageDateOfUpload = image.ImageDateOfUpload,
                Description = image.Description,
                ImageOwnerId = image.ImageOwnerId,
                Banned = image.Banned,
            };
        }

        public static explicit operator Image(ImageModel imageModel)
        {
            return new Image
            {
                ImageId = imageModel.ImageId,
                MimeType = imageModel.MimeType,
                ImageData = imageModel.ImageData,
                ImageDateOfUpload = imageModel.ImageDateOfUpload,
                Description = imageModel.Description,
                ImageOwnerId = imageModel.ImageOwnerId,
                Banned = imageModel.Banned,
            };
        }
    }
}