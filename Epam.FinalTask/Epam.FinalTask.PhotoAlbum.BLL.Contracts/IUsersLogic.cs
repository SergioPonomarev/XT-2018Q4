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

        void BanUser(User user);

        void UnbanUser(User user);

        void PromoteToAdmin(User user);

        void DemoteToUser(User user);
    }
}
