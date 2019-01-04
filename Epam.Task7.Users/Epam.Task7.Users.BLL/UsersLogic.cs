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
        private readonly IUsersDao usersDao;

        private const string DateFormat = "yyyy-MM-dd";

        public UsersLogic()
        {
            this.usersDao = new InMemoryDAL.UsersDao();
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
                usersDao.Add(user);
            }
            catch
            {
                throw;
            }
        }

        public bool Remove(int id)
        {
            return usersDao.Remove(id);
        }

        public bool RemoveAll()
        {
            return usersDao.RemoveAll();
        }

        public IEnumerable<User> GetAll()
        {
            return usersDao.GetAll().ToArray();
        }
    }
}
