using System;

namespace Epam.Task3.VectorGraphicsEditor.Entities
{
    public class Line : Figure
    {
        private static int count;

        private int length;

        static Line()
        {
            Line.count = 0;
        }

        public Line(int length, int xCoord, int yCoord)
        {
            this.Length = length;
            this.Center = new Point(xCoord, yCoord);
            Line.count++;
            this.Name = $"Line{Line.count.ToString()}";
        }

        public Line(int length, Point center)
        {
            this.Length = length;
            this.Center = center;
            Line.count++;
            this.Name = $"Line{Line.count.ToString()}";
        }

        public override string Name { get; }

        public override Point Center { get; set; }

        public int Length
        {
            get => this.length;

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Line length must be greater than or equal to 0.");
                }

                this.length = value;
            }
        }

        public static Line CreateFigure()
        {
            bool check = false;
            bool blockCheck = false;
            int length = 0;
            int xCoord = 0;
            int yCoord = 0;

            while (!blockCheck)
            {
                try
                {
                    Console.Write("Please, enter a natural number for the length of the line: ");
                    check = int.TryParse(Console.ReadLine(), out length);

                    blockCheck = CheckLength(check, length);
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
                    Console.Write("Please, enter an integer for X coordinate of the center point: ");
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
                    Console.Write("Please, enter an integer for Y coordinate of the center point: ");
                    check = int.TryParse(Console.ReadLine(), out yCoord);

                    blockCheck = CheckCoord(check);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                }
            }

            return new Line(length, xCoord, yCoord);
        }

        public override string ShowFigure()
        {
            return string.Format($"Type figure: {this.GetType().Name}{Environment.NewLine}" +
                $"Center point coordinates: {this.Center.X}, {this.Center.Y}{Environment.NewLine}" +
                $"Length: {this.Length}");
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
