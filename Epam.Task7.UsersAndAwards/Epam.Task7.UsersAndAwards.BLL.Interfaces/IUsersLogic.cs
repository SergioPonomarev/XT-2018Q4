using System;
using System.Collections.Generic;
using Epam.Task7.UsersAndAwards.Entities;

namespace Epam.Task7.UsersAndAwards.BLL.Interfaces
{
    public interface IUsersLogic
    {
        IEnumerable<User> GetAll();

        void Add(string userName, string userDateOfBirth);

        bool Remove(int id);

        bool RemoveAll();
    }
}
