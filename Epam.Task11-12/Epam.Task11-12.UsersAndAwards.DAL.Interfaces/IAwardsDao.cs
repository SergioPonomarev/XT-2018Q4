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

        Award GetAwardByAwardTitle(string awardTitle);

        bool Update(Award award);

        bool AddImageToAward(Image image, Award award);

        int AddAwardImage(Image image);

        bool AddDefaultAwardImage(Image image);

        Image GetAwardImageByAwardId(int awardImageId);
    }
}
