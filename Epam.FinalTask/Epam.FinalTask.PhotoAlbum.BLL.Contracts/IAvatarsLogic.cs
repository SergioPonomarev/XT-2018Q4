﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.FinalTask.PhotoAlbum.Entities;

namespace Epam.FinalTask.PhotoAlbum.BLL.Contracts
{
    public interface IAvatarsLogic
    {
        Avatar GetUserAvatar(int avatarId);

        Avatar GetDefaultAvatar();

        bool SetDefaultAvatar(Avatar avatar);

        bool SetAvatarToUser(Avatar newAvatar, User user);
    }
}
