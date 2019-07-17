using System;

namespace Task2_7
{
   public abstract class Shape
    {
        public abstract void PrintInfo();
        public abstract void Draw();        

        protected void Checkpositive(int val, ref int place)
        {
            if (val <= 0)
            {
                throw new ArgumentException("The value must be positive");
            }
            else
            {
                place = val;
            }
        }
    }
}
