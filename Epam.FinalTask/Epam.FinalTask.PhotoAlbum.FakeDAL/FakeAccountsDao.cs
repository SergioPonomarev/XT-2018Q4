using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.FinalTask.PhotoAlbum.DAL.Contracts;

namespace Epam.FinalTask.PhotoAlbum.FakeDAL
{
    public class FakeAccountsDao : IAccountsDao
    {
        private Dictionary<string, string> passwords;

        public FakeAccountsDao()
        {
            this.passwords = new Dictionary<string, string>
            {
                { "admin", "240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9" }
            };
        }

        public string GetPassByLogin(string login)
        {
            if (this.passwords.ContainsKey(login))
            {
                return this.passwords[login];
            }
            else
            {
                return string.Empty;
            }
        }

        public bool SetPassToUser(string userName, string hashedPass)
        {
            try
            {
                this.passwords.Add(userName, hashedPass);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
