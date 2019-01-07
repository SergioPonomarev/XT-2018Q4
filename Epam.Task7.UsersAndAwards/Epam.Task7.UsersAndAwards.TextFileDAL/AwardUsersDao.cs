using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using Epam.Task7.UsersAndAwards.DAL.Interfaces;
using Epam.Task7.UsersAndAwards.Entities;

namespace Epam.Task7.UsersAndAwards.TextFileDAL
{
    public class AwardUsersDao : IAwardUsersDao
    {
        private const char Separator = '|';
        private readonly string awardUsersFilePath;

        public AwardUsersDao()
        {
            this.awardUsersFilePath = ConfigurationManager.AppSettings["TextFileDALAwardUsersKey"];
        }

        public bool Add(AwardUser awardUser)
        {
            try
            {
                File.AppendAllLines(this.awardUsersFilePath, new[] { AwardUsersSerialize(awardUser) });
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<AwardUser> GetAll()
        {
            try
            {
                return File.ReadAllLines(this.awardUsersFilePath)
                    .Select(line =>
                    {
                        var parts = line.Split(new[] { Separator }, 2);
                        return new AwardUser
                        {
                            UserId = int.Parse(parts[0]),
                            AwardId = int.Parse(parts[1]),
                        };
                    });
            }
            catch
            {
                return Enumerable.Empty<AwardUser>();
            }
        }

        private static string AwardUsersSerialize(AwardUser awardUser)
        {
            return $"{awardUser.UserId.ToString()}{Separator}{awardUser.AwardId.ToString()}";
        }
    }
}
