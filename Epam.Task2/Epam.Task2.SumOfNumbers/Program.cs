using System;

namespace Epam.Task2.SumOfNumbers
{
    internal class Program
    {
        private static void Main()
        {
            int sumOfNumbers = SumOfNumbers();

            Console.WriteLine($"The sum of all multiples of 3 or 5 below 1000 is: {sumOfNumbers.ToString()}");
        }

        private static int SumOfNumbers()
        {
            int sum = 0;

            for (int i = 1; i < 1000; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    sum += i;
                }
            }

            return sum;
        }
    }
}
