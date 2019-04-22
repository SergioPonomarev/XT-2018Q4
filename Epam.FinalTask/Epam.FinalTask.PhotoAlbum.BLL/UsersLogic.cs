using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.FinalTask.PhotoAlbum.BLL.Contracts;
using Epam.FinalTask.PhotoAlbum.DAL.Contracts;
using Epam.FinalTask.PhotoAlbum.Entities;

namespace Epam.FinalTask.PhotoAlbum.BLL
{
    public class UsersLogic : IUsersLogic
    {
        private static readonly string defaultRole = "User";
        private static readonly int defaultAvatarId = 1;

        private readonly IUsersDao usersDao;

        public UsersLogic(IUsersDao usersDao)
        {
            this.usersDao = usersDao;
        }

        public bool Add(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                return false;
            }

            if (this.GetUserByUserName(userName) == null)
            {
                User user = new User
                {
                    UserName = userName,
                    UserRole = defaultRole,
                    UserAvatarId = defaultAvatarId,
                    Banned = false,
                };

                return this.usersDao.Add(user);
            }
            else
            {
                return false;
            }
        }

        public void BanUser(User user)
        {
            this.usersDao.BanUser(user);
        }

        public void DemoteToUser(User user)
        {
            this.usersDao.DemoteToUser(user);
        }

        public User GetUserById(int userId)
        {
            return this.usersDao.GetUserById(userId);
        }

        public User GetUserByUserName(string userName)
        {
            return this.usersDao.GetUserByUserName(userName);
        }

        public void PromoteToAdmin(User user)
        {
            this.usersDao.PromoteToAdmin(user);
        }

        public bool Remove(User user)
        {
            return this.usersDao.Remove(user);
        }

        public void UnbanUser(User user)
        {
            this.usersDao.UnbanUser(user);
        }
    }
}
