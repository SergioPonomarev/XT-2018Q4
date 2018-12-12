using System;
using System.Collections.Generic;

namespace Epam.Task5.CustomSortDemo
{
    internal class Program
    {
        private static string value;
        private static string flag = "a";
        private static List<string> list = new List<string>();

        private static void Main()
        {
            Console.WriteLine("Greetings! This is Custom Sort Demonstrating Program.");
            Console.WriteLine();

            while (flag != "q")
            {
                switch (flag)
                {
                    case "a":
                        Console.Write("Please, enter a string to add in array: ");
                        value = Console.ReadLine();
                        list.Add(value);
                        Console.WriteLine($"String '{value}' added.");
                        Console.WriteLine();
                        Console.Write("Enter 'q' to finish and sort strings or 'a' to add more strings: ");
                        flag = Console.ReadLine().ToLower();
                        break;

                    default:
                        Console.Write("Invalid value! Enter 'q' to finish and sort or 'a' to add more strings: ");
                        flag = Console.ReadLine().ToLower();
                        Console.WriteLine();
                        break;
                }
            }

            Console.WriteLine();

            string[] strings = list.ToArray();
            Console.WriteLine("Unsorted array of strings:");
            ConsolePrintStringArray(strings);
            Console.WriteLine();

            CustomSort(strings, StringCompareByLength);

            Console.WriteLine("Sorted array of strings:");
            ConsolePrintStringArray(strings);
            Console.WriteLine();
        }

        private static void ConsolePrintStringArray(string[] array)
        {
            if (array.Length == 0)
            {
                Console.WriteLine("There is no elements in array.");
                return;
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"{(i + 1).ToString()}. '{array[i]}' - string length: {array[i].Length.ToString()}");
            }
        }

        private static int StringCompareByLength(string str1, string str2)
        {
            if (ReferenceEquals(str1, str2))
            {
                return 0;
            }

            if (string.IsNullOrEmpty(str1))
            {
                return 1;
            }

            if (string.IsNullOrEmpty(str2))
            {
                return -1;
            }

            if (string.IsNullOrWhiteSpace(str1))
            {
                return 1;
            }

            if (string.IsNullOrWhiteSpace(str2))
            {
                return -1;
            }

            if (str1.Length < str2.Length)
            {
                return -1;
            }
            else if (str1.Length > str2.Length)
            {
                return 1;
            }
            else
            {
                return StringAlphabeticCompare(str1, str2);
            }
        }

        private static int StringAlphabeticCompare(string str1, string str2)
        {
            int min = str1.Length < str2.Length 
                ? str1.Length 
                : str2.Length;

            int i;

            for (i = 0; i < min; i++)
            {
                if (char.ToUpper(str1[i]) < char.ToUpper(str2[i]))
                {
                    return -1;
                }

                if (char.ToUpper(str1[i]) > char.ToUpper(str2[i]))
                {
                    return 1;
                }
            }

            for (i = 0; i < min; i++)
            {
                if (char.IsLower(str1[i]))
                {
                    return -1;
                }

                if (char.IsLower(str2[i]))
                {
                    return 1;
                }
            }

            return 0;
        }

        private static void CustomSort<T>(T[] arr, Func<T, T, int> compareMethod)
        {
            CustomSort(arr, 0, arr.Length - 1, compareMethod);
        }

        private static void CustomSort<T>(T[] arr, int l, int r, Func<T, T, int> compareMethod)
        {
            int i = l;
            int j = r;
            T x = arr[l + ((r - l) / 2)];

            while (i <= j)
            {
                while (compareMethod(arr[i], x) < 0)
                {
                    i++;
                }

                while (compareMethod(arr[j], x) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    T temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    i++;
                    j--;
                }
            }

            if (l < j)
            {
                CustomSort(arr, l, j, compareMethod);
            }

            if (i < r)
            {
                CustomSort(arr, i, r, compareMethod);
            }
        }
    }
}
