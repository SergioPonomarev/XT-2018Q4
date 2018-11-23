using System;

namespace Epam.Task2.AnotherTriangle
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Greatings! You are using "
                             + "The Another Triangle Printer Program!");
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

                    AnotherTriangle(number);
                    return;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                }
            }
        }

        private static void AnotherTriangle(int number)
        {
            int count = 1;
            for (int i = 0; i < number; i++)
            {
                for (int j = 0; j < number - i; j++)
                {
                    Console.Write(" ");
                }
                for (int k = 0; k < count; k++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
                count += 2;
            }
        }
    }
}
