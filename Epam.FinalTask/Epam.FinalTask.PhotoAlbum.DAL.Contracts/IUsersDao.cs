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

        bool Add(User user);

        IEnumerable<User> GetAll();

        bool Remove(User user);

        void BanUser(User user);

        void UnbanUser(User user);

        void PromoteToAdmin(User user);

        void DemoteToUser(User user);
    }
}
