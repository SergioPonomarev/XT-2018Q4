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
            string main = "hello";

            main = main.Remove(2, 1);

            Console.WriteLine(main);

            MyString ms = "hello";

            ms = ms.Remove(2, 1);

            Console.WriteLine(ms);
        }
    }
}
