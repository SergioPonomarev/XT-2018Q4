using System;
using System.Text.RegularExpressions;

namespace Epam.Task8.EmailFinder
{
    internal class Program
    {
        private const string EmailPattern = @"(?:\b[A-Za-z0-9]+[_\-.]*[A-Za-z0-9]+@(?:[A-Za-z0-9\-\.])*\.[A-Za-z]{2,6})";
        private static string input;
        private static Regex emailRegex = new Regex(EmailPattern);

        private static void Main()
        {
            Console.Write("Enter text to define if it contains e-mail addresses: ");
            input = Console.ReadLine();

            Console.WriteLine("Text that you entered:");
            Console.WriteLine(input);
            Console.WriteLine();

            if (emailRegex.IsMatch(input))
            {
                Console.WriteLine("The following e-mail addresses were found in the text:");
                foreach (var address in emailRegex.Matches(input))
                {
                    Console.WriteLine(address);
                }
            }
            else
            {
                Console.WriteLine("There is no appropriate e-mail addresses in the text.");
            }
        }
    }
}
