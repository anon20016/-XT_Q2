using System;

namespace Task2_6
{
    public class Ring : RoundShape
    {
        private int innerRadius;

        public Ring(Point center, int externalRadius, int innerRadius) : base(center, externalRadius)
        {
            InnerRadius = innerRadius;
        }
        public Ring(int x, int y, int externalRadius, int innerRadius) : base(x, y, externalRadius)
        {
            InnerRadius = innerRadius;
        }

        public int InnerRadius
        {
            get => innerRadius;
            set
            {
                if (value <= 0 || value > ExternalRadius)
                {
                    throw new ArgumentException("Inner radius not set correctly!");
                }
                innerRadius = value;                
            }
        }

        /// <summary>
        /// Calculating Area of a figure
        /// </summary>
        /// <returns></returns>
        public double Area() => Math.PI * ((ExternalRadius * ExternalRadius) - (innerRadius * innerRadius));
        /// <summary>
        /// Calculating Circumference
        /// </summary>
        /// <returns></returns>
        public double Length() => 2 * Math.PI * (ExternalRadius + innerRadius);
    }
}
