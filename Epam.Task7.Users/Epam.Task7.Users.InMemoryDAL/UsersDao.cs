using System;
using System.Collections.Generic;
using Epam.Task7.Users.DAL.Interfaces;
using Epam.Task7.Users.Entities;

namespace Epam.Task7.Users.InMemoryDAL
{
    public class UsersDao : IUsersDao
    {
        private readonly IDictionary<int, User> users;
        private int maxId;

        public UsersDao()
        {
            this.users = new Dictionary<int, User>();
        }

        public void Add(User user)
        {
            user.Id = ++this.maxId;
            this.users.Add(user.Id, user);
        }

        public IEnumerable<User> GetAll()
        {
            return this.users.Values;
        }

        public bool Remove(int id)
        {
            return this.users.Remove(id);
        }

        public bool RemoveAll()
        {
            this.users.Clear();
            return true;
        }
    }
}
