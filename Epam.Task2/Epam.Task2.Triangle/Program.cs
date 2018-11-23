using System;

namespace Epam.Task2.Triangle
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Greatings! You are using "
                             + "The Triangle Printer Program!");
            Console.WriteLine();

            while (true)
            {
                try
                {
                    Console.Write("Please, enter a number of strings "
                                      + "to print a triangle: ");
                    bool check = int.TryParse(Console.ReadLine(), out int number);
                    Console.WriteLine();

                    if (!check || number < 1)
                    {
                        throw new ArgumentException("The entered value must "
                                                    + "be a natural number.");
                    }

                    Triangle(number);
                    return;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                }
            }
        }

        private static void Triangle(int number)
        {
            for (int i = 0; i < number; i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}
