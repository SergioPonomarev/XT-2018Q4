using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.FinalTask.PhotoAlbum.DAL.Contracts
{
    public interface IAccountsDao
    {
        string GetPassByUserId(int userId);

        bool SetPassToUser(int userId, string hashedPass);
    }
}
