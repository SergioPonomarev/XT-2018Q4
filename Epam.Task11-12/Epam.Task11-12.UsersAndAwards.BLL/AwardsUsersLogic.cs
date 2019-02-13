using System;
using System.Linq;
using Epam.Task11_12.UsersAndAwards.BLL.Interfaces;
using Epam.Task11_12.UsersAndAwards.DAL.Interfaces;
using Epam.Task11_12.UsersAndAwards.Entities;

namespace Epam.Task11_12.UsersAndAwards.BLL
{
    public class AwardsUsersLogic : IAwardsUsersLogic
    {
        private const string AllUsersCacheKey = "GetAllUsers";

        private readonly IAwardsUsersDao awardsUsersDao;
        private readonly ICacheLogic cacheLogic;
        private readonly IUsersLogic usersLogic;
        private readonly IAwardsLogic awardsLogic;

        public AwardsUsersLogic(IAwardsUsersDao awardsUsersDao, ICacheLogic cacheLogic, IUsersLogic usersLogic, IAwardsLogic awardsLogic)
        {
            this.awardsUsersDao = awardsUsersDao;
            this.cacheLogic = cacheLogic;
            this.usersLogic = usersLogic;
            this.awardsLogic = awardsLogic;
        }

        public bool AwardUser(int userId, int awardId)
        {
            User user = this.usersLogic.GetUserById(userId);
            if (user == null)
            {
                return false;
            }

            Award award = this.awardsLogic.GetAwardById(awardId);
            if (award == null)
            {
                return false;
            }

            if (user.UserAwards.Contains(award))
            {
                return false;
            }

            this.cacheLogic.Delete(AllUsersCacheKey);

            AwardUser awardUser = new AwardUser
            {
                UserId = user.UserId,
                AwardId = award.AwardId,
            };

            return this.awardsUsersDao.AwardUser(awardUser);
        }

        public bool RemoveAwardFromUser(int userId, int awardId)
        {
            User user = this.usersLogic.GetUserById(userId);
            if (user == null)
            {
                return false;
            }

            Award award = this.awardsLogic.GetAwardById(awardId);
            if (award == null)
            {
                return false;
            }

            if (!user.UserAwards.Contains(award))
            {
                return false;
            }

            this.cacheLogic.Delete(AllUsersCacheKey);

            AwardUser awardUser = new AwardUser
            {
                UserId = user.UserId,
                AwardId = award.AwardId,
            };

            return this.awardsUsersDao.RemoveAwardFromUser(awardUser);
        }
    }
}
