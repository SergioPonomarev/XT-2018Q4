using System;
using Epam.Task3.VectorGraphicsEditor.Instances;

namespace Epam.Task3.VectorGraphicsEditor
{
    internal class Program
    {
        private static Circle circle;
        private static Line line;
        private static Rectangle rectangle;
        private static Ring ring;
        private static Round round;

        private static void Main(string[] args)
        {
            Console.WriteLine("Greetings! You are using Vector Graphics Editor Program.");
            Console.WriteLine();

            while (true)
            {
                ShowMenu();
                string choice = ReadMenuChoice();
                Console.WriteLine();
                switch (choice)
                {
                    case "circle":
                        circle = Circle.CreateFigure();
                        Console.WriteLine();
                        ConsolePrintFigure(circle);
                        Console.WriteLine();
                        break;

                    case "line":
                        line = Line.CreateFigure();
                        Console.WriteLine();
                        ConsolePrintFigure(line);
                        Console.WriteLine();
                        break;

                    case "rectangle":
                        rectangle = Rectangle.CreateFigure();
                        Console.WriteLine();
                        ConsolePrintFigure(rectangle);
                        Console.WriteLine();
                        break;

                    case "ring":
                        ring = Ring.CreateFigure();
                        Console.WriteLine();
                        ConsolePrintFigure(ring);
                        Console.WriteLine();
                        break;

                    case "round":
                        round = Round.CreateFigure();
                        Console.WriteLine();
                        ConsolePrintFigure(round);
                        Console.WriteLine();
                        break;

                    case "quit":
                        return;

                    default:
                        break;
                }
            }
        }

        private static void ShowMenu()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("- Circle - create a circle");
            Console.WriteLine("- Line - create a line");
            Console.WriteLine("- Rectangle - create a rectangle");
            Console.WriteLine("- Ring - create a ring");
            Console.WriteLine("- Round - create a round");
            Console.WriteLine("- Quit - quit the program");
            Console.Write("Choose your option: ");
        }

        private static string ReadMenuChoice()
        {
            string choice = Console.ReadLine();

            return choice.ToLower();
        }

        private static void ConsolePrintFigure<T>(T value)
            where T : Figure
        {
            Console.WriteLine(value.ShowFigure());
        }
    }
}
