using System;

namespace Task2_7
{
    public class Line : Shape
    {
        public Line(int startX, int startY, int endX, int endY)
        {
            First = new Point(startX, startY);
            End = new Point(endX, endY);
        }

        public Point First { get; set; }
        public Point End { get; set; }
        
        public override void PrintInfo()
        {
            Console.WriteLine("Line:");
            Console.WriteLine($"Start: {First.ToString()}, End = {End.ToString()} \n");
        }
        public override void Draw()
        {
            Console.WriteLine("–");
        }
    }
}
