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
        private readonly IUsersDao usersDao;

        public UsersLogic(IUsersDao usersDao)
        {
            this.usersDao = usersDao;
        }

        public User GetUserByUserName(string userName)
        {
            return this.usersDao.GetUserByUserName(userName);
        }
    }
}
