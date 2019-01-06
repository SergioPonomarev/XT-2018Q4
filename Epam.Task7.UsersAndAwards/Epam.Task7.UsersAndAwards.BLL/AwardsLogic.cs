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
    public class AwardsLogic : IAwardsLogic
    {
        private const string AllAwardsCacheKey = "GetAllAwards";

        private readonly IAwardsDao awardsDao;
        private readonly ICacheLogic cacheLogic;

        public AwardsLogic(IAwardsDao awardsDao, ICacheLogic cacheLogic)
        {
            this.awardsDao = awardsDao;
            this.cacheLogic = cacheLogic;
        }

        public void Add(string awardTitle)
        {
            if (string.IsNullOrEmpty(awardTitle) ||
                string.IsNullOrWhiteSpace(awardTitle))
            {
                throw new ArgumentException("Wrong award title.", nameof(awardTitle));
            }

            Award award = new Award
            {
                Title = awardTitle,
            };

            try
            {
                this.cacheLogic.Delete(AllAwardsCacheKey);
                this.awardsDao.Add(award);
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<Award> GetAll()
        {
            var cacheResult = this.cacheLogic.Get<IEnumerable<Award>>(AllAwardsCacheKey);

            if (cacheResult == null)
            {
                var result = this.awardsDao.GetAll().ToArray();
                this.cacheLogic.Add(AllAwardsCacheKey, result);
                return result;
            }

            return cacheResult;
        }

        public bool Remove(int id)
        {
            this.cacheLogic.Delete(AllAwardsCacheKey);
            return this.awardsDao.Remove(id);
        }

        public bool RemoveAll()
        {
            this.cacheLogic.Delete(AllAwardsCacheKey);
            return this.awardsDao.RemoveAll();
        }
    }
}
