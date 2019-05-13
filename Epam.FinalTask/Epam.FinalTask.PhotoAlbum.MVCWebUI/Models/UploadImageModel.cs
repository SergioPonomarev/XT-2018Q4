using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Epam.FinalTask.PhotoAlbum.MVCWebUI.CustomAttributes;

namespace Epam.FinalTask.PhotoAlbum.MVCWebUI.Models
{
    public class UploadImageModel
    {
        [ValidImageFormat(ErrorMessage = "Only .jpg, .jpeg, .png images are allowed.")]
        [MaxFileSize(1048576, ErrorMessage = "File size must not exceed 1 mb.")]
        public HttpPostedFileBase Image { get; set; }

        [StringLength(140, ErrorMessage = "Description must be less than or equal to 140 characters.")]
        public string Description { get; set; }
    }
}