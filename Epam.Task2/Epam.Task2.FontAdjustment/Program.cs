using System;

namespace Epam.Task2.FontAdjustment
{
    class Program
    {
        [Flags]
        private enum Fonts : byte
        {
            None = 0,
            Bold = 1,
            Italic = 2,
            Underline = 4,
        }

        static void Main()
        {
            Console.WriteLine("Greatings! You are using The "
                             + "Font Adjustment Program!");

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
                    bool check = byte.TryParse(Console.ReadLine(), out byte value);
                    
                    if (!check || value < 1 || value > 4)
                    {
                        throw new ArgumentException("Entered value is not correct.");
                    }

                    switch (value)
                    {
                        case 1:
                        case 2:
                            if (fonts.HasFlag((Fonts)value))
                            {
                                fonts -= value;
                            }
                            else
                            {
                                fonts += value;
                            }
                            break;

                        case 3:
                            if (fonts.HasFlag((Fonts)value + 1))
                            {
                                fonts -= (byte)(value + 1);
                            }
                            else
                            {
                                fonts += (byte)(value + 1);
                            }
                            break;

                        case 4:
                            Console.WriteLine("Quiting the program.");
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
