using System;

namespace Epam.Task2.FontAdjustment
{
    class Program
    {
        private static int[] values = new int[3];

        [Flags]
        private enum Fonts
        {
            None = 0,
            Bold = 1,
            Italic = 2,
            Underline = 4,
        }

        static void Main()
        {
            Console.WriteLine("Greatings! You are using The "
                             + "Font Adjustment Programm");

            Fonts fonts = Fonts.None;
            while (true)
            {
                try
                {
                    Console.WriteLine();
                    Console.Write("Actual font adjustment: ");
                    Console.WriteLine(fonts);
                    Console.WriteLine();

                    ShowMenu();

                    Console.Write("Enter a number of adjustment from menu: ");
                    bool check = int.TryParse(Console.ReadLine(), out int value);
                    
                    if (!check || value < 1 || value > 4)
                    {
                        throw new ArgumentException("Entered value is not correct.");
                    }

                    switch (value)
                    {
                        case 1:
                        case 2:
                            if (CheckValue(value))
                            {
                                RemoveValue(ref fonts, value);
                            }
                            else
                            {
                                AddValue(ref fonts, value);
                            }
                            break;

                        case 3:
                            if (CheckValue(value + 1))
                            {
                                RemoveValue(ref fonts, value + 1);
                            }
                            else
                            {
                                AddValue(ref fonts, value + 1);
                            }
                            break;

                        case 4:
                            Console.WriteLine("Quiting the programm.");
                            return;
                    }

                }
                catch (ArgumentException ex)
                {
                    ConsoleColor color = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine();
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = color;
                }

            }
        }

        private static bool CheckValue(int value)
        {
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] == value)
                {
                    return true;
                }
            }
            return false;
        }

        private static void AddValue(ref Fonts fonts, int value)
        {
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] == 0)
                {
                    values[i] = value;
                    break;
                }
            }
            fonts += value;
        }

        private static void RemoveValue(ref Fonts fonts, int value)
        {
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] == value)
                {
                    values[i] = 0;
                    break;
                }
            }
            fonts -= value;
        }

        private static void ShowMenu()
        {
            ConsoleColor color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Please, choose font adjustment to apply:");
            Console.WriteLine("\t1: Bold");
            Console.WriteLine("\t2: Italic");
            Console.WriteLine("\t3: Underline");
            Console.WriteLine("\t4: for quit from the programm");
            Console.ForegroundColor = color;
            Console.WriteLine();
        }
    }
}
