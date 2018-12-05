using System;

namespace Epam.Task3.VectorGraphicsEditor
{
    public class Rectangle : Figure
    {
        private int width;
        private int height;

        public override Point Center { get; set; }

        public int Width
        {
            get => width;

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Rectangle width must be greater than or equal to 0.");
                }

                width = value;
            }
        }

        public int Height
        {
            get => height;

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Rectangle height must be greater than or equal to 0.");
                }

                height = value;
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
    }
}
