using System;

namespace Task2_7
{
    public class Ring : Round
    {
        private int innerRadius;

        public Ring(Point center, int radius, int innerRadius) : base(center, radius)
        {
            InnerRadius = innerRadius;
        }
        public Ring(int x, int y, int radius, int innerRadius) : base(x, y, radius)
        {
            InnerRadius = innerRadius;
        }

        public int InnerRadius
        {
            get => innerRadius;
            set => Checkpositive(value, ref innerRadius);
        }

        public override void PrintInfo()
        {
            Console.WriteLine("Ring:");
            Console.WriteLine($"Center: {Center.ToString()}, Inner radius = {InnerRadius}, External radius = {Radius} \n");
        }
        public override void Draw()
        {
            Console.WriteLine("0");
        }
    }
}
