using System;

namespace Epam.Task1.Simple
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Greatings! You are using The Prime Number Check Programm!");
            Console.WriteLine();

            while (true)
            {
                try
                {
                    Console.Write("Please, enter a value to check if it is a prime number: ");
                    bool check = int.TryParse(Console.ReadLine(), out int number);
                    Console.WriteLine();

                    if (!check)
                    {
                        throw new ArgumentException("The entered value must be a number.");
                    }
                    
                    Simple(number);
                    return;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                }
            }
        }

        private static void Simple(int number)
        {
            if (number < 2)
            {
                Console.WriteLine($"{number} is not a prime number.");
                return;
            }

            bool isSimple = true;

            for (int i = 2; i <= number / i; i++)
            {
                if (number % i == 0)
                {
                    isSimple = false;
                    break;
                }
            }

            if (isSimple)
            {
                Console.WriteLine($"{number} is a prime number.");
            }
            else
            {
                Console.WriteLine($"{number} is not a prime number.");
            }
        }
    }
}
