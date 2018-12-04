using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task3.RoundProgram;

namespace Epam.Task3.RingProgram
{
    public class Ring
    {
        private Point center;
        private int innerRadius;
        private int outerRadius;

        public double RingArea
        {
            get
            {
                double result = OuterRound.Area - InnerRound.Area;

                return result;
            }
        }

        public double RingCircumference
        {
            get
            {
                double result = OuterRound.Circumference + InnerRound.Circumference;

                return result;
            }
        }

        public int InnerRadius
        {
            get => innerRadius;

            set
            {
                if (InnerRound != null)
                {
                    if (value > OuterRadius)
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
            get => outerRadius;

            set
            {
                if (OuterRound != null)
                {
                    if (value < InnerRadius)
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
            get => center;

            set
            {
                this.center = value;

                if (InnerRound != null)
                {
                    this.InnerRound.Center = value;
                }

                if (OuterRound != null)
                {
                    this.OuterRound.Center = value;
                }
            }
        }

        private Round InnerRound { get; set; }

        private Round OuterRound { get; set; }

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
    }
}
