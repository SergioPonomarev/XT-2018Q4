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

        Award GetAwardByAwardTitle(string awardTitle);

        bool Update(int awardId, string awardTitle);

        bool AddImageToAward(Image image, string awardTitle);

        bool AddDefaultAwardImage(Image image);
    }
}
