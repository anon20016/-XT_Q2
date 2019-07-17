using System;

namespace Task2_7
{
    public class Circle : Round
    {
        public Circle(int x, int y, int radius) : base(x, y, radius)
        {
        }

        public override void PrintInfo()
        {
            Console.WriteLine("Circle:");
            Console.WriteLine($"Center: {Center.ToString()}, Radius = {Radius} \n");
        }
    }
}
