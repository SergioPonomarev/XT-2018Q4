using System;

namespace Epam.Task3.Round
{
    internal class Program
    {
        private static bool check;
        private static bool checkRadius;
        private static bool checkXCoord;
        private static bool checkYCoord;
        private static int radius;
        private static int xCoord;
        private static int yCoord;

        private static void Main()
        {
            Console.WriteLine("Greetings! You are using The Round Creating Program!");
            Console.WriteLine();

            while (!checkRadius)
            {
                try
                {
                    Console.Write("Please, enter a natural number for the radius of the round: ");
                    check = int.TryParse(Console.ReadLine(), out radius);

                    checkRadius = CheckRadius(check, radius);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                }
            }

            Console.WriteLine();

            while (!checkXCoord)
            {
                try
                {
                    Console.Write("Please, enter an integer for X coordinate of the center point of the round: ");
                    check = int.TryParse(Console.ReadLine(), out xCoord);

                    checkXCoord = CheckCoord(check);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                }
            }

            Console.WriteLine();

            while (!checkYCoord)
            {
                try
                {
                    Console.Write("Please, enter an integer for Y coordinate of the center point of the round: ");
                    check = int.TryParse(Console.ReadLine(), out yCoord);

                    checkYCoord = CheckCoord(check);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                }
            }

            Console.WriteLine();

            Round round = new Round(radius, xCoord, yCoord);

            Console.WriteLine("Round created:");
            Console.WriteLine($"\t- the radius is: {round.Radius};");
            Console.WriteLine($"\t- the center point is: x = {round.Center.X} and y = {round.Center.Y};");
            Console.WriteLine($"\t- the length of circumference is: {round.Circumference};");
            Console.WriteLine($"\t- the area is: {round.Area};");
        }

        private static bool CheckRadius(bool check, int value)
        {
            if (!check || value <= 0)
            {
                throw new ArgumentException("The radius of the round must be more than 0.");
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
