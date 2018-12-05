using System;

namespace Epam.Task3.VectorGraphicsEditor
{
    public class Line : Figure
    {
        private int length;

        public override Point Center { get; set; }

        public int Length
        {
            get => length;

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Line length must be greater than or equal to 0.");
                }

                length = value;
            }
        }
    }
}
