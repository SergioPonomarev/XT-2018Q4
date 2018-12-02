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
            string main = "llhelloll";

            main = main.Replace("ll", "m");

            Console.WriteLine(main);

            MyString ms = "llhelloll";

            ms = ms.Replace("ll", "m");

            Console.WriteLine(ms);
        }
    }
}
