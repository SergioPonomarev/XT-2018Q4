using System;
using System.Security.Cryptography;
using System.Text;
using Epam.Task11_12.UsersAndAwards.BLL.Interfaces;
using Epam.Task11_12.UsersAndAwards.DAL.Interfaces;
using Epam.Task11_12.UsersAndAwards.Entities;

namespace Epam.Task11_12.UsersAndAwards.BLL
{
    public class AccountsLogic : IAccountsLogic
    {
        private const string AllUsersCacheKey = "GetAllUsers";

        private readonly IAccountsDao accountsDao;
        private readonly IUsersLogic usersLogic;
        private readonly ICacheLogic cacheLogic;

        public AccountsLogic(IAccountsDao accountsDao, IUsersLogic usersLogic, ICacheLogic cacheLogic)
        {
            this.usersLogic = usersLogic;
            this.accountsDao = accountsDao;
            this.cacheLogic = cacheLogic;
        }

        public bool CanLogin(string login, string password)
        {
            User user = this.usersLogic.GetUserByUserName(login);

            if (user == null)
            {
                return false;
            }

            string hashedPass = this.GetHashedPass(login, password);

            string hashedPassFromDB = this.accountsDao.GetPassByLogin(login);

            return hashedPass == hashedPassFromDB;
        }

        public bool UserRegistration(string userName, DateTime userDateOfBirth, string userPassword)
        {
            if (this.usersLogic.Add(userName, userDateOfBirth))
            {
                User user = this.usersLogic.GetUserByUserName(userName);

                if (user == null)
                {
                    return false;
                }

                if (string.IsNullOrEmpty(userPassword) ||
                    string.IsNullOrWhiteSpace(userPassword))
                {
                    return false;
                }

                string hashedPass = this.GetHashedPass(userName, userPassword);

                this.cacheLogic.Delete(AllUsersCacheKey);
                return this.accountsDao.SetPassToUser(userName, hashedPass);
            }
            else
            {
                return false;
            }
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

        private string GetHashedPass(string inputLogin, string inputPass)
        {
            var sha256 = new SHA256CryptoServiceProvider();
            byte[] inputBytes = Encoding.UTF8.GetBytes(inputLogin + inputPass);
            byte[] hashedBytes = sha256.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes).Replace("-", string.Empty).ToLower();
        }
    }
}
