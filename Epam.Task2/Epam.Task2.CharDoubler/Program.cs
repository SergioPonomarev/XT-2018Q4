using System;
using System.Text;

namespace Epam.Task2.CharDoubler
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Greatings! You are using The Char Doubler Program!");
            Console.WriteLine();

            Console.WriteLine("Please, enter the main string:");
            string mainString = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine($"Please, enter the additional string which characters will double{Environment.NewLine}same characters in the main string:");
            string additionalString = Console.ReadLine();
            Console.WriteLine();

            string result = CharDoubler(mainString, additionalString);

            Console.WriteLine("The resulting string is:");
            Console.WriteLine(result);
        }

        private static string CharDoubler(string mainString, string additionalString)
        {
            StringBuilder sb = new StringBuilder(mainString);

            for (int i = 0; i < sb.Length; i++)
            {
                char tempMS = char.ToUpper(sb[i]);
                for (int j = 0; j < additionalString.Length; j++)
                {
                    char tempAS = char.ToUpper(additionalString[j]);
                    if (tempMS.Equals(tempAS))
                    {
                        sb.Insert(i, sb[i]);
                        i++;
                        break;
                    }
                }
            }

            string result = sb.ToString();
            return result;
        }
    }
}
