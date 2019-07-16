using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_1
{
    public class Circle
    {
        private Point center;       
        private double radius;
        private double area;
        private double circumference;

        public Circle(double radius)
        {
            Radius = radius;
            Center = Point.Zero();
            CalculateParams();
        }
        public Circle(Point pnt, double radius)
        {
            Radius = radius;
            Center = pnt;
            CalculateParams();
        }
        public Circle(double x, double y, double radius)
        {
            Radius = radius;
            Center = new Point(x, y);
            CalculateParams();
        }

        /// <summary>
        /// Counting parametrs of Circle
        /// </summary>
        private void CalculateParams()
        {
            circumference = CalcCircumference();
            area = CalcArea();
        }

        public Point Center
        {
            get => center;
            private set { center = value; }
        }

        public double Radius
        {
            get => radius;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Radius must be positive");
                }
                radius = value;
            }
        }

        public double GetCircumference { get => circumference; }

        public double GetArea { get => area; }

        private double CalcCircumference()
        {
            return 2 * Math.PI * Radius;
        }

        private double CalcArea()
        {
            return Math.PI * Radius * Radius;
        }

        public override string ToString()
        {
            return "Circle with center " + Center.ToString() + $" and radius {Radius}";
        }
    }
}