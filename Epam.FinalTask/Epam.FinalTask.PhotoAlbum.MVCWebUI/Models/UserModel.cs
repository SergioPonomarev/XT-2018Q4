using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Epam.FinalTask.PhotoAlbum.Entities;

namespace Epam.FinalTask.PhotoAlbum.MVCWebUI.Models
{
    public class UserModel
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string UserRole { get; set; }

        public int UserAvatarId { get; set; }

        public IEnumerable<ImageModel> UserImages { get; set; }

        public bool Banned { get; set; }

        public static implicit operator UserModel(User user)
        {
            return new UserModel
            {
                UserId = user.UserId,
                UserName = user.UserName,
                UserRole = user.UserRole,
                UserAvatarId = user.UserAvatarId,
                Banned = user.Banned,
            };
        }

        public static explicit operator User(UserModel userModel)
        {
            return new User
            {
                UserId = userModel.UserId,
                UserName = userModel.UserName,
                UserRole = userModel.UserRole,
                UserAvatarId = userModel.UserAvatarId,
                Banned = userModel.Banned,
            };
        }
    }
}