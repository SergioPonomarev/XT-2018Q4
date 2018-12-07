using System;

namespace Epam.Task1.Square
{
    internal class Program
    {
        private const char StarChar = '*';
        private const char SpaceChar = ' ';

        private static void Main()
        {
            Console.WriteLine("Greetings! You are using The Square Printer Programm!");
            Console.WriteLine();

            while (true)
            {
                try
                {
                    Console.Write("Please, enter a size of square to print: ");
                    bool check = int.TryParse(Console.ReadLine(), out int size);
                    Console.WriteLine();

                    if (ValueCheck(check, size))
                    {
                        Square(size);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                }
            }
        }

        private static bool ValueCheck(bool check, int value)
        {
            if (!check || (value % 2 == 0) || value < 0)
            {
                throw new ArgumentException("The entered value must be an odd natural number.");
            }

            return true;
        }

        private static void Square(int size)
        {
            for (int i = 0; i < size; i++)
            {
                if (i == size / 2)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (j == size / 2)
                        {
                            Console.Write(SpaceChar);
                        }
                        else
                        {
                            Console.Write(StarChar);
                        }
                    }

                    Console.WriteLine();
                }
                else
                {
                    for (int j = 0; j < size; j++)
                    {
                        Console.Write(StarChar);
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
