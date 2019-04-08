using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.FinalTask.PhotoAlbum.DAL.Contracts;

namespace Epam.FinalTask.PhotoAlbum.FakeDAL
{
    public class FakeAccountsDao : IAccountsDao
    {
        public string GetPassByLogin(string login)
        {
            throw new NotImplementedException();
        }
    }
}
