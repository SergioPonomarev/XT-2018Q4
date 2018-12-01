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
            char a = 'a';
            char A = 'A';
            char b = 'b';
            char B = 'B';

            string s1 = "Advace";
            string s2 = "advace";

            Console.WriteLine(s1.CompareTo(s2));
            Console.WriteLine(string.Compare(s1, s2, true));

            string[] str =
            {
                "Advace",
                "advace",
                "Bdvace",
                "bdvace",
                "adv",
                "bdv",
                "Adv"
            };

            Array.Sort(str);

            Console.WriteLine();
        }
    }
}
