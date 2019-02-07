using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task11_12.UsersAndAwards.DAL.Interfaces;
using Epam.Task11_12.UsersAndAwards.Entities;

namespace Epam.Task11_12.UsersAndAwards.SqlDAL
{
    public class SqlAwardsUsersDao : IAwardsUsersDao
    {
        private readonly string conStr;

        public SqlAwardsUsersDao(string connectionString)
        {
            this.conStr = connectionString;
        }

        public bool AwardUser(AwardUser awardUser)
        {
            throw new NotImplementedException();
        }
    }
}
