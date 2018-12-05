using System;

namespace Epam.Task3.VectorGraphicsEditor.Instances
{
    public class Point
    {
        public Point()
        {
        }

        public Point(int value) : this(value, value)
        {
        }

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }
    }
}
