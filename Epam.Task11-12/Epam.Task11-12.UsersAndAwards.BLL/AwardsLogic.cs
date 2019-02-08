using System;
using System.Collections.Generic;
using System.Linq;
using Epam.Task11_12.UsersAndAwards.BLL.Interfaces;
using Epam.Task11_12.UsersAndAwards.DAL.Interfaces;
using Epam.Task11_12.UsersAndAwards.Entities;

namespace Epam.Task11_12.UsersAndAwards.BLL
{
    public class AwardsLogic : IAwardsLogic
    {
        private const string AllAwardsCacheKey = "GetAllAwards";
        private const string AllUsersCacheKey = "GetAllUsers";

        private readonly IAwardsDao awardsDao;
        private readonly ICacheLogic cacheLogic;

        public AwardsLogic(IAwardsDao awardsDao, ICacheLogic cacheLogic)
        {
            this.awardsDao = awardsDao;
            this.cacheLogic = cacheLogic;
        }

        public bool Add(string awardTitle)
        {
            if (string.IsNullOrEmpty(awardTitle) ||
                string.IsNullOrWhiteSpace(awardTitle))
            {
                //throw new ArgumentException("Wrong award title.");
                return false;
            }

            if (!this.GetAll().Any(a => a.AwardTitle.ToLower() == awardTitle.ToLower()))
            {
                Award award = new Award
                {
                    AwardTitle = awardTitle,
                };

                this.cacheLogic.Delete(AllAwardsCacheKey);
                return this.awardsDao.Add(award);
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<Award> GetAll()
        {
            var cacheResult = this.cacheLogic.Get<IEnumerable<Award>>(AllAwardsCacheKey);

            if (cacheResult == null)
            {
                var result = this.awardsDao.GetAll();
                this.cacheLogic.Add(AllAwardsCacheKey, result);
                return result;
            }

            return cacheResult;
        }

        public Award GetAwardById(int awardId)
        {
            var cacheResult = this.cacheLogic.Get<IEnumerable<Award>>(AllAwardsCacheKey);

            if (cacheResult != null)
            {
                Award award = cacheResult.FirstOrDefault(a => a.AwardId == awardId);

                if (award == null)
                {
                    return null;
                }

                return award;
            }

            return this.awardsDao.GetAwardById(awardId);
        }

        public bool Remove(int awardId)
        {
            this.cacheLogic.Delete(AllAwardsCacheKey);
            this.cacheLogic.Delete(AllUsersCacheKey);
            return this.awardsDao.Remove(awardId);
        }

        public bool Update(int awardId, string awardTitle)
        {
            Award award = this.GetAwardById(awardId);

            if (award != null)
            {
                if (string.IsNullOrEmpty(awardTitle) ||
                    string.IsNullOrWhiteSpace(awardTitle))
                {
                    return false;
                }

                award.AwardTitle = awardTitle;

                this.cacheLogic.Delete(AllAwardsCacheKey);
                this.cacheLogic.Delete(AllUsersCacheKey);

                return this.awardsDao.Update(award);
            }
            else
            {
                return false;
            }
        }

        public bool AddImageToAward(Image image, Award award)
        {
            this.cacheLogic.Delete(AllUsersCacheKey);
            this.cacheLogic.Delete(AllAwardsCacheKey);
            return this.awardsDao.AddImageToAward(image, award);
        }
    }
}
