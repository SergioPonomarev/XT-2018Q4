using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task7.UsersAndAwards.Entities;

namespace Epam.Task7.UsersAndAwards.DAL.Interfaces
{
    public interface IAwardUsersDao
    {
        bool Add(AwardUser awardUser);

        IEnumerable<AwardUser> GetAll();
    }
}
