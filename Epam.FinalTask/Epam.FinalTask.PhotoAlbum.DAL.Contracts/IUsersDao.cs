using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.FinalTask.PhotoAlbum.Entities;

namespace Epam.FinalTask.PhotoAlbum.DAL.Contracts
{
    public interface IUsersDao
    {
        User GetUserByUserName(string userName);

        User GetUserById(int userId);

        bool Add(User user);

        bool Remove(User user);

        bool BanUser(User user);

        bool UnbanUser(User user);

        bool PromoteToAdmin(User user);

        bool DemoteToUser(User user);
    }
}
