using System;

namespace Epam.Task1.SquarePrinter
{
    class Program
    {
        static void Main()
        {
            for (int i = 5; i < 11; i+=2)
            {
                SquarePrinter(i);
                Console.WriteLine();
            }
        }

        public static void SquarePrinter(int n)
        {
            char ch = '*';
            char space = ' ';
            string halfString = new string(ch, n / 2);
            string fullString = new string(ch, n);
            for (int i = 0; i < n; i++)
            {
                if (i == n / 2)
                {
                    Console.WriteLine(halfString + space + halfString);
                }
                else Console.WriteLine(fullString);
            }
        }
    }
}
