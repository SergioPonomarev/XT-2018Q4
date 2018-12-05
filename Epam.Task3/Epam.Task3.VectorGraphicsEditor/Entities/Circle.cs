using System;

namespace Epam.Task3.VectorGraphicsEditor.Entities
{
    public class Circle : Figure
    {
        private int radius;

        public Circle(int radius, int centerX, int centerY)
        {
            this.Radius = radius;
            this.Center = new Point(centerX, centerY);
        }

        public Circle(int radius, Point center)
        {
            this.Radius = radius;
            this.Center = center;
        }

        public override Point Center { get; set; }

        public int Radius
        {
            get => this.radius;

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The radius of the circle must be greater than or equal to 0.");
                }

                this.radius = value;
            }
        }

        public double Circumference
        {
            get
            {
                return 2 * Math.PI * this.radius;
            }
        }

        public static Circle CreateFigure()
        {
            bool check = false;
            bool checkRadius = false;
            bool checkXCoord = false;
            bool checkYCoord = false;
            int radius = 0;
            int xCoord = 0;
            int yCoord = 0;
            Circle circle;

            while (!checkRadius)
            {
                try
                {
                    Console.Write("Please, enter a natural number for the radius of the circle: ");
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
                    Console.Write("Please, enter an integer for X coordinate of the center point of the circle: ");
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
                    Console.Write("Please, enter an integer for Y coordinate of the center point of the circle: ");
                    check = int.TryParse(Console.ReadLine(), out yCoord);

                    checkYCoord = CheckCoord(check);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                }
            }

            circle = new Circle(radius, xCoord, yCoord);

            return circle;
        }

        public override string ShowFigure()
        {
            return string.Format($"Type figure: {this.GetType().Name}{Environment.NewLine}" + 
                $"- Center point coordinates: {this.Center.X}, {this.Center.Y}{Environment.NewLine}" + 
                $"- Radius: {this.Radius}{Environment.NewLine}" + 
                $"- Circumference: {this.Circumference}");
        }

        private static bool CheckRadius(bool check, int value)
        {
            if (!check || value < 0)
            {
                throw new ArgumentException("The radius of the circle must be greater than or equal to 0.");
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
