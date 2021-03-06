﻿using System;

namespace Epam.Task2._2DArray
{
    internal class Program
    {
        private static int arrDimOne = 0;
        private static int arrDimTwo = 0;
        private static int upperBound = 0;
        private static bool check;
        private static Random random = new Random();

        private static void Main()
        {
            Console.WriteLine($"Greetings! You are using The Even Position Numbers Summing{Environment.NewLine}in Two-Dimensional Array Program!");
            Console.WriteLine();

            while (true)
            {
                try
                {
                    if (arrDimOne == 0)
                    {
                        Console.Write($"Please, enter a natural number more than 0 for the first dimension{Environment.NewLine}of two-dimensional array: ");
                        check = int.TryParse(Console.ReadLine(), out arrDimOne);
                        DimensionCheck(check, ref arrDimOne);
                        Console.WriteLine();
                    }

                    if (arrDimTwo == 0)
                    {
                        Console.Write($"Please, enter a natural number more than 0 for the second dimension{Environment.NewLine}of two-dimensional array: ");
                        check = int.TryParse(Console.ReadLine(), out arrDimTwo);
                        DimensionCheck(check, ref arrDimTwo);
                        Console.WriteLine();
                    }

                    int[,] array = new int[arrDimOne, arrDimTwo];

                    if (upperBound == 0)
                    {
                        Console.Write("Please, enter a number from 1 to 100 for upper bound of numbers in array: ");
                        check = int.TryParse(Console.ReadLine(), out upperBound);
                        BoundCheck(check, ref upperBound);
                        Console.WriteLine();
                    }

                    ArrayFill(array, upperBound);

                    Console.WriteLine("The array contents the following numbers:");

                    PrintArray(array);
                    Console.WriteLine();

                    int evenPositionSum = EvenPositionSum(array);
                    Console.WriteLine($"The sum of even-positioned numbers in array is: {evenPositionSum.ToString()}");

                    return;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                }
            }
        }

        private static int EvenPositionSum(int[,] arr)
        {
            int sum = 0;

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if ((i + j) % 2 == 0)
                    {
                        sum += arr[i, j];
                    }
                }
            }

            return sum;
        }

        private static void DimensionCheck(bool check, ref int value)
        {
            if (!check || value < 1)
            {
                value = 0;
                throw new ArgumentException("The array dimension must be a natural number more than 0.");
            }
        }

        private static void BoundCheck(bool check, ref int value)
        {
            if (!check || value < 1 || value > 100)
            {
                value = 0;
                throw new ArgumentOutOfRangeException(null, "The upper bound of numbers in array must be from 1 to 100.");
            }
        }

        private static void ArrayFill(int[,] arr, int upperBound)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = random.Next(upperBound + 1);
                }
            }
        }

        private static void PrintArray(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (j == arr.GetLength(1) - 1)
                    {
                        Console.Write(arr[i, j]);
                    }
                    else
                    {
                        Console.Write(arr[i, j] + ", ");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
