using System;

namespace Epam.Task11_12.UsersAndAwards.BLL.Interfaces
{
    public interface IAwardsUsersLogic
    {
        bool AwardUser(int userId, int awardId);
    }
}
