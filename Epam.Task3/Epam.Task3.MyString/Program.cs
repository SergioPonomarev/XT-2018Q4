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

            string[] str =
            {
                "Advace",
                "advace",
                "Bdvace",
                "bdvace",
                "adv",
                "bdv",
                "Adv",
                "azva"
            };

            Array.Sort(str);

            Console.WriteLine(CompareTo(new char[] { 'A', 'd', 'v', 'a', 'c', 'e'}, new char[] { 'a', 'd', 'v', 'a', 'c', 'e'}));
            Console.WriteLine(CompareTo(new char[] { 'a', 'd', 'v', 'a', 'c', 'e' }, new char[] { 'A', 'd', 'v'}));
            Console.WriteLine(CompareTo(new char[] { 'a', 'd', 'v', 'a', 'c', 'e' }, new char[] { 'b', 'd', 'v' }));
            Console.WriteLine(CompareTo(new char[] { 'A', 'd', 'v', 'a', 'c', 'e' }, new char[] { 'a', 'z', 'v', 'a' }));
        }

        public static int CompareTo(char[] ch1, char[] ch2)
        {
            int min = ch1.Length < ch2.Length ? ch1.Length : ch2.Length;

            for (int i = 0; i < min; i++)
            {
                if (char.ToUpper(ch1[i]) < char.ToUpper(ch2[i]))
                {
                    return -1;
                }

                if (char.ToUpper(ch1[i]) > char.ToUpper(ch2[i]))
                {
                    return 1;
                }
            }

            if (ch1.Length < ch2.Length)
            {
                return -1;
            }
            
            if (ch1.Length > ch2.Length)
            {
                return 1;
            }

            if (char.IsLower(ch1[0]))
            {
                return -1;
            }

            if (char.IsLower(ch2[0]))
            {
                return 1;
            }

            return 0;
        }
    }
}
