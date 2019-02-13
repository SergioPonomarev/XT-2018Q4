using System;

namespace Epam.Task11_12.UsersAndAwards.BLL.Interfaces
{
    public interface IAccountsLogic
    {
        bool CanLogin(string login, string password);

        bool UserRegistration(string userName, DateTime userDateOfBirth, string userPassword);

        string[] GetRoles(string userName);
    }
}
