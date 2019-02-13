using System;
using System.Collections.Generic;
using Epam.Task11_12.UsersAndAwards.Entities;

namespace Epam.Task11_12.UsersAndAwards.DAL.Interfaces
{
    public interface IUsersDao
    {
        IEnumerable<User> GetAll();

        bool Add(User user);

        bool Update(User user);

        bool Remove(int userId);

        User GetUserById(int userId);

        User GetUserByUserName(string userName);

        IEnumerable<Award> GetAwardsByUserId(int userId);

        bool AddImageToUser(Image image, User user);

        int AddUserImage(Image image);

        bool AddDefaultUserImage(Image image);

        bool PromoteToAdmin(string userName);

        bool DemoteToUser(string userName);

        Image GetUserImageByImageId(int imageId);

        IEnumerable<User> GetUsersByRole(string role);

        IEnumerable<User> GetUsersExeptRole(string role);
    }
}
