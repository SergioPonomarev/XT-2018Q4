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
        private const int DefaultImageId = 1;
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
                return false;
            }

            if (userDateOfBirth >= DateTime.Now)
            {
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

                return user;
            }

            return this.usersDao.GetUserById(userId);
        }

        public User GetUserByUserName(string userName)
        {
            var cacheResult = this.cacheLogic.Get<IEnumerable<User>>(AllUsersCacheKey);

            if (cacheResult != null)
            {
                User user = cacheResult.FirstOrDefault(u => u.UserName == userName);

                return user;
            }
            
            return this.usersDao.GetUserByUserName(userName);
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

        public bool PromoteToAdmin(string userName)
        {
            User user = this.GetUserByUserName(userName);

            if (user == null)
            {
                return false;
            }

            this.cacheLogic.Delete(AllUsersCacheKey);
            return this.usersDao.PromoteToAdmin(userName);
        }

        public bool DemoteToUser(string userName)
        {
            User user = this.GetUserByUserName(userName);

            if (user == null)
            {
                return false;
            }

            this.cacheLogic.Delete(AllUsersCacheKey);
            return this.usersDao.DemoteToUser(userName);
        }

        public Image GetUserImageByUserName(string userName)
        {
            User user = this.GetUserByUserName(userName);
            Image image = null;
            image = this.usersDao.GetUserImageByImageId(user.UserImageId);
            if (image == null)
            {
                image = this.GetDefaultUserImage();
            }

            return image;
        }

        public Image GetDefaultUserImage()
        {
            return this.usersDao.GetUserImageByImageId(DefaultImageId);
        }

        public IEnumerable<User> GetUsersByRole(string role)
        {
            return this.usersDao.GetUsersByRole(role);
        }

        public IEnumerable<User> GetUsersExeptRole(string role)
        {
            return this.usersDao.GetUsersExeptRole(role);
        }
    }
}
