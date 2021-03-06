﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.FinalTask.PhotoAlbum.Entities;

namespace Epam.FinalTask.PhotoAlbum.DAL.Contracts
{
    public interface IAvatarsDao
    {
        Avatar GetUserAvatar(int avatarId);

        Avatar GetDefaultAvatar();

        bool SetDefaultAvatar(Avatar avatar);

        bool SetAvatarToUser(Avatar newAvatar, User user);

        int Add(Avatar avatar);

        bool Remove(int avatarId);
    }
}
