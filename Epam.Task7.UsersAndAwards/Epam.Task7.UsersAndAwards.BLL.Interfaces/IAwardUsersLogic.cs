using System;
using System.Collections.Generic;
using Epam.Task7.UsersAndAwards.Entities;

namespace Epam.Task7.UsersAndAwards.BLL.Interfaces
{
    public interface IAwardUsersLogic
    {
        bool AddAwardUser(int userId, int awardId);

        IEnumerable<Award> GetAwardsByUserId(int userId);
    }
}
