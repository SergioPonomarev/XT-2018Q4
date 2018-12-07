using System;

namespace Epam.Task3.VectorGraphicsEditor.Entities
{
    public class Round : Figure
    {
        private static int count;

        private int radius;

        static Round()
        {
            Round.count = 0;
        }

        public Round(int radius, int centerX, int centerY)
        {
            this.Radius = radius;
            this.Center = new Point(centerX, centerY);
            Round.count++;
            this.Name = $"Round{Round.count.ToString()}";
        }

        public Round(int radius, Point center)
        {
            this.Radius = radius;
            this.Center = center;
            Round.count++;
            this.Name = $"Round{Round.count.ToString()}";
        }

        public override string Name { get; }

        public override Point Center { get; set; }

        public int Radius
        {
            get => this.radius;

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The radius of the round must be greater than or equal to 0.");
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

        public double Area
        {
            get
            {
                return Math.PI * this.radius * this.radius;
            }
        }

        public static Round CreateFigure()
        {
            bool check = false;
            bool blockCheck = false;
            int radius = 0;
            int xCoord = 0;
            int yCoord = 0;

            while (!blockCheck)
            {
                try
                {
                    Console.Write("Please, enter a natural number for the radius of the round: ");
                    check = int.TryParse(Console.ReadLine(), out radius);

                    blockCheck = CheckRadius(check, radius);
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
                    Console.Write("Please, enter an integer for X coordinate of the center point of the round: ");
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
                    Console.Write("Please, enter an integer for Y coordinate of the center point of the round: ");
                    check = int.TryParse(Console.ReadLine(), out yCoord);

                    blockCheck = CheckCoord(check);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                }
            }

            return new Round(radius, xCoord, yCoord);
        }

        public override string ShowFigure()
        {
            return string.Format($"Type figure: {this.GetType().Name}{Environment.NewLine}" +
                $"- Center point coordinates: {this.Center.X}, {this.Center.Y}{Environment.NewLine}" +
                $"- Radius: {this.Radius}{Environment.NewLine}" +
                $"- Area: {this.Area}{Environment.NewLine}" +
                $"- Circumference: {this.Circumference}");
        }

        private static bool CheckRadius(bool check, int value)
        {
            if (!check || value < 0)
            {
                throw new ArgumentException("The radius of the round must be greater than or equal to 0.");
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