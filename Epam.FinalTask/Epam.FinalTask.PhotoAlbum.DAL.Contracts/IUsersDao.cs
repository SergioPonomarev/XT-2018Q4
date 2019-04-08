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
    }
}
