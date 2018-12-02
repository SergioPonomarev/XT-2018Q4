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
            char[] chars = {'p', 'a', 'b', 'c', 'd' };

            string str1 = "baptistp";

            string str2 = "borov";

            string str3 = "drotic";

            string str4 = "fopov";

            string str5 = "gret";

            Console.WriteLine(str5.LastIndexOfAny(chars));

            Console.WriteLine(str1.LastIndexOfAny(chars, 3, 4));

            Console.WriteLine(str2.LastIndexOfAny(chars));

            Console.WriteLine(str3.LastIndexOfAny(chars));

            Console.WriteLine(str4.LastIndexOfAny(chars));

            Console.WriteLine();

            MyString ms1 = "baptistp";

            MyString ms2 = "borov";

            MyString ms3 = "drotic";

            MyString ms4 = "fopov";

            MyString ms5 = "gret";

            Console.WriteLine(ms5.LastIndexOfAny(chars));

            Console.WriteLine(ms1.LastIndexOfAny(chars, 3, 4));

            Console.WriteLine(ms2.LastIndexOfAny(chars));

            Console.WriteLine(ms3.LastIndexOfAny(chars));

            Console.WriteLine(ms4.LastIndexOfAny(chars));
        }
    }
}
