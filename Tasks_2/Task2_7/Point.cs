using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_7
{
    public class Point
    {
        /// <summary>
        /// Point (0, 0)
        /// </summary>
        public static Point Zero()
        {
            return new Point(0, 0);
        }

        public double X { get; private set; }
        public double Y { get; private set; }        

        public Point(double coordX, double coordY)
        {
            X = coordX;
            Y = coordY;
        }

        public override bool Equals(object obj)
        {
            var point = obj as Point;
            return X == point.X && Y == point.Y;
        }

        public static bool operator ==(Point a, Point b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(Point a, Point b)
        {
            return !a.Equals(b);
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
        
    }
}