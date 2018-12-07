using System;

namespace Epam.Task2.Rectangle
{
    internal class Program
    {
        private static int sideA = 0;
        private static bool check;

        private static void Main()
        {
            Console.WriteLine("Greetings! You are using The Rectangle Area Calculator Program!");
            Console.WriteLine();
            
            while (true)
            {
                try
                {
                    if (sideA == 0)
                    {
                        Console.Write("Please, enter a value for side a: ");
                        check = int.TryParse(Console.ReadLine(), out sideA);
                        ValueCheck(check, ref sideA);
                        Console.WriteLine();
                    }

                    Console.Write("Please, enter a value for side b: ");
                    check = int.TryParse(Console.ReadLine(), out int sideB);
                    ValueCheck(check, ref sideB);
                    Console.WriteLine();

                    int rectArea = RectArea(sideA, sideB);
                    Console.WriteLine($"The area of the rectangle with side a = {sideA} and side b = {sideB} is: {rectArea.ToString()}");
                    return;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                }
            }
        }

        private static int RectArea(int a, int b)
        {
            int area = a * b;
            return area;
        }

        private static void ValueCheck(bool check, ref int val)
        {
            if (!check || val < 1)
            {
                val = 0;
                throw new ArgumentException("The entered value must be a natural number.");
            }
        }
    }
}
