using System;

namespace Epam.Task1.Sequence
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Greatings! You are using The Number Sequencer Programm!");
            Console.WriteLine();

            while (true)
            {
                try
                {
                    Console.Write("Please, enter a number from 1 to some reasonable value: ");
                    bool check = int.TryParse(Console.ReadLine(), out int number);
                    Console.WriteLine();

                    if (ValueCheck(check, number))
                    {
                        Sequence(number);
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
                throw new ArgumentException("The entered value must be a natural number from 1 or more.");
            }

            return true;
        }

        private static void Sequence(int number)
        {
            for (int i = 1; i <= number; i++)
            {
                if (i == number)
                {
                    Console.Write(i);
                }
                else
                {
                    Console.Write(i);
                    Console.Write(", ");
                }
            }

            Console.WriteLine();
        }
    }
}
