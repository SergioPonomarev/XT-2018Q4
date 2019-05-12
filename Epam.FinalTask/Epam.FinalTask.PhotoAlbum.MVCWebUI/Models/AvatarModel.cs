using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Epam.FinalTask.PhotoAlbum.Entities;

namespace Epam.FinalTask.PhotoAlbum.MVCWebUI.Models
{
    public class AvatarModel
    {
        public int AvatarId { get; set; }

        public string MimeType { get; set; }

        public string AvatarData { get; set; }

        public static implicit operator AvatarModel(Avatar avatar)
        {
            return new AvatarModel
            {
                AvatarId = avatar.AvatarId,
                MimeType = avatar.MimeType,
                AvatarData = avatar.AvatarData,
            };
        }

        public static explicit operator Avatar(AvatarModel avatarModel)
        {
            return new Avatar
            {
                AvatarId = avatarModel.AvatarId,
                MimeType = avatarModel.MimeType,
                AvatarData = avatarModel.AvatarData,
            };
        }
    }
}