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
            string str1 = "hello";

            string str2 = null;

            string str = string.Concat(str1, str2);
        }
    }
}
