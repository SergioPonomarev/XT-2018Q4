using System;

namespace Epam.Task1.Square
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Greatings! You are using " +
                              "The Square Printer Programm!");
            Console.WriteLine();

            while (true)
            {
                try
                {
                    Console.Write("Please, enter a size of square to print: ");
                    bool check = int.TryParse(Console.ReadLine(), out int size);
                    Console.WriteLine();

                    if (!check || (size % 2 == 0) || size < 0)
                    {
                        throw new ArgumentException("The entered value must be "
                                                    + "an odd natural number.");
                    }

                    Square(size);
                    return;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                }
            }
        }

        public static void Square(int size)
        {
            for (int i = 0; i < size; i++)
            {
                if (i == size / 2)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (j == size / 2)
                        {
                            Console.Write(" ");
                        }
                        else
                        {
                            Console.Write("*");
                        }
                    }
                    Console.WriteLine();
                }
                else
                {
                    for (int j = 0; j < size; j++)
                    {
                        Console.Write("*");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
