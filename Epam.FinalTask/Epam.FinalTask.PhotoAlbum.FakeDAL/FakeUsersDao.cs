using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.FinalTask.PhotoAlbum.DAL.Contracts;
using Epam.FinalTask.PhotoAlbum.Entities;

namespace Epam.FinalTask.PhotoAlbum.FakeDAL
{
    public class FakeUsersDao : IUsersDao
    {
        private static int id = 1;
        private readonly IImagesDao imagesDao;

        private List<User> users;

        public FakeUsersDao(IImagesDao imagesDao)
        {
            this.imagesDao = imagesDao;

            this.users = new List<User>
            {
                new User()
                {
                    UserId = id,
                    UserName = "admin",
                    UserRole = "SuperAdmin",
                    UserAvatarId = 1,
                }
            };

            id++;
        }

        public User GetUserByUserName(string userName)
        {
            User user = this.users.FirstOrDefault(u => u.UserName == userName);

            if (user != null)
            {
                user.UserImages = this.imagesDao.GetUserImages(user.UserId);
            }

            return user;
        }

        public bool Add(User user)
        {
            try
            {
                user.UserId = id++;
                this.users.Add(user);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Remove(User user)
        {
            return this.users.Remove(user);
        }

        public bool BanUser(User user)
        {
            this.users.Remove(user);

            user.Banned = true;

            this.users.Add(user);

            return true;
        }

        public bool UnbanUser(User user)
        {
            this.users.Remove(user);

            user.Banned = false;

            this.users.Add(user);

            return true;
        }

        public bool PromoteToAdmin(User user)
        {
            this.users.Remove(user);

            user.UserRole = "Admin";

            this.users.Add(user);

            return true;
        }

        public bool DemoteToUser(User user)
        {
            this.users.Remove(user);

            user.UserRole = "User";

            this.users.Add(user);

            return true;
        }

        public User GetUserById(int userId)
        {
            User user = this.users.FirstOrDefault(u => u.UserId == userId);

            if (user != null)
            {
                user.UserImages = this.imagesDao.GetUserImages(user.UserId);
            }

            return user;
        }
    }
}
