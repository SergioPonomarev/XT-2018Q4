using Epam.Task7.Users.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task7.Users.BLL.Interfaces
{
    public interface IUsersLogic
    {
        IEnumerable<User> GetAll();

        void Create(string userName, string userDateOfBirth);

        bool Delete(int id);

        bool DeleteAll();
    }
}
