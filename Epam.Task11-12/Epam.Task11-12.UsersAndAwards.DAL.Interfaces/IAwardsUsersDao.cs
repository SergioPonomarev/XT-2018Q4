using System;
using Epam.Task11_12.UsersAndAwards.Entities;

namespace Epam.Task11_12.UsersAndAwards.DAL.Interfaces
{
    public interface IAwardsUsersDao
    {
        bool AwardUser(AwardUser awardUser);
    }
}
