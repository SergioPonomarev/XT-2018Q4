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
    public class AccountsLogic : IAccountsLogic
    {
        private readonly IAccountsDao accountsDao;
        private readonly IUsersLogic usersLogic;

        public AccountsLogic(IAccountsDao accountsDao, IUsersLogic usersLogic)
        {
            this.accountsDao = accountsDao;
            this.usersLogic = usersLogic;
        }

        public string[] GetRoles(string userName)
        {
            User user = this.usersLogic.GetUserByUserName(userName);

            switch (user.UserRole.ToLower())
            {
                case "user":
                    return new[] { "Users" };

                case "admin":
                    return new[] { "Users", "Admins" };

                default:
                    return new string[0];
            }
        }
    }
}
