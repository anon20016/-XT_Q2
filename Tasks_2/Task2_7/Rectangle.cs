using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_7
{
    public class Rectangle : Shape
    {
        private int width;
        private int heigth;

        public Rectangle(int x, int y, int width, int heigth)
        {
            StartPoint = new Point(x, y);
            Width = width;
            Heigth = heigth;
        }
        public Rectangle(Point p, int width, int heigth)
        {
            StartPoint = p;
            Width = width;
            Heigth = heigth;
        }

        public Point StartPoint{ get; set; }

        public int Width
        {
            get => width;
            set => Checkpositive(value, ref width);            
        }

        public int Heigth
        {
            get => heigth;
            set => Checkpositive(value, ref heigth);
        }

        public override void PrintInfo()
        {
            Console.WriteLine("Rectangle:");
            Console.WriteLine($"Start point: {StartPoint.ToString()}, Width = {Width}, Heigth = {Heigth} \n");
        }
        public override void Draw()
        {
            Console.WriteLine("[]");
        }
    }
}
