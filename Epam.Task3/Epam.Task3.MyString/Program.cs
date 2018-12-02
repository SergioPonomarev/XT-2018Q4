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
            string str = "ellohello";

            MyString l = "ell";

            MyString ms = "ellohello";

            Console.WriteLine(ms.LastIndexOf(l));

            Console.WriteLine(ms.LastIndexOf(l, 4, 5));
        }
    }
}
