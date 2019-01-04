using Epam.Task7.Users.BLL.Interfaces;
using Epam.Task7.Users.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task7.Users.BLL
{
    public class UsersLogic : IUsersLogic
    {
        private readonly IUsersDao usersDao;

        public UsersLogic()
        {
            this.usersDao = new InMemoryDAL.UsersDao();
        }

        public void Add(string userName, string userDateOfBirth)
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

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
