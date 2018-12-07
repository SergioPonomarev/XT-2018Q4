using System;

namespace Epam.Task3.RingProgram
{
    internal class Program
    {
        private static bool check;
        private static bool blockCheck;
        private static int innerRadius;
        private static int outerRadius;
        private static int xCoord;
        private static int yCoord;

        private static void Main()
        {
            Console.WriteLine("Greetings! You are using The Ring Creating Program!");
            Console.WriteLine();

            while (!blockCheck)
            {
                try
                {
                    Console.Write("Please, enter an integer for X coordinate of the center point of the ring: ");
                    check = int.TryParse(Console.ReadLine(), out xCoord);

                    blockCheck = CheckCoord(check);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                }
            }

            Console.WriteLine();
            blockCheck = false;

            while (!blockCheck)
            {
                try
                {
                    Console.Write("Please, enter an integer for Y coordinate of the center point of the round: ");
                    check = int.TryParse(Console.ReadLine(), out yCoord);

                    blockCheck = CheckCoord(check);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                }
            }

            Console.WriteLine();
            blockCheck = false;

            while (!blockCheck)
            {
                try
                {
                    Console.Write("Please, enter a natural number for the inner radius of the ring: ");
                    check = int.TryParse(Console.ReadLine(), out innerRadius);

                    blockCheck = CheckRadius(check, innerRadius);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                }
            }

            Console.WriteLine();
            blockCheck = false;

            while (!blockCheck)
            {
                try
                {
                    Console.Write("Please, enter a natural number for the outer radius of the ring: ");
                    check = int.TryParse(Console.ReadLine(), out outerRadius);

                    if (CheckRadius(check, outerRadius))
                    {
                        blockCheck = CheckRadiusDiference(innerRadius, outerRadius);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                }
            }

            Console.WriteLine();

            Ring ring = new Ring(xCoord, yCoord, innerRadius, outerRadius);

            Console.WriteLine("The Ring is created:");

            int innerRR = ring.InnerRadius;
            Console.WriteLine($"\t- the inner radius is: {innerRR.ToString()};");

            int outerRR = ring.OuterRadius;
            Console.WriteLine($"\t- the outer radius is: {outerRR.ToString()};");

            int x = ring.Center.X;
            int y = ring.Center.Y;
            Console.WriteLine($"\t- the center point is: x = {x.ToString()} and y = {y.ToString()};");

            double circum = ring.RingCircumference;
            Console.WriteLine($"\t- the sum of inner and outer rounds circumference is: {circum.ToString()};");

            double area = ring.RingArea;
            Console.WriteLine($"\t- the area is: {area.ToString()}.");
        }

        private static bool CheckRadiusDiference(int innerR, int outerR)
        {
            if (innerR > outerR)
            {
                throw new ArgumentException("Inner radius of the ring mustn't be greater than outer radius of the ring.");
            }

            return true;
        }

        private static bool CheckRadius(bool check, int value)
        {
            if (!check || value < 0)
            {
                throw new ArgumentException("The radius of the round must be greater than or equal to 0.");
            }

            return true;
        }

        private static bool CheckCoord(bool check)
        {
            if (!check)
            {
                throw new ArgumentException("The coordinate must be an integer.");
            }

            return true;
        }
    }
}
