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

        bool Add(string userName);

        IEnumerable<User> GetAll();

        bool RemoveUser(string userName);

        void BanUser(User user);

        void UnbanUser(User user);
    }
}
