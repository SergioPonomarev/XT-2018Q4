using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using Epam.Task7.UsersAndAwards.DAL.Interfaces;
using Epam.Task7.UsersAndAwards.Entities;

namespace Epam.Task7.UsersAndAwards.TextFileDAL
{
    public class AwardsDao : IAwardsDao
    {
        private const char Separator = '|';
        private readonly string maxIdFilePath;
        private readonly string awardsFilePath;
        private int maxId;

        public AwardsDao()
        {
            this.maxIdFilePath = ConfigurationManager.AppSettings["TextFileDALAwardsIdKey"];
            this.awardsFilePath = ConfigurationManager.AppSettings["TextFileDALAwardsKey"];

            try
            {
                this.maxId = int.Parse(File.ReadAllText(this.maxIdFilePath));
            }
            catch
            {
                this.maxId = 0;
            }
        }

        public void Add(Award award)
        {
            award.Id = ++this.maxId;

            File.WriteAllText(this.maxIdFilePath, this.maxId.ToString());
            File.AppendAllLines(this.awardsFilePath, new[] { AwardSerialize(award) });
        }

        public IEnumerable<Award> GetAll()
        {
            try
            {
                return File.ReadAllLines(this.awardsFilePath)
                    .Select(line =>
                    {
                        var parts = line.Split(new[] { Separator }, 2);
                        return new Award
                        {
                            Id = int.Parse(parts[0]),
                            Title = parts[1],
                        };
                    });
            }
            catch
            {
                return Enumerable.Empty<Award>();
            }
        }

        public bool Remove(int id)
        {
            var awards = this.GetAll().ToList();
            var award = awards.FirstOrDefault(a => a.Id == id);
            if (award == null)
            {
                return false;
            }

            awards.Remove(award);

            File.WriteAllLines(this.awardsFilePath, awards.Select(AwardSerialize));

            return true;
        }

        public bool RemoveAll()
        {
            try
            {
                File.WriteAllText(this.awardsFilePath, string.Empty);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static string AwardSerialize(Award award)
        {
            return $"{award.Id}{Separator}{award.Title}";
        }
    }
}
