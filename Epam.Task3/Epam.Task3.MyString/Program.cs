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

            string b = main.Substring(0, 5);

            Console.WriteLine(b);

            MyString ms = "llhelloll";

            b = ms.SubMyString(0, 5);

            Console.WriteLine(b);
        }
    }
}
