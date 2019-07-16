using System;

namespace Task2_6
{
    public class RoundShape
    {
        private int externalRadius;
        public Point Center { get; set; }


        public RoundShape(Point center, int externalRadius)
        {
            Center = center;
            ExternalRadius = externalRadius;
        }
        public RoundShape(int x, int y, int externalRadius)
        {
            Center = new Point(x, y);
            ExternalRadius = externalRadius;
        }
        public RoundShape(int externalRadius)
        {
            Center = Point.Zero();
            ExternalRadius = externalRadius;
        }


        public int ExternalRadius
        {
            get => externalRadius;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("External radius must be positive!");
                }
                externalRadius = value;
            }
        }
    }
}
