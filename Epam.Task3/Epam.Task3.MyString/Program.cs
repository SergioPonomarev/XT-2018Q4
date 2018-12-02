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

            bool b = main.StartsWith("llh");

            Console.WriteLine(b);

            MyString ms = "llelloll";

            b = ms.StartsWith("llh");

            Console.WriteLine(b);
        }
    }
}
