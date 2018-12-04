using System;

namespace Epam.Task3.RoundProgram
{
    public class Round
    {
        private int radius;

        public Round(int radius, int centerX, int centerY)
        {
            this.Radius = radius;
            this.Center = new Point(centerX, centerY);
        }

        public Point Center { get; set; }

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
    }
}
