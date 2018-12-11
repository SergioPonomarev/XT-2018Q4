using System;

namespace Epam.Task5.CustomSort
{
    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            return $"{this.Name} - {this.Age}";
        }
    }
}
