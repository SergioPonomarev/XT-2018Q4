using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.FinalTask.PhotoAlbum.DAL.Contracts;
using Epam.FinalTask.PhotoAlbum.Entities;

namespace Epam.FinalTask.PhotoAlbum.FakeDAL
{
    public class FakeUsersDao : IUsersDao
    {
        public User GetUserByUserName(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
