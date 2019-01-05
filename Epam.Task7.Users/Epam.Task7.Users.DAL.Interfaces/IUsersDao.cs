using System;
using System.Collections.Generic;
using Epam.Task7.Users.Entities;

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
