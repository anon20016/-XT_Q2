using System;

namespace Task2_8
{
    abstract class Obstacle
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Obstacle(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
