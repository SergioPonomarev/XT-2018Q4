using System;

namespace Epam.Task2.NoPositive
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Greatings! You are using The "
                             + "Positive Numbers Changer Program!");
            Console.WriteLine();

            int arrDimOne = 0;
            int arrDimTwo = 0;
            int arrDimThree = 0;
            int lowerBound = -101;
            int upperBound = -101;
            bool check;

            while (true)
            {
                try
                {
                    if (arrDimOne == 0)
                    {
                        Console.Write($"Please, enter a natural number"
                                      + $" more than 0 for the first "
                                      + $"dimension{Environment.NewLine}"
                                      + $"of three-dimensional array: ");
                        check = int.TryParse(Console.ReadLine(),
                                             out arrDimOne);
                        DimensionCheck(check, ref arrDimOne);
                        Console.WriteLine();
                    }

                    if (arrDimTwo == 0)
                    {
                        Console.Write($"Please, enter a natural number"
                                      + $" more than 0 for the second "
                                      + $"dimension{Environment.NewLine}"
                                      + $"of three-dimensional array: ");
                        check = int.TryParse(Console.ReadLine(),
                                             out arrDimTwo);
                        DimensionCheck(check, ref arrDimTwo);
                        Console.WriteLine();
                    }

                    if (arrDimThree == 0)
                    {
                        Console.Write($"Please, enter a natural number"
                                      + $" more than 0 for the third "
                                      + $"dimension{Environment.NewLine}"
                                      + $"of three-dimensional array: ");
                        check = int.TryParse(Console.ReadLine(),
                                             out arrDimThree);
                        DimensionCheck(check, ref arrDimThree);
                        Console.WriteLine();
                    }

                    int[,,] array = new int[arrDimOne, 
                                            arrDimTwo, 
                                            arrDimThree];

                    if (lowerBound == -101)
                    {
                        Console.Write("Please, enter a number from"
                                     + " -100 to -1 for lower bound"
                                      + " of numbers in array: ");
                        check = int.TryParse(Console.ReadLine(),
                                             out lowerBound);
                        LowerBoundCheck(check, ref lowerBound);
                        Console.WriteLine();
                    }

                    if (upperBound == -101)
                    {
                        Console.Write("Please, enter a number from"
                                     + " 0 to 100 for upper bound"
                                      + " of numbers in array: ");
                        check = int.TryParse(Console.ReadLine(),
                                             out upperBound);
                        UpperBoundCheck(check, ref upperBound);
                        Console.WriteLine();
                    }

                    ArrayFill(array, lowerBound, upperBound);

                    Console.WriteLine("The array contents the following "
                                      + "numbers:");

                    PrintArray(array);

                    ChangePositiveNum(array);

                    Console.WriteLine("The array contents the following "
                                      + $"numbers after changing{Environment.NewLine}"
                                      + "all positive numbers to 0:");

                    PrintArray(array);

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

        private static void ChangePositiveNum(int[,,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    for (int k = 0; k < arr.GetLength(2); k++)
                    {
                        if (arr[i, j, k] > 0)
                        {
                            arr[i, j, k] = 0;
                        }
                    }
                }
            }
        }

        private static void DimensionCheck(bool check, ref int value)
        {
            if (!check || value < 1)
            {
                value = 0;
                throw new ArgumentException("The array dimension must be a "
                                        + "natural number more than 0.");
            }
        }

        private static void LowerBoundCheck(bool check, ref int value)
        {
            if (!check || value < -100 || value > -1)
            {
                value = -101;
                throw new ArgumentOutOfRangeException(null, "The bound of "
                          + "numbers in array must be from -100 to -1.");
            }
        }

        private static void UpperBoundCheck(bool check, ref int value)
        {
            if (!check || value < 0 || value > 100)
            {
                value = -101;
                throw new ArgumentOutOfRangeException(null, "The bound of "
                          + "numbers in array must be from 0 to 100.");
            }
        }

        private static void ArrayFill(int[,,] arr,
                                      int lowerBound,
                                      int upperBound)
        {
            Random random = new Random();

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    for (int k = 0; k < arr.GetLength(2); k++)
                    {
                        arr[i, j, k] = random.Next(lowerBound, upperBound);
                    }
                }
            }
        }

        private static void PrintArray(int[,,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    for (int k = 0; k < arr.GetLength(2); k++)
                    {
                        if (k == arr.GetLength(2) - 1)
                        {
                            Console.Write(arr[i, j, k]);
                        }
                        else
                        {
                            Console.Write(arr[i, j, k] + ", ");
                        }
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
    }
}
