using System;

namespace Epam.Task2.Triangle
{
    internal class Program
    {
        private const char StarChar = '*';

        private static void Main()
        {
            Console.WriteLine("Greatings! You are using The Triangle Printer Program!");
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
                        Triangle(number);
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

        private static void Triangle(int number)
        {
            for (int i = 0; i < number; i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    Console.Write(StarChar);
                }

                Console.WriteLine();
            }
        }
    }
}
