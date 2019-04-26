using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

            User user;

            try
            {
                user = this.GetUserByUserName(userName);
            }
            catch (SqlException)
            {
                return false;
            }

            if (user == null)
            {
                User newUser = new User
                {
                    UserName = userName,
                    UserRole = defaultRole,
                    UserAvatarId = defaultAvatarId,
                    Banned = false,
                };

                return this.usersDao.Add(newUser);
            }
            else
            {
                return false;
            }
        }

        public bool BanUser(User user)
        {
            return this.usersDao.BanUser(user);
        }

        public bool DemoteToUser(User user)
        {
            return this.usersDao.DemoteToUser(user);
        }

        public User GetUserById(int userId)
        {
            try
            {
                return this.usersDao.GetUserById(userId);
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public User GetUserByUserName(string userName)
        {
            try
            {
                return this.usersDao.GetUserByUserName(userName);
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public bool PromoteToAdmin(User user)
        {
            return this.usersDao.PromoteToAdmin(user);
        }

        public bool Remove(User user)
        {
            return this.usersDao.Remove(user);
        }

        public bool UnbanUser(User user)
        {
            return this.usersDao.UnbanUser(user);
        }
    }
}
