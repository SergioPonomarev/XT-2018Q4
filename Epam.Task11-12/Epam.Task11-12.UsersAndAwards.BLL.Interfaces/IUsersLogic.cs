using System;
using System.Collections.Generic;
using Epam.Task11_12.UsersAndAwards.Entities;

namespace Epam.Task11_12.UsersAndAwards.BLL.Interfaces
{
    public interface IUsersLogic
    {
        IEnumerable<User> GetAll();

        bool Add(string userName, DateTime userDateOfBirth);

        bool Update(int userId, string userName = default(string), DateTime userDateOfBirth = default(DateTime));

        bool Remove(int userId);

        User GetUserById(int userId);

        bool AddImageToUser(Image image, User user);
    }
}
