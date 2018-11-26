using System;

namespace Epam.Task2.NonNegativeSum
{
    internal class Program
    {
        private static int arrayLength = 0;
        private static int lowerBound = -101;
        private static int upperBound = -101;
        private static bool check;
        private static Random random = new Random();

        private static void Main()
        {
            Console.WriteLine("Greatings! You are using The Non-Negative Numbers Summing in Array Program!");
            Console.WriteLine();

            while (true)
            {
                try
                {
                    if (arrayLength == 0)
                    {
                        Console.Write("Please, enter a natural number more than 0 for array length: ");
                        check = int.TryParse(Console.ReadLine(), out arrayLength);
                        LengthCheck(check, ref arrayLength);
                        Console.WriteLine();
                    }

                    int[] array = new int[arrayLength];

                    if (lowerBound == -101)
                    {
                        Console.Write("Please, enter a number from -100 to -1 for lower bound of numbers in array: ");
                        check = int.TryParse(Console.ReadLine(), out lowerBound);
                        LowerBoundCheck(check, ref lowerBound);
                        Console.WriteLine();
                    }

                    if (upperBound == -101)
                    {
                        Console.Write("Please, enter a number from 0 to 100 for upper bound of numbers in array: ");
                        check = int.TryParse(Console.ReadLine(), out upperBound);
                        UpperBoundCheck(check, ref upperBound);
                        Console.WriteLine();
                    }

                    ArrayFill(array, lowerBound, upperBound);

                    Console.WriteLine("The array contents the following numbers:");

                    PrintArray(array);
                    Console.WriteLine();

                    int nonNegativeSum = NonNegativeSum(array);
                    Console.WriteLine($"The sum of non-negative numbers in array is: {nonNegativeSum.ToString()}");

                    return;
                }

                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                }
            }
        }

        private static int NonNegativeSum(int[] arr)
        {
            int sum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > 0)
                {
                    sum += arr[i];
                }
            }

            return sum;
        }

        private static void LengthCheck(bool check, ref int value)
        {
            if (!check || value < 1)
            {
                value = 0;
                throw new ArgumentException("The array length must be a natural number more than 0.");
            }
        }

        private static void LowerBoundCheck(bool check, ref int value)
        {
            if (!check || value < -100 || value > -1)
            {
                value = -101;
                throw new ArgumentOutOfRangeException(null, "The bound of numbers in array must be from -100 to -1.");
            }
        }

        private static void UpperBoundCheck(bool check, ref int value)
        {
            if (!check || value < 0 || value > 100)
            {
                value = -101;
                throw new ArgumentOutOfRangeException(null, "The bound of numbers in array must be from 0 to 100.");
            }
        }

        private static void ArrayFill(int[] arr, int lowerBound, int upperBound)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(lowerBound, upperBound + 1);
            }
        }

        private static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (i == arr.Length - 1)
                {
                    Console.Write(arr[i].ToString());
                }
                else
                {
                    Console.Write(arr[i].ToString() + ", ");
                }
            }

            Console.WriteLine();
        }
    }
}
