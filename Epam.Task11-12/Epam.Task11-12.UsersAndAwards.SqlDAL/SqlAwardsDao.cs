using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task11_12.UsersAndAwards.DAL.Interfaces;
using Epam.Task11_12.UsersAndAwards.Entities;

namespace Epam.Task11_12.UsersAndAwards.SqlDAL
{
    public class SqlAwardsDao : IAwardsDao
    {
        private readonly string conStr;

        public SqlAwardsDao(string connectionString)
        {
            this.conStr = connectionString;
        }

        public bool Add(Award award)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Award> GetAll()
        {
            throw new NotImplementedException();
        }

        public Award GetAwardById(int awardId)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int awardId)
        {
            throw new NotImplementedException();
        }

        public bool Update(int awardId, string awardTitle)
        {
            throw new NotImplementedException();
        }
    }
}
