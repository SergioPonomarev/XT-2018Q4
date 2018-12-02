using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.MyString
{
    internal class Program
    {
        private static void Main()
        {
            MyString main = "Great day!";

            MyString add = "What a ";

            main = main.Insert(0, add);

            Console.WriteLine(main);
        }
    }
}
