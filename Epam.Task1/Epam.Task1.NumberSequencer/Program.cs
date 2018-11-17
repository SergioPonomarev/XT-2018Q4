using System;

namespace Epam.Task1.NumberSequencer
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(NumberSequencer(7));
        }

        public static string NumberSequencer(int n)
        {
            string result = string.Empty;
            for (int i = 1; i <= n; i++)
            {
                if (i == n) result += i.ToString();
                else result += i.ToString() + ", ";
            }
            return result;
        }
    }
}
