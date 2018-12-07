using System;
using System.Collections.Generic;

namespace Epam.Task4.Lost
{
    internal class Program
    {
        private static bool check;
        private static bool numsCheck;
        private static int num;

        private static void Main()
        {
            Console.WriteLine("Greetings! You are using The Lost Program.");
            Console.WriteLine();
            while (!numsCheck)
            {
                try
                {
                    Console.Write("Enter the number of people in the circle: ");
                    check = int.TryParse(Console.ReadLine(), out num);
                    numsCheck = CheckValue(check, num);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                }
            }

            Console.WriteLine();

            int[] arr = new int[num];

            ArrayFill(arr);

            LinkedList<int> list = new LinkedList<int>(arr);

            RemainingValueIdintifier(list);

            int person = list.First.Value;

            Console.WriteLine($"Remaining person in circle has number: {person.ToString()}");
        }

        private static void RemainingValueIdintifier<T>(LinkedList<T> list)
        {
            var currentItem = list.First;

            while (list.Count > 1)
            {
                list.Remove(currentItem.Next ?? list.First);
                currentItem = currentItem.Next ?? list.First;
            }
        }

        private static void ArrayFill(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = i + 1;
            }
        }

        private static bool CheckValue(bool check, int num)
        {
            if (!check || num < 1)
            {
                throw new ArgumentException("Value must be greater than zero.");
            }

            return true;
        }
    }
}
