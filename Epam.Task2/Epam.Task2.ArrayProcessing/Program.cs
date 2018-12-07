using System;

namespace Epam.Task2.ArrayProcessing
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
            Console.WriteLine("Greetings! You are using The Array Processing Program!");
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
                        Console.Write("Please, enter a number from -100 to 100 for lower bound of numbers in array: ");
                        check = int.TryParse(Console.ReadLine(), out lowerBound);
                        BoundCheck(check, ref lowerBound);
                        Console.WriteLine();
                    }

                    if (upperBound == -101)
                    {
                        Console.Write("Please, enter a number from -100 to 100 for upper bound of numbers in array: ");
                        check = int.TryParse(Console.ReadLine(), out upperBound);
                        BoundCheck(check, ref upperBound);
                        Console.WriteLine();
                    }

                    ArrayFill(array, lowerBound, upperBound);

                    Console.WriteLine("The array contents the following numbers:");

                    PrintArray(array);
                    Console.WriteLine();

                    int minArrayValue = MinArrayValue(array);
                    Console.WriteLine($"The smallest number in the array is: {minArrayValue.ToString()}");
                    Console.WriteLine();

                    int maxArrayValue = MaxArrayValue(array);
                    Console.WriteLine($"The largest number in the array is: {maxArrayValue.ToString()}");
                    Console.WriteLine();

                    ArraySort(array);

                    Console.WriteLine("The array contents the following numbers after sorting:");

                    PrintArray(array);
                    Console.WriteLine();

                    return;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                }
            }
        }

        private static void LengthCheck(bool check, ref int value)
        {
            if (!check || value < 1)
            {
                value = 0;
                throw new ArgumentException("The array length must be a natural number more than 0.");
            }
        }

        private static void BoundCheck(bool check, ref int value)
        {
            if (!check || value < -100 || value > 101)
            {
                value = -101;
                throw new ArgumentOutOfRangeException(null, "The bound of numbers in array must be from -100 to 100.");
            }
        }

        private static void ArraySort(int[] arr)
        {
            QuickSort(arr, 0, arr.Length - 1);
        }

        private static void QuickSort(int[] arr, int l, int r)
        {
            int temp;
            int x = arr[(l + r) / 2];
            int i = l;
            int j = r;

            while (i <= j)
            {
                while (arr[i] < x)
                {
                    i++;
                }

                while (arr[j] > x)
                {
                    j--;
                }

                if (i <= j)
                {
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    i++;
                    j--;
                }
            }

            if (i < r)
            {
                QuickSort(arr, i, r);
            }

            if (l < j)
            {
                QuickSort(arr, l, j);
            }
        }

        private static int MaxArrayValue(int[] arr)
        {
            int temp = arr[0];

            for (int i = 1; i < arr.Length; i++)
            {
                if (temp < arr[i])
                {
                    temp = arr[i];
                }
            }

            return temp;
        }

        private static int MinArrayValue(int[] arr)
        {
            int temp = arr[0];

            for (int i = 1; i < arr.Length; i++)
            {
                if (temp > arr[i])
                {
                    temp = arr[i];
                }
            }

            return temp;
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
