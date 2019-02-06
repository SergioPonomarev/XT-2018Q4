using System;
using System.Collections.Generic;
using Epam.Task11_12.UsersAndAwards.Entities;

namespace Epam.Task11_12.UsersAndAwards.BLL.Interfaces
{
    public interface IAwardsLogic
    {
        IEnumerable<Award> GetAll();

        bool Add(string awardTitle);

        bool Remove(int awardId);

        Award GetAwardById(int awardId);

        bool Update(int awardId, string awardTitle);
    }
}
