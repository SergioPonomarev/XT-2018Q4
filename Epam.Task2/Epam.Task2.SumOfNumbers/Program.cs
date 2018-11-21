using System;

namespace Epam.Task2.SumOfNumbers
{
    class Program
    {
        static void Main()
        {
            Console.Write("The sum of all multiples of 3 or 5 below 1000 is: ");
            SumOfNumbers();
        }

        public static void SumOfNumbers()
        {
            int sum = 0;

            for (int i = 1; i < 1000; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    sum += i;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
