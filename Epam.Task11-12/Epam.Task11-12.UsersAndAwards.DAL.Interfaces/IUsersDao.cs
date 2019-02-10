using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
