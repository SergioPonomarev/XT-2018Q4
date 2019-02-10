using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task11_12.UsersAndAwards.DAL.Interfaces
{
    public interface IAccountsDao
    {
        string GetPassByLogin(string login);

        bool SetPassToUser(string userName, string hashedPass);
    }
}
