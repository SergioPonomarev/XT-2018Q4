using System;

namespace Epam.Task3.VectorGraphicsEditor.Entities
{
    public class Ring : Figure
    {
        private static int count;

        private Point center;

        private int innerRadius;

        private int outerRadius;

        static Ring()
        {
            Ring.count = 0;
        }

        public Ring(int xCenter, int yCenter, int innerRadius, int outerRadius)
        {
            if (innerRadius > outerRadius)
            {
                throw new ArgumentException("Radius of the inner round mustn't be more that radius of the outer round.");
            }

            this.Center = new Point(xCenter, yCenter);
            this.InnerRadius = innerRadius;
            this.OuterRadius = outerRadius;
            this.InnerRound = new Round(this.InnerRadius, this.Center);
            this.OuterRound = new Round(this.OuterRadius, this.Center);
            Ring.count++;
            this.Name = $"Ring{Ring.count.ToString()}";
        }

        public Ring(int innerRadius, int outerRadius, Point center)
        {
            if (innerRadius > outerRadius)
            {
                throw new ArgumentException("Radius of the inner round mustn't be more that radius of the outer round.");
            }

            this.Center = center;
            this.InnerRadius = innerRadius;
            this.OuterRadius = outerRadius;
            this.InnerRound = new Round(this.InnerRadius, this.Center);
            this.OuterRound = new Round(this.OuterRadius, this.Center);
            Ring.count++;
            this.Name = $"Ring{Ring.count.ToString()}";
        }

        public override string Name { get; }

        public double Area
        {
            get
            {
                double result = this.OuterRound.Area - this.InnerRound.Area;

                return result;
            }
        }

        public double Circumference
        {
            get
            {
                double result = this.OuterRound.Circumference + this.InnerRound.Circumference;

                return result;
            }
        }

        public int InnerRadius
        {
            get => this.innerRadius;

            set
            {
                if (this.InnerRound != null)
                {
                    if (value > this.OuterRadius)
                    {
                        throw new ArgumentException("Radius of the inner round mustn't be more that radius of the outer round.");
                    }

                    this.InnerRound.Radius = value;
                }

                this.innerRadius = value;
            }
        }

        public int OuterRadius
        {
            get => this.outerRadius;

            set
            {
                if (this.OuterRound != null)
                {
                    if (value < this.InnerRadius)
                    {
                        throw new ArgumentException("Radius of the inner round mustn't be more that radius of the outer round.");
                    }

                    this.OuterRound.Radius = value;
                }

                this.outerRadius = value;
            }
        }

        public override Point Center
        {
            get => this.center;

            set
            {
                this.center = value;

                if (this.InnerRound != null)
                {
                    this.InnerRound.Center = value;
                }

                if (this.OuterRound != null)
                {
                    this.OuterRound.Center = value;
                }
            }
        }

        private Round InnerRound { get; set; }

        private Round OuterRound { get; set; }

        public static Ring CreateFigure()
        {
            bool check = false;
            bool checkInnerRadius = false;
            bool checkOuterRadius = false;
            bool checkXCoord = false;
            bool checkYCoord = false;
            int innRadius = 0;
            int outRadius = 0;
            int xCoord = 0;
            int yCoord = 0;
            Ring ring;

            while (!checkXCoord)
            {
                try
                {
                    Console.Write("Please, enter an integer for X coordinate of the center point of the ring: ");
                    check = int.TryParse(Console.ReadLine(), out xCoord);

                    checkXCoord = CheckCoord(check);
                }
                catch (Exception ex)
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
                    Console.Write("Please, enter an integer for Y coordinate of the center point of the ring: ");
                    check = int.TryParse(Console.ReadLine(), out yCoord);

                    checkYCoord = CheckCoord(check);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                }
            }

            Console.WriteLine();

            while (!checkInnerRadius)
            {
                try
                {
                    Console.Write("Please, enter a natural number for the inner radius of the ring: ");
                    check = int.TryParse(Console.ReadLine(), out innRadius);

                    checkInnerRadius = CheckRadius(check, innRadius);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                }
            }

            Console.WriteLine();

            while (!checkOuterRadius)
            {
                try
                {
                    Console.Write("Please, enter a natural number for the outer radius of the ring: ");
                    check = int.TryParse(Console.ReadLine(), out outRadius);

                    if (CheckRadius(check, outRadius))
                    {
                        checkOuterRadius = CheckRadiusDiference(innRadius, outRadius);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                }
            }

            ring = new Ring(xCoord, yCoord, innRadius, outRadius);

            return ring;
        }

        public override string ShowFigure()
        {
            return string.Format($"Type figure: {this.GetType().Name}{Environment.NewLine}" +
                $"- Center point coordinates: {this.Center.X}, {this.Center.Y}{Environment.NewLine}" +
                $"- Inner radius: {this.InnerRadius}{Environment.NewLine}" +
                $"- Outer radius: {this.OuterRadius}{Environment.NewLine}" +
                $"- Area: {this.Area}{Environment.NewLine}" +
                $"- Sum of circumferences: {this.Circumference}");
        }

        private static bool CheckRadiusDiference(int innerR, int outerR)
        {
            if (innerR > outerR)
            {
                throw new ArgumentException("Inner radius of the ring mustn't be greater than outer radius of the ring.");
            }

            return true;
        }

        private static bool CheckRadius(bool check, int value)
        {
            if (!check || value < 0)
            {
                throw new ArgumentException("The radius must be greater than or equal to 0.");
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
