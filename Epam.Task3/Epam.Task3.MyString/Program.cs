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

            main = main.Replace('l', 'm');

            Console.WriteLine(main);

            MyString ms = "hello";

            ms = ms.Replace('l', 'm');

            Console.WriteLine(ms);
        }
    }
}
