using System;
using System.Text.RegularExpressions;

namespace Epam.Task8.NumberValidator
{
    internal class Program
    {
        private const string ScientificNumberPattern = @"(^[+-]?[0-9]+(?:\.[0-9]+)*(?:E|e)[+-]?[0-9]+$)";
        private const string NormalNumberPattern = @"(^[+-]?[0-9]+(?:\.[0-9]+)?$)";

        private static void Main()
        {
            Console.Write("Enter a number to define what kind of notation is: ");
            string input = Console.ReadLine();

            if (Regex.IsMatch(input, ScientificNumberPattern))
            {
                Console.WriteLine($"{input} is scientific notation.");
            }
            else if (Regex.IsMatch(input, NormalNumberPattern))
            {
                Console.WriteLine($"{input} is normal natation.");
            }
            else
            {
                Console.WriteLine($"{input} is not a number.");
            }
        }
    }
}
