using System;
using System.Collections.Generic;
using System.Linq;
using Epam.Task11_12.UsersAndAwards.BLL.Interfaces;
using Epam.Task11_12.UsersAndAwards.DAL.Interfaces;
using Epam.Task11_12.UsersAndAwards.Entities;

namespace Epam.Task11_12.UsersAndAwards.BLL
{
    public class UsersLogic : IUsersLogic
    {
        private const string AllUsersCacheKey = "GetAllUsers";

        private readonly IUsersDao usersDao;
        private readonly ICacheLogic cacheLogic;

        public UsersLogic(IUsersDao usersDao, ICacheLogic cacheLogic)
        {
            this.usersDao = usersDao;
            this.cacheLogic = cacheLogic;
        }

        public bool Add(string userName, DateTime userDateOfBirth)
        {
            if (string.IsNullOrEmpty(userName) ||
                string.IsNullOrWhiteSpace(userName))
            {
                //throw new ArgumentException("Wrong user name.");
                return false;
            }

            if (userDateOfBirth >= DateTime.Now)
            {
                //throw new ArgumentException("Wrong user date of birth.");
                return false;
            }

            if (!this.GetAll().Any(u => u.UserName.ToLower() == userName.ToLower()))
            {
                User user = new User
                {
                    UserName = userName,
                    UserDateOfBirth = userDateOfBirth,
                };

                this.cacheLogic.Delete(AllUsersCacheKey);
                return this.usersDao.Add(user);
            }
            else
            {
                return false;
            }

        }

        public IEnumerable<User> GetAll()
        {
            var cacheResult = this.cacheLogic.Get<IEnumerable<User>>(AllUsersCacheKey);

            if (cacheResult == null)
            {
                var result = this.usersDao.GetAll();
                this.cacheLogic.Add(AllUsersCacheKey, result);
                return result;
            }

            return cacheResult;
        }

        public User GetUserById(int userId)
        {
            var cacheResult = this.cacheLogic.Get<IEnumerable<User>>(AllUsersCacheKey);

            if (cacheResult != null)
            {
                User user = cacheResult.FirstOrDefault(u => u.UserId == userId);

                //if (user == null)
                //{
                //    //throw new ArgumentException("User is not found.");
                //    return null;
                //}

                return user;
            }

            return usersDao.GetUserById(userId);
        }

        public User GetUserByUserName(string userName)
        {
            var cacheResult = this.cacheLogic.Get<IEnumerable<User>>(AllUsersCacheKey);

            if (cacheResult != null)
            {
                User user = cacheResult.FirstOrDefault(u => u.UserName == userName);

                return user;
            }

            return usersDao.GetUserByUserName(userName);
        }

        public bool Remove(int userId)
        {
            this.cacheLogic.Delete(AllUsersCacheKey);
            return this.usersDao.Remove(userId);
        }

        public bool Update(int userId, DateTime userDateOfBirth)
        {
            User user = this.GetUserById(userId);

            if (user != null)
            {
                if (userDateOfBirth != default(DateTime))
                {
                    if (userDateOfBirth >= DateTime.Now)
                    {
                        return false;
                    }

                    user.UserDateOfBirth = userDateOfBirth;
                }

                this.cacheLogic.Delete(AllUsersCacheKey);
                return this.usersDao.Update(user);
            }
            else
            {
                return false;
            }
        }

        public bool AddImageToUser(Image image, string userName)
        {
            User user = this.GetUserByUserName(userName);

            if (user != null)
            {
                this.cacheLogic.Delete(AllUsersCacheKey);
                return this.usersDao.AddImageToUser(image, user);
            }
            else
            {
                return false;
            }
        }

        public bool AddDefaultUserImage(Image image)
        {
            return this.usersDao.AddDefaultUserImage(image);
        }
    }
}
