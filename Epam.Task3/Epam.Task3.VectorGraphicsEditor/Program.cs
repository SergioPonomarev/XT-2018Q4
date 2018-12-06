using System;
using Epam.Task3.VectorGraphicsEditor.Entities;

namespace Epam.Task3.VectorGraphicsEditor
{
    internal class Program
    {
        private static Circle circle;
        private static Line line;
        private static Rectangle rectangle;
        private static Ring ring;
        private static Round round;
        private static bool createMenu = true;
        private static bool listMenu = true;
        private static Figure[] figures;

        private static void Main()
        {
            Console.WriteLine("Greetings! You are using Vector Graphics Editor Program.");
            Console.WriteLine();

            while (true)
            {
                ShowMainMenu();
                string choice = ReadMenuChoice();
                Console.WriteLine();
                switch (choice)
                {
                    case "create":
                        createMenu = true;
                        while (createMenu)
                        {
                            ShowCreateMenu();
                            choice = ReadMenuChoice();
                            Console.WriteLine();
                            switch (choice)
                            {
                                case "circle":
                                    circle = Circle.CreateFigure();
                                    Console.WriteLine();
                                    SaveFigure(circle);
                                    ConsolePrintFigure(circle);
                                    Console.WriteLine();
                                    break;

                                case "line":
                                    line = Line.CreateFigure();
                                    Console.WriteLine();
                                    SaveFigure(line);
                                    ConsolePrintFigure(line);
                                    Console.WriteLine();
                                    break;

                                case "rectangle":
                                    rectangle = Rectangle.CreateFigure();
                                    Console.WriteLine();
                                    SaveFigure(rectangle);
                                    ConsolePrintFigure(rectangle);
                                    Console.WriteLine();
                                    break;

                                case "ring":
                                    ring = Ring.CreateFigure();
                                    Console.WriteLine();
                                    SaveFigure(ring);
                                    ConsolePrintFigure(ring);
                                    Console.WriteLine();
                                    break;

                                case "round":
                                    round = Round.CreateFigure();
                                    Console.WriteLine();
                                    SaveFigure(round);
                                    ConsolePrintFigure(round);
                                    Console.WriteLine();
                                    break;

                                case "quit":
                                    createMenu = false;
                                    break;

                                default:
                                    break;
                            }
                        }

                        break;

                    case "list":
                        listMenu = true;
                        bool check = false;
                        while (listMenu)
                        {
                            ShowListMenu();
                            choice = ReadMenuChoice();
                            Console.WriteLine();
                            switch (choice)
                            {
                                case "show":
                                    ShowFiguresList();
                                    break;

                                case "print":
                                    {
                                        Console.Write("Enter a number of the figure to print: ");
                                        check = int.TryParse(Console.ReadLine(), out int number);
                                        Console.WriteLine();
                                        if (!check)
                                        {
                                            Console.WriteLine("Must be a number.");
                                            Console.WriteLine();
                                        }
                                        else
                                        {
                                            if (number < 1 || number > figures.Length)
                                            {
                                                Console.WriteLine("There is no such number in the figures list.");
                                                Console.WriteLine();
                                            }
                                            else
                                            {
                                                Figure figure = FindFigure(number);

                                                ConsolePrintFigure(figure);
                                                Console.WriteLine();
                                            }
                                        }
                                    }

                                    break;

                                case "remove":
                                    {
                                        Console.Write("Enter a number of the figure to remove: ");
                                        check = int.TryParse(Console.ReadLine(), out int number);
                                        Console.WriteLine();
                                        if (!check)
                                        {
                                            Console.WriteLine("Must be a number.");
                                            Console.WriteLine();
                                        }
                                        else
                                        {
                                            if (number < 1 || number > figures.Length)
                                            {
                                                Console.WriteLine("There is no such number in the figures list.");
                                                Console.WriteLine();
                                            }
                                            else
                                            {
                                                RemoveFigure(number - 1);
                                            }
                                        }
                                    }

                                    break;

                                default:
                                    break;

                                case "quit":
                                    listMenu = false;
                                    break;
                            }
                        }

                        break;

                    case "quit":
                        return;

                    default:
                        break;
                }
            }
        }

        private static void RemoveFigure(int number)
        {
            Figure[] temp = new Figure[figures.Length - 1];

            for (int i = 0, j = 0; i < figures.Length; i++)
            {
                if (i == number)
                {
                    continue;
                }

                temp[j] = figures[i];
                j++;
            }

            figures = temp;

            Console.WriteLine("Figure is removed.");
            Console.WriteLine();
        }

        private static Figure FindFigure(int number)
        {
            return figures[number - 1];
        }

        private static void ShowListMenu()
        {
            Console.WriteLine("List menu:");
            Console.WriteLine("- Show - show list of figures");
            Console.WriteLine("- Print - print specified figure");
            Console.WriteLine("- Remove - remove specified figure");
            Console.WriteLine("- Quit - quit from List menu and go to Main menu");
            Console.Write("Choose your option: ");
        }

        private static void ShowFiguresList()
        {
            if (figures == null)
            {
                Console.WriteLine("There is no items in list.");
                Console.WriteLine();
            }
            else
            {
                for (int i = 0; i < figures.Length; i++)
                {
                    Console.WriteLine($"- {(i + 1).ToString()}. {figures[i].Name}");
                }

                Console.WriteLine();
            }
        }

        private static void SaveFigure(Figure figure)
        {
            if (figures == null)
            {
                figures = new Figure[1];
                figures[0] = figure;
            }
            else
            {
                Figure[] temp = new Figure[figures.Length + 1];

                for (int i = 0; i < figures.Length; i++)
                {
                    temp[i] = figures[i];
                }

                temp[figures.Length] = figure;

                figures = temp;
            }

            Console.WriteLine("Figure is saved.");
            Console.WriteLine();
        }

        private static void ShowMainMenu()
        {
            Console.WriteLine("Main menu:");
            Console.WriteLine("- Create - create a figure");
            Console.WriteLine("- List - show list of figures");
            Console.WriteLine("- Quit - quit the program");
            Console.Write("Choose your option: ");
        }

        private static void ShowCreateMenu()
        {
            Console.WriteLine("Creating menu:");
            Console.WriteLine("- Circle - create a circle");
            Console.WriteLine("- Line - create a line");
            Console.WriteLine("- Rectangle - create a rectangle");
            Console.WriteLine("- Ring - create a ring");
            Console.WriteLine("- Round - create a round");
            Console.WriteLine("- Quit - quit the creating menu and go to Main menu");
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
