using System;
using System.Collections.Generic;
using Epam.Task7.UsersAndAwards.Entities;

namespace Epam.Task7.UsersAndAwards.DAL.Interfaces
{
    public interface IUsersDao
    {
        IEnumerable<User> GetAll();

        void Add(User user);

        bool Remove(int id);

        bool RemoveAll();
    }
}
