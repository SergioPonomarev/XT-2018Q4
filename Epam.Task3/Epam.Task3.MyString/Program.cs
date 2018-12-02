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

            string b = main.ToUpper();

            Console.WriteLine(b);

            MyString ms = "hello";

            b = ms.ToUpper();

            Console.WriteLine(b);
        }
    }
}
