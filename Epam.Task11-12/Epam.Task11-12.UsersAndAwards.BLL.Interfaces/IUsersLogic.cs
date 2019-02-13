using System;
using System.Collections.Generic;
using Epam.Task11_12.UsersAndAwards.Entities;

namespace Epam.Task11_12.UsersAndAwards.BLL.Interfaces
{
    public interface IUsersLogic
    {
        IEnumerable<User> GetAll();

        bool Add(string userName, DateTime userDateOfBirth);

        bool Update(int userId, DateTime userDateOfBirth);

        bool Remove(int userId);

        User GetUserById(int userId);

        User GetUserByUserName(string userName);

        bool AddImageToUser(Image image, string userName);

        bool AddDefaultUserImage(Image image);

        bool PromoteToAdmin(string userName);

        bool DemoteToUser(string userName);

        Image GetUserImageByUserName(string userName);

        Image GetDefaultUserImage();

        IEnumerable<User> GetUsersByRole(string role);

        IEnumerable<User> GetUsersExeptRole(string role);
    }
}
