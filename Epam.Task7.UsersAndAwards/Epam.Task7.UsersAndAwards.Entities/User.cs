using System;
using System.Collections.Generic;

namespace Epam.Task7.UsersAndAwards.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int Age
        {
            get
            {
                return this.AgeCalculating();
            }
        }

        public IEnumerable<Award> UserAwards { get; set; }

        private int AgeCalculating()
        {
            DateTime current = DateTime.Now;
            int a = (((this.DateOfBirth.Year * 100) + this.DateOfBirth.Month) * 100) + this.DateOfBirth.Day;
            int b = (((current.Year * 100) + current.Month) * 100) + current.Day;
            int age = (b - a) / 10000;
            return age;
        }
    }
}
