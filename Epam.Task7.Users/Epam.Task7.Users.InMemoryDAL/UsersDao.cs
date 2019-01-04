using Epam.Task7.Users.DAL.Interfaces;
using Epam.Task7.Users.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveAll()
        {
            throw new NotImplementedException();
        }
    }
}
