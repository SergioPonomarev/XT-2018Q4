using System;

namespace Epam.Task1.SquarePrinter
{
    class Program
    {
        static void Main()
        {
            SquarePrinter(7);
            Console.WriteLine();
            SquarePrinter(5);
            Console.WriteLine();
            SquarePrinter(11);
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
