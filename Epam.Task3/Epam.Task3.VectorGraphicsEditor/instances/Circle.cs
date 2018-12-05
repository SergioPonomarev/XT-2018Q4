using System;

namespace Epam.Task3.VectorGraphicsEditor
{
    public class Circle : Figure
    {
        private int radius;

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

        public override string ToString()
        {
            return string.Format($"Type figure: {this.GetType()}{Environment.NewLine}" + 
                $"Center point coordinates: {this.Center.X}, {this.Center.Y}{Environment.NewLine}" + 
                $"Radius: {this.Radius}{Environment.NewLine}" + 
                $"Circumference: {this.Circumference}");
        }
    }
}
