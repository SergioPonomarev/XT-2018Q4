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
            char[] main = { 'b', 'r', 'o', 'w', 'n', ' ', 'f', 'o', 'g', ' ', 'f', 'o', 'x', ' ', 'j', 'u', 'f', 'o', 'k' };

            char[] coin = { 'f', 'o', 'k' };

            bool check = Contains(main, coin);
        }

        public static bool Contains(char[] main, char[] coin)
        {
            if (coin == null)
            {
                throw new ArgumentNullException("Value is null.");
            }

            bool check = false; ;

            for (int i = 0; i <= main.Length - coin.Length; i++)
            {
                if (main[i] == coin[0])
                {
                    int index = i;

                    for (int j = 0; j < coin.Length; j++)
                    {
                        if (main[index] != coin[j])
                        {
                            break;
                        }

                        index++;
                    }

                    if (main[index - 1] == coin[coin.Length - 1])
                    {
                        check = true;
                        break;
                    }
                }
            }

            return check;
        }
    }
}
