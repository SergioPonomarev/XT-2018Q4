using System;

namespace Epam.Task3.Game
{
    public class Field
    {
        public Field(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public int Width { get; }
        public int Height { get; }
    }
}
