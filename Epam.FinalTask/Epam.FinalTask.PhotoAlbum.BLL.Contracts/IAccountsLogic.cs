using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.FinalTask.PhotoAlbum.BLL.Contracts
{
    public interface IAccountsLogic
    {
        bool CanLogin(string login, string password);

        string[] GetRoles(string userName);

        bool UserRegistration(string userName, string password);
    }
}
