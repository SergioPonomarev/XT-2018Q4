using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.FinalTask.PhotoAlbum.DAL.Contracts;
using Epam.FinalTask.PhotoAlbum.Entities;

namespace Epam.FinalTask.PhotoAlbum.FakeDAL
{
    public class FakeAccountsDao : IAccountsDao
    {
        private Dictionary<int, string> passwords;

        public FakeAccountsDao()
        {
            this.passwords = new Dictionary<int, string>
            {
                { 1, "240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9" }
            };
        }

        public string GetPassByUserId(int userId)
        {
            if (this.passwords.ContainsKey(userId))
            {
                return this.passwords[userId];
            }
            else
            {
                return string.Empty;
            }
        }

        public bool SetPassToUser(int userId, string hashedPass)
        {
            try
            {
                this.passwords.Add(userId, hashedPass);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
