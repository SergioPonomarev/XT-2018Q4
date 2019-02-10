using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task11_12.UsersAndAwards.BLL.Interfaces
{
    public interface IAccountsLogic
    {
        bool CanLogin(string login, string password);

        bool UserRegistration(string userName, DateTime userDateOfBirth, string userPassword);
    }
}
