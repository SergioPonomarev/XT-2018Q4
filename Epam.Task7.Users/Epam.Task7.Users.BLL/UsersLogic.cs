using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Epam.Task7.Users.BLL.Interfaces;
using Epam.Task7.Users.DAL.Interfaces;
using Epam.Task7.Users.Entities;

namespace Epam.Task7.Users.BLL
{
    public class UsersLogic : IUsersLogic
    {
        private const string AllUsersCacheKey = "GetAllUsers";
        private const string DateFormat = "yyyy-MM-dd";

        private readonly IUsersDao usersDao;
        private readonly ICacheLogic cacheLogic;

        public UsersLogic(IUsersDao usersDao, ICacheLogic cacheLogic)
        {
            this.usersDao = usersDao;
            this.cacheLogic = cacheLogic;
        }

        public void Add(string userName, string userDateOfBirth)
        {
            if (string.IsNullOrEmpty(userName) ||
                string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentException("Wrong user name.", nameof(userName));
            }

            if (string.IsNullOrEmpty(userDateOfBirth) ||
                string.IsNullOrWhiteSpace(userDateOfBirth))
            {
                throw new ArgumentException("Wrong user date of birth.", nameof(userDateOfBirth));
            }

            DateTime dateOfBirth;

            try
            {
                dateOfBirth = DateTime.ParseExact(userDateOfBirth, DateFormat, CultureInfo.InvariantCulture);
            }
            catch
            {
                throw;
            }

            if (DateTime.Now < dateOfBirth)
            {
                throw new ArgumentException("Inputed date of birth is greater than current date.");
            }

            User user = new User
            {
                Name = userName,
                DateOfBirth = dateOfBirth,
            };

            try
            {
                this.cacheLogic.Delete(AllUsersCacheKey);
                this.usersDao.Add(user);
            }
            catch
            {
                throw;
            }
        }

        public bool Remove(int id)
        {
            this.cacheLogic.Delete(AllUsersCacheKey);
            return this.usersDao.Remove(id);
        }

        public bool RemoveAll()
        {
            this.cacheLogic.Delete(AllUsersCacheKey);
            return this.usersDao.RemoveAll();
        }

        public IEnumerable<User> GetAll()
        {
            var cacheResult = this.cacheLogic.Get<IEnumerable<User>>(AllUsersCacheKey);

            if (cacheResult == null)
            {
                var result = this.usersDao.GetAll().ToArray();
                this.cacheLogic.Add(AllUsersCacheKey, result);
                return result;
            }

            return cacheResult;
        }
    }
}
