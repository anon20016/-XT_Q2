using System;

namespace Task2_7
{
    public class Round : Shape
    {
        private int radius;

        public Round(int x, int y, int radius)
        {
            Center = new Point(x, y);
            Radius = radius;
        }
        public Round(Point center, int radius)
        {
            Center = center;
            Radius = radius;
        }

        public Point Center { get; set; }
        public int Radius
        {
            get => radius;
            set => Checkpositive(value, ref radius);            
        }

        public override void PrintInfo()
        {
            Console.WriteLine("Round:");
            Console.WriteLine($"Center = {Center.ToString()}, Radius = {Radius} \n");
        }
        public override void Draw()
        {
            Console.WriteLine("O");
        }
    }
}
