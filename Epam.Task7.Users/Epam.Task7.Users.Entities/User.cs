using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task7.Users.Entities
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
                return AgeCalculating();
            }
        }

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
