using Epam.Task7.Users.BLL.Interfaces;
using Epam.Task7.Users.DAL.Interfaces;
using Epam.Task7.Users.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task7.Users.BLL
{
    public class UsersLogic : IUsersLogic
    {
        private const string ALL_USERS_CACHE_KEY = "GetAllUsers";

        private readonly IUsersDao usersDao;
        private readonly ICacheLogic cacheLogic;

        private const string DateFormat = "yyyy-MM-dd";

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
                cacheLogic.Delete(ALL_USERS_CACHE_KEY);
                usersDao.Add(user);
            }
            catch
            {
                throw;
            }
        }

        public bool Remove(int id)
        {
            cacheLogic.Delete(ALL_USERS_CACHE_KEY);
            return usersDao.Remove(id);
        }

        public bool RemoveAll()
        {
            cacheLogic.Delete(ALL_USERS_CACHE_KEY);
            return usersDao.RemoveAll();
        }

        public IEnumerable<User> GetAll()
        {
            var cacheResult = cacheLogic.Get<IEnumerable<User>>(ALL_USERS_CACHE_KEY);

            if (cacheResult == null)
            {
                var result = usersDao.GetAll().ToArray();
                cacheLogic.Add(ALL_USERS_CACHE_KEY, result);
                Console.WriteLine("From dao");
                return result;
            }

            Console.WriteLine("From cache");
            return cacheResult;
        }
    }
}
