using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

        public bool CanLogin(string login, string password)
        {
            User user = this.usersLogic.GetUserByUserName(login);

            if (user == null)
            {
                return false;
            }

            string hashedPass = this.GetHashedPass(login, password);

            string hashedPassFromDB = this.accountsDao.GetPassByUserId(user.UserId);

            return hashedPass == hashedPassFromDB;
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

                case "superadmin":
                    return new[] { "Users", "Admins", "SuperAdmins" };

                default:
                    return new string[0];
            }
        }

        public bool UserRegistration(string userName, string password)
        {
            if (this.usersLogic.Add(userName))
            {
                if (string.IsNullOrWhiteSpace(password))
                {
                    return false;
                }

                string hashedPass = this.GetHashedPass(userName, password);

                User user = this.usersLogic.GetUserByUserName(userName);

                return this.accountsDao.SetPassToUser(user.UserId, hashedPass);
            }
            else
            {
                return false;
            }
        }

        private string GetHashedPass(string inputLogin, string inputPass)
        {
            var sha256 = new SHA256CryptoServiceProvider();
            byte[] inputBytes = Encoding.UTF8.GetBytes(inputLogin + inputPass);
            byte[] hashedBytes = sha256.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes).Replace("-", string.Empty).ToLower();
        }
    }
}
