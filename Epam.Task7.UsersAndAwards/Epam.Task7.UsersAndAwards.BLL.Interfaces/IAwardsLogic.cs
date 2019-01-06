using System;
using System.Collections.Generic;
using Epam.Task7.UsersAndAwards.Entities;

namespace Epam.Task7.UsersAndAwards.BLL.Interfaces
{
    public interface IAwardsLogic
    {
        IEnumerable<Award> GetAll();

        void Add(string awardTitle);

        bool Remove(int id);

        bool RemoveAll();
    }
}
