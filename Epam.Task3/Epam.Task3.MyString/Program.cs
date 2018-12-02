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
            string str = "hello";

            char l = 'l';

            Console.WriteLine(str.LastIndexOf('a'));

            Console.WriteLine();

            MyString ms = "hello";

            Console.WriteLine(ms.LastIndexOf('a'));
        }
    }
}
