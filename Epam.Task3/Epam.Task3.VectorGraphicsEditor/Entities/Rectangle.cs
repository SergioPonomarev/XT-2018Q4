using System;

namespace Epam.Task3.VectorGraphicsEditor.Entities
{
    public class Rectangle : Figure
    {
        private int width;
        private int height;

        public Rectangle(int width, int height, int centerX, int centerY)
        {
            this.Width = width;
            this.Height = height;
            this.Center = new Point(centerX, centerY);
        }

        public Rectangle(int width, int height, Point center)
        {
            this.Width = width;
            this.Height = height;
            this.Center = center;
        }

        public override Point Center { get; set; }

        public int Width
        {
            get => this.width;

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Rectangle width must be greater than or equal to 0.");
                }

                this.width = value;
            }
        }

        public int Height
        {
            get => this.height;

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Rectangle height must be greater than or equal to 0.");
                }

                this.height = value;
            }
        }

        public int Area
        {
            get
            {
                return this.Height * this.Width;
            }
        }

        public int Perimeter
        {
            get
            {
                return 2 * (this.Height + this.Width);
            }
        }

        public static Rectangle CreateFigure()
        {
            bool check = false;
            bool checkWidth = false;
            bool checkHeight = false;
            bool checkXCoord = false;
            bool checkYCoord = false;
            int width = 0;
            int height = 0;
            int xCoord = 0;
            int yCoord = 0;
            Rectangle rectangle;

            while (!checkWidth)
            {
                try
                {
                    Console.Write("Please, enter a natural number for the width of the rectangle: ");
                    check = int.TryParse(Console.ReadLine(), out width);

                    checkWidth = CheckValue(check, width);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                }
            }

            Console.WriteLine();

            while (!checkHeight)
            {
                try
                {
                    Console.Write("Please, enter a natural number for the height of the rectangle: ");
                    check = int.TryParse(Console.ReadLine(), out height);

                    checkHeight = CheckValue(check, height);
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

            rectangle = new Rectangle(width, height, xCoord, yCoord);

            return rectangle;
        }

        public override string ShowFigure()
        {
            return string.Format($"Type figure: {this.GetType().Name}{Environment.NewLine}" +
                $"Center point coordinates: {this.Center.X}, {this.Center.Y}{Environment.NewLine}" +
                $"Width: {this.Width}{Environment.NewLine}" +
                $"Height: {this.Height}{Environment.NewLine}" + 
                $"Area: {this.Area}{Environment.NewLine}" +
                $"Perimeter: {this.Perimeter}");
        }

        private static bool CheckValue(bool check, int value)
        {
            if (!check || value < 0)
            {
                throw new ArgumentException("The value must be greater than or equal to 0.");
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
