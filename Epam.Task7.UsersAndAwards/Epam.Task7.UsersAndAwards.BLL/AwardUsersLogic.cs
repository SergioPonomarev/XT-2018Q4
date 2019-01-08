using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task7.UsersAndAwards.BLL.Interfaces;
using Epam.Task7.UsersAndAwards.DAL.Interfaces;
using Epam.Task7.UsersAndAwards.Entities;

namespace Epam.Task7.UsersAndAwards.BLL
{
    public class AwardUsersLogic : IAwardUsersLogic
    {
        private const string AllUsersCacheKey = "GetAllUsers";
        private const string AllAwardsCacheKey = "GetAllAwards";

        private readonly IUsersDao usersDao;
        private readonly IAwardsDao awardsDao;
        private readonly IAwardUsersDao awardUsersDao;
        private readonly ICacheLogic cacheLogic;

        public AwardUsersLogic(IUsersDao usersDao, IAwardsDao awardsDao, IAwardUsersDao awardUsersDao, ICacheLogic cacheLogic)
        {
            this.usersDao = usersDao;
            this.awardsDao = awardsDao;
            this.awardUsersDao = awardUsersDao;
            this.cacheLogic = cacheLogic;
        }

        public bool AddAwardUser(int userId, int awardId)
        {
            var users = this.usersDao.GetAll();
            var user = users.FirstOrDefault(u => u.Id == userId);
            if (user == null)
            {
                return false;
            }

            var awards = this.awardsDao.GetAll();
            var award = awards.FirstOrDefault(a => a.Id == awardId);
            if (award == null)
            {
                return false;
            }

            AwardUser awardUser = new AwardUser
            {
                UserId = userId,
                AwardId = awardId,
            };

            var awardsUser = this.awardUsersDao.GetAll();

            if (awardsUser.Contains(awardUser))
            {
                throw new ArgumentException($"User with id {userId} allready has award with id {awardId}");
            }

            this.cacheLogic.Delete(AllUsersCacheKey);
            this.cacheLogic.Delete(AllAwardsCacheKey);

            return this.awardUsersDao.Add(awardUser);
        }

        public IEnumerable<Award> GetAwardsByUserId(int userId)
        {
            var awards = this.awardsDao.GetAll();

            var awardsUser = this.awardUsersDao.GetAll();

            if (!awardsUser.Any())
            {
                return Enumerable.Empty<Award>();
            }

            var awardsId = awardsUser.Where(au => au.UserId == userId).Select(awId => awId.AwardId);

            return awards.Where(aw => awardsId.Contains(aw.Id));
        }
    }
}
