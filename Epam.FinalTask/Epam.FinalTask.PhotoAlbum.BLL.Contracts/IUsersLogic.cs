using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.FinalTask.PhotoAlbum.Entities;

namespace Epam.FinalTask.PhotoAlbum.BLL.Contracts
{
    public interface IUsersLogic
    {
        User GetUserByUserName(string userName);

        User GetUserById(int userId);

        bool Add(string userName);

        bool Remove(User user);

        bool BanUser(User user);

        bool UnbanUser(User user);

        bool PromoteToAdmin(User user);

        bool DemoteToUser(User user);
    }
}
