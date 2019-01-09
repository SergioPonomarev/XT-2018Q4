using System;
using System.Text.RegularExpressions;

namespace Epam.Task8.HtmlReplacer
{
    internal class Program
    {
        private const string HtmlPattern = @"(?:<[^>]+>)";
        private const string Replacer = "_";

        private static string defaultText = "<b>This</b> is <i>text</i> with <font color=\"red\">HTML</font> tags.";
        private static string input;
        private static Regex htmlRegex = new Regex(HtmlPattern);

        private static void Main()
        {
            Console.WriteLine("Press Enter to use default text with HTML tags or press any another key to input your text:");
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                input = defaultText;
                Console.Write("Default text: ");
                Console.WriteLine(input);
            }
            else
            {
                Console.WriteLine("Enter your text:");
                input = Console.ReadLine();
                Console.WriteLine("Text that you entered:");
                Console.WriteLine(input);
            }

            Console.WriteLine($"Text after replacing HTML tags with '{Replacer}' symbol:");

            string result = htmlRegex.Replace(input, Replacer);

            Console.WriteLine(result);
        }
    }
}
