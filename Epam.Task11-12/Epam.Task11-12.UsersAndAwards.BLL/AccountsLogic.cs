using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
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

            string hashedPass = this.GetHashedPass(password);

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

                //if (string.IsNullOrEmpty(userPassword) ||
                //    string.IsNullOrWhiteSpace(userPassword))
                //{
                //    return false;
                //}

                string hashedPass = this.GetHashedPass(userPassword);

                this.cacheLogic.Delete(AllUsersCacheKey);
                return this.accountsDao.SetPassToUser(userName, hashedPass);
            }
            else
            {
                return false;
            }
        }

        private string GetHashedPass(string input)
        {
            var sha256 = new SHA256CryptoServiceProvider();
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashedBytes = sha256.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }
    }
}
