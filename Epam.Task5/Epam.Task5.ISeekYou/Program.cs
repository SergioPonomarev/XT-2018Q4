using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Epam.Task5.NumberArraySum;

namespace Epam.Task5.ISeekYou
{
    internal class Program
    {
        private static List<double> timeCounts = new List<double>();
        private static Stopwatch sw = new Stopwatch();
        private static int result;

        private static void Main()
        {
            Console.WriteLine("This is The Time Performance Comparing Program.");
            Console.WriteLine();

            Console.WriteLine("Five different ways to count positive elements in an array.");
            Console.WriteLine("Number of elements in the array: 100.");
            Console.WriteLine("Number of iterations of each method: 100.");
            Console.WriteLine();

            int[] array = new int[100];

            ArrayFill(array);

            Console.WriteLine("Regular method to count positive array elements:");

            for (int i = 0; i < 100; i++)
            {
                sw.Reset();
                sw.Start();

                result = PositiveElementsArrayCount(array);

                timeCounts.Add(sw.Elapsed.TotalMilliseconds);
            }

            Console.WriteLine($"Average time of performance: {timeCounts.Average()} msc.");

            Console.WriteLine();

            Console.WriteLine("Method to count positive elements in an array to which the compare condition is passed by the delegate instance:");

            for (int i = 0; i < 100; i++)
            {
                sw.Reset();
                sw.Start();

                result = PositiveElementsArrayCountDelegate(array, CompareToZero);

                timeCounts.Add(sw.Elapsed.TotalMilliseconds);
            }

            Console.WriteLine($"Average time of performance: {timeCounts.Average()} msc.");

            Console.WriteLine();

            Console.WriteLine("Method to count positive elements in an array to which the compare condition is passed by anonymous method:");

            for (int i = 0; i < 100; i++)
            {
                sw.Reset();
                sw.Start();

                result = PositiveElementsArrayCountDelegate(
                            array, 
                            delegate(int num)
                            {
                                return num > 0;
                            });

                timeCounts.Add(sw.Elapsed.TotalMilliseconds);
            }

            Console.WriteLine($"Average time of performance: {timeCounts.Average()} msc.");

            Console.WriteLine();

            Console.WriteLine("Method to count positive elements in an array to which the compare condition is passed by lambda expression:");

            for (int i = 0; i < 100; i++)
            {
                sw.Reset();
                sw.Start();

                result = PositiveElementsArrayCountDelegate(array, n => n > 0);

                timeCounts.Add(sw.Elapsed.TotalMilliseconds);
            }

            Console.WriteLine($"Average time of performance: {timeCounts.Average()} msc.");

            Console.WriteLine();

            Console.WriteLine("Positive array elements counted by linq method:");

            for (int i = 0; i < 100; i++)
            {
                sw.Reset();
                sw.Start();

                result = array.Count(n => n > 0);

                timeCounts.Add(sw.Elapsed.TotalMilliseconds);
            }

            Console.WriteLine($"Average time of performance: {timeCounts.Average()} msc.");

            Console.WriteLine();
        }

        private static void ArrayFill(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = SingleRandom.Next(-100, 101);
            }
        }

        private static int PositiveElementsArrayCount(int[] arr)
        {
            int count = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > 0)
                {
                    count++;
                }
            }

            return count;
        }

        private static int PositiveElementsArrayCountDelegate(int[] arr, Func<int, bool> compareMethod)
        {
            int count = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (compareMethod(arr[i]))
                {
                    count++;
                }
            }

            return count;
        }

        private static bool CompareToZero(int value)
        {
            return value > 0;
        }
    }
}
