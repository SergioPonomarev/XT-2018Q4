using System;
using Epam.Task3.RoundProgram;

namespace Epam.Task3.RingProgram
{
    public class Ring
    {
        private Point center;
        private int innerRadius;
        private int outerRadius;

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
        }

        public Ring(Point center, int innerRadius, int outerRadius)
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
        }

        public double RingArea
        {
            get
            {
                double result = this.OuterRound.Area - this.InnerRound.Area;

                return result;
            }
        }

        public double RingCircumference
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

        public Point Center
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
    }
}
