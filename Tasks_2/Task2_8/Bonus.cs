using System;
namespace Task2_8
{
   public abstract class Bonus
    {
        public Bonus(int x, int y, int val)
        {
            X = x;
            Y = y;
            Bonus_val = val;
        }
        public int X { get; set; }
        public int Y { get; set; }
        public int Bonus_val { get; set; }

        public abstract void Print();
    }
}
