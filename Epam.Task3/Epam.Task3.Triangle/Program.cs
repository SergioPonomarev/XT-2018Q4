using System;

namespace Epam.Task3.Triangle
{
    internal class Program
    {
        private static bool check;
        private static bool sideCheck;
        private static Triangle triangle;

        private static void Main()
        {
            triangle = new Triangle();

            Console.WriteLine($"Greetings! You are using The Triangle Creating Program!");
            Console.WriteLine();

            while (!sideCheck)
            {
                try
                {
                    Console.Write("Please, enter a value for the Side A of the triangle: ");
                    check = int.TryParse(Console.ReadLine(), out int value);

                    triangle.SideA = value;

                    sideCheck = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                }
            }

            Console.WriteLine();
            sideCheck = false;

            while (!sideCheck)
            {
                try
                {
                    Console.Write("Please, enter a value for the Side B of the triangle: ");
                    check = int.TryParse(Console.ReadLine(), out int value);

                    triangle.SideB = value;

                    sideCheck = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                }
            }

            Console.WriteLine();
            sideCheck = false;

            while (!sideCheck)
            {
                try
                {
                    Console.Write("Please, enter a value for the Side C of the triangle: ");
                    check = int.TryParse(Console.ReadLine(), out int value);

                    triangle.SideC = value;

                    sideCheck = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                }
            }

            Console.WriteLine();

            Console.WriteLine("The Triangle is created:");

            int a = triangle.SideA;
            int b = triangle.SideB;
            int c = triangle.SideC;
            Console.WriteLine($"\t- the side A is: {a.ToString()}, the side B is: {b.ToString()}, the side C is: {c.ToString()};");

            double p = triangle.GetTrianglePerimeter();
            Console.WriteLine($"\t- the perimeter of the triangle is: {p.ToString()};");

            double area = triangle.GetTriangleArea();
            Console.WriteLine($"\t- the area of the triangle is: {area.ToString()}.");
        }
    }
}
