using System;
using System.Collections.Generic;
using Epam.Task7.UsersAndAwards.Entities;

namespace Epam.Task7.UsersAndAwards.DAL.Interfaces
{
    public interface IAwardsDao
    {
        IEnumerable<Award> GetAll();

        void Add(Award award);

        bool Remove(int id);

        bool RemoveAll();
    }
}
