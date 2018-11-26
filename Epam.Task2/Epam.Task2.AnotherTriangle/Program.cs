using System;

namespace Epam.Task2.AnotherTriangle
{
    internal class Program
    {
        private const char StarChar = '*';
        private const char SpaceChar = ' ';

        private static void Main()
        {
            Console.WriteLine("Greatings! You are using The Another Triangle Printer Program!");
            Console.WriteLine();

            while (true)
            {
                try
                {
                    Console.Write("Please, enter a number of strings to print a triangle: ");
                    bool check = int.TryParse(Console.ReadLine(), out int number);
                    Console.WriteLine();

                    if (ValueCheck(check, number))
                    {
                        AnotherTriangle(number);
                        return;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                }
            }
        }

        private static bool ValueCheck(bool check, int value)
        {
            if (!check || value < 1)
            {
                throw new ArgumentException("The entered value must be a natural number.");
            }

            return true;
        }

        private static void AnotherTriangle(int number)
        {
            int count = 1;
            for (int i = 0; i < number; i++)
            {
                for (int j = 0; j < number - i; j++)
                {
                    Console.Write(SpaceChar);
                }

                for (int k = 0; k < count; k++)
                {
                    Console.Write(StarChar);
                }

                Console.WriteLine();
                count += 2;
            }
        }
    }
}
