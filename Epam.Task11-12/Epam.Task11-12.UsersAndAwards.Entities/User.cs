using System;
using System.Collections.Generic;

namespace Epam.Task11_12.UsersAndAwards.Entities
{
    public class User
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public DateTime UserDateOfBirth { get; set; }

        public int UserAge => this.AgeCalculating();

        public IEnumerable<Award> UserAwards { get; set; }

        public int UserImageId { get; set; }

        private int AgeCalculating()
        {
            DateTime current = DateTime.Now;
            int a = (((this.UserDateOfBirth.Year * 100) + this.UserDateOfBirth.Month) * 100) + this.UserDateOfBirth.Day;
            int b = (((current.Year * 100) + current.Month) * 100) + current.Day;
            int age = (b - a) / 10000;
            return age;
        }
    }
}
