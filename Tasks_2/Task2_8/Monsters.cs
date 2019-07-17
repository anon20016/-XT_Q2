using System;

namespace Task2_8
{
    abstract class Monsters
    {
        public Monsters(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public abstract void Event();
        public abstract void Move();
    }
}
