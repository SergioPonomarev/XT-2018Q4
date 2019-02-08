using System;
using System.Collections.Generic;
using Epam.Task11_12.UsersAndAwards.Entities;

namespace Epam.Task11_12.UsersAndAwards.DAL.Interfaces
{
    public interface IAwardsDao
    {
        IEnumerable<Award> GetAll();

        bool Add(Award award);

        bool Remove(int awardId);

        Award GetAwardById(int awardId);

        bool Update(Award award);
    }
}
