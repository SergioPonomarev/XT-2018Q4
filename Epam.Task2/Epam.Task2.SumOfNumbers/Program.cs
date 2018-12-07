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
            int sumThree = ((3 + 999) * 333) / 2;
            int sumFive = ((5 + 995) * 199) / 2;
            int sumFifteen = ((15 + 990) * 66) / 2;
            return sumThree + sumFive - sumFifteen;
        }
    }
}
