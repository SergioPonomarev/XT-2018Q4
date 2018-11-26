using System;
using System.Text;

namespace Epam.Task2.AverageStringLength
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Greatings! You are using The Average String Length Calculator Program!");
            Console.WriteLine();

            Console.WriteLine("Please, introduce the string:");
            string inputString = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("The string entered:");
            Console.WriteLine(inputString);
            Console.WriteLine();

            string convertedString = StringConverter(inputString);

            string[] words = convertedString.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            double averageWordsLength = GetAverageLength(words);
            Console.WriteLine($"The average word length in the entered string is: {averageWordsLength:F2}");
        }

        private static double GetAverageLength(string[] arr)
        {
            int charCount = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                charCount += arr[i].Length;
            }

            return (double)charCount / arr.Length;
        }

        private static string StringConverter(string str)
        {
            StringBuilder sb = new StringBuilder(str);

            for (int i = 0; i < sb.Length; i++)
            {
                if (char.IsDigit(sb[i]) || char.IsNumber(sb[i]) || char.IsPunctuation(sb[i]))
                {
                    sb.Remove(i, 1);
                    i--;
                }
            }

            string tempStr = sb.ToString();
            return tempStr;
        }
    }
}
