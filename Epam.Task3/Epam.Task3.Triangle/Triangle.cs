using System;

namespace Epam.Task3.Triangle
{
    public class Triangle
    {
        private int sideA;
        private int sideB;
        private int sideC;

        public int SideA
        {
            get
            {
                if (this.sideA <= 0)
                {
                    throw new ArgumentException("The Side A of the triangle is not defined.", nameof(this.SideA));
                }

                return this.sideA;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The value must be an integer more than 0.", nameof(this.SideA));
                }

                this.sideA = value;
            }
        }

        public int SideB
        {
            get
            {
                if (this.sideB <= 0)
                {
                    throw new ArgumentException("The Side B of the triangle is not defined.", nameof(this.SideB));
                }

                return this.sideB;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The value must be an integer more than 0.", nameof(this.SideB));
                }

                this.sideB = value;
            }
        }

        public int SideC
        {
            get
            {
                if (this.sideC <= 0)
                {
                    throw new ArgumentException("The Side C of the triangle is not defined.", nameof(this.SideC));
                }

                return this.sideC;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The value must be an integer more than 0.", nameof(this.SideC));
                }

                if (value >= this.SideA + this.SideB)
                {
                    throw new ArgumentException("Side C must be less than sum of Side A and Side B.", nameof(this.SideC));
                }

                this.sideC = value;
            }
        }

        public double GetTriangleArea()
        {
            double p = this.GetTrianglePerimeter();
            double halfP = p / 2;
            double result = Math.Sqrt(halfP * (halfP - this.SideA) * (halfP - this.SideB) * (halfP - this.SideC));

            return result;
        }

        public double GetTrianglePerimeter()
        {
            double result = this.SideA + this.SideB + this.SideC;

            return result;
        }
    }
}
