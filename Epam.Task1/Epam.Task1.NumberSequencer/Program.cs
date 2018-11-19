using System;

namespace Epam.Task1.Sequence
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Greatings! You are using " +
                              "The Number Sequencer Programm!");
            Console.WriteLine(); // Could use an '\n' escape sequence instead

            while (true)
            {
                try
                {
                    Console.Write("Please, enter a number from 1 to "
                                  + "some reasonable value: ");
                    bool check = int.TryParse(Console.ReadLine(), out int number);
                    Console.WriteLine();
                    if (!check)
                    {
                        throw new ArgumentException("The entered value must be "
                                                    + "a natural number from 1 "
                                                    + "or more.");
                    }
                    
                    Sequence(number);
                    return;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                }
            }
        }

        public static void Sequence(int number)
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
