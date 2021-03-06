﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.FinalTask.PhotoAlbum.BLL.Contracts;
using Epam.FinalTask.PhotoAlbum.DAL.Contracts;
using Epam.FinalTask.PhotoAlbum.Entities;
using Epam.FinalTask.PhotoAlbum.FakeDAL;

namespace Epam.FinalTask.PhotoAlbum.BLL
{
    public class AvatarsLogic : IAvatarsLogic
    {
        private readonly IAvatarsDao avatarsDao;

        public AvatarsLogic(IAvatarsDao avatarsDao)
        {
            this.avatarsDao = avatarsDao;
        }

        public Avatar GetDefaultAvatar()
        {
            try
            {
                return this.avatarsDao.GetDefaultAvatar();
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public Avatar GetUserAvatar(int avatarId)
        {
            try
            {
                return this.avatarsDao.GetUserAvatar(avatarId);
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public bool SetAvatarToUser(Avatar newAvatar, User user)
        {
            return this.avatarsDao.SetAvatarToUser(newAvatar, user);
        }

        public bool SetDefaultAvatar(Avatar avatar)
        {
            return this.avatarsDao.SetDefaultAvatar(avatar);
        }
    }
}
