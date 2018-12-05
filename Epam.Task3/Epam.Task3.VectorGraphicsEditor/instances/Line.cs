using System;

namespace Epam.Task3.VectorGraphicsEditor.instances
{
    public class Line : Figure
    {
        private int length;

        public Line(int length, int xCoord, int yCoord)
        {
            this.Length = length;
            this.Center = new Point(xCoord, yCoord);
        }

        public Line(int length, Point center)
        {
            this.Length = length;
            this.Center = center;
        }

        public override Point Center { get; set; }

        public int Length
        {
            get => length;

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Line length must be greater than or equal to 0.");
                }

                length = value;
            }
        }

        public override string ShowFigure()
        {
            return string.Format($"Type figure: {this.GetType().Name}{Environment.NewLine}" +
                $"Center point coordinates: {this.Center.X}, {this.Center.Y}{Environment.NewLine}" +
                $"Length: {this.Length}");
        }

        public static Line CreateFigure()
        {
            bool check = false;
            bool checkLength = false;
            bool checkXCoord = false;
            bool checkYCoord = false;
            int length = 0;
            int xCoord = 0;
            int yCoord = 0;
            Line line;

            while (!checkLength)
            {
                try
                {
                    Console.Write("Please, enter a natural number for the length of the line: ");
                    check = int.TryParse(Console.ReadLine(), out length);

                    checkLength = CheckLength(check, length);
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
                    Console.Write("Please, enter an integer for X coordinate of the center point: ");
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
                    Console.Write("Please, enter an integer for Y coordinate of the center point: ");
                    check = int.TryParse(Console.ReadLine(), out yCoord);

                    checkYCoord = CheckCoord(check);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                }
            }

            line = new Line(length, xCoord, yCoord);

            return line;
        }

        private static bool CheckLength(bool check, int value)
        {
            if (!check || value < 0)
            {
                throw new ArgumentException("The length of the line must be greater than or equal to 0.");
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
