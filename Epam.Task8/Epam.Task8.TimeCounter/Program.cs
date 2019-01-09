using System;
using System.Text.RegularExpressions;

namespace Epam.Task8.TimeCounter
{
    internal class Program
    {
        private const string TimePattern = @"\b(0?[0-9]|1[0-9]|2[0-3]):[0-5][0-9]";

        private static void Main()
        {
            Console.Write("Enter some text to define if there is any time record: ");

            string input = Console.ReadLine();

            if (Regex.IsMatch(input, TimePattern))
            {
                Console.WriteLine($"There is {Regex.Matches(input, TimePattern).Count} time records in the text.");
            }
            else
            {
                Console.WriteLine("There is no time records in the text.");
            }
        }
    }
}
