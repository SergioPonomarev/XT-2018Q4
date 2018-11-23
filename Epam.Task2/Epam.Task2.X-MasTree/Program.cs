using System;

namespace Epam.Task2.XMasTree
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Greatings! You are using "
                             + "The X-Mas Tree Printer Program!");
            Console.WriteLine();

            while (true)
            {
                try
                {
                    Console.Write("Please, enter a number of tree levels "
                                      + "to print a X-Mas Tree: ");
                    bool check = int.TryParse(Console.ReadLine(), out int number);
                    Console.WriteLine();

                    if (ValueCheck(check, number))
                    {
                        XMasTree(number);
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

        private static bool ValueCheck(bool check, int number)
        {
            if (!check || number < 1)
            {
                throw new ArgumentException("The entered value must "
                                            + "be a natural number.");
            }

            return true;
        }

        private static void XMasTree(int number)
        {
            for (int i = 0; i < number; i++)
            {
                int counter = 1;

                for (int j = 0; j <= i; j++)
                {
                    for (int k = 0; k < number - j; k++)
                    {
                        Console.Write(" ");
                    }

                    for (int l = 0; l < counter; l++)
                    {
                        Console.Write("*");
                    }

                    Console.WriteLine();
                    counter += 2;
                }
            }
        }
    }
}
