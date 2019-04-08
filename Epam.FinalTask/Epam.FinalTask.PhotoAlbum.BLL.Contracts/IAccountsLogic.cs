using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.FinalTask.PhotoAlbum.BLL.Contracts
{
    public interface IAccountsLogic
    {
        string[] GetRoles(string userName);
    }
}
