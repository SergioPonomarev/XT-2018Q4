using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Epam.FinalTask.PhotoAlbum.MVCWebUI.CustomAttributes;

namespace Epam.FinalTask.PhotoAlbum.MVCWebUI.Models
{
    public class EditUserModel
    {
        public string UserName { get; set; }

        [ValidImageFormat(ErrorMessage = "Only .jpg, .jpeg, .png images are allowed.")]
        [MaxFileSize(524288, ErrorMessage = "File size must not exceed 1 mb.")]
        public HttpPostedFileBase Avatar { get; set; }
    }
}