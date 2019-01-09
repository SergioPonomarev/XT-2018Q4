using System;
using System.Text.RegularExpressions;

namespace Epam.Task8.DateExistance
{
    internal class Program
    {
        private const string DatePattern = @"((?:0[1-9]|[12][0-9]|3[01])-(?:0[13578]|1[02])-(?:[0-9]{4}))|((?:0[1-9]|[12][0-9]|30)-(?:0[469]|11)-(?:[0-9]{4}))|((?:0[1-9]|[12][0-9])-02-(?:[0-9]{4}))";

        private static Regex regex = new Regex(DatePattern);

        private static string input;

        private static void Main()
        {
            while (true)
            {
                Console.WriteLine("Enter some text to define if there is any date:");
                input = Console.ReadLine();

                if (regex.IsMatch(input))
                {
                    ShowMatches();
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("There are no dates in the text.");
                }

                Console.WriteLine("Press Escape key to quit the program or any another key to continue: ");

                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    return;
                }

                Console.WriteLine();
            }
        }

        private static void ShowMatches()
        {
            Console.WriteLine("The text that has been entered contains next dates:");

            foreach (var date in regex.Matches(input))
            {
                Console.WriteLine(date);
            }
        }
    }
}
