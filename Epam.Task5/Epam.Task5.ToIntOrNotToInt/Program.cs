using System;

namespace Epam.Task5.ToIntOrNotToInt
{
    internal class Program
    {
        private static string value;
        private static string flag = "a";
        private static bool result;

        private static void Main()
        {
            Console.WriteLine("Greetings! This is IsPositiveNaturalNumber Method Demonstrating Program.");
            Console.WriteLine();

            while (flag != "q")
            {
                switch (flag)
                {
                    case "a":
                        Console.Write("Please, enter a string to find out if it is positive natural number: ");
                        value = Console.ReadLine();
                        result = value.IsPositiveNaturalNumber();

                        Console.Write($"String '{value}' is ");
                        if (result)
                        {
                            Console.WriteLine($"positive natural number ({result.ToString()})");
                        }
                        else
                        {
                            Console.WriteLine($"NOT positive natural number ({result.ToString()})");
                        }

                        Console.WriteLine();
                        Console.Write("Enter 'q' to quit the program or 'a' to check more strings: ");
                        flag = Console.ReadLine().ToLower();
                        Console.WriteLine();
                        break;

                    default:
                        Console.Write("Invalid value! Enter 'q' to quit the program or 'a' to check more strings: ");
                        flag = Console.ReadLine().ToLower();
                        Console.WriteLine();
                        break;
                }
            }
        }
    }
}
