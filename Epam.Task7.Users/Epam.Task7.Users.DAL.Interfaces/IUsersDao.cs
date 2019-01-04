using Epam.Task7.Users.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task7.Users.DAL.Interfaces
{
    public interface IUsersDao
    {
        IEnumerable<User> GetAll();

        void Add(User user);

        bool Remove(int id);

        bool RemoveAll();
    }
}
