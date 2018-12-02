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
            MyString ms1 = "advice";

            object obj = 1;

            Console.WriteLine(ms1.CompareTo(obj));
        }
    }
}
