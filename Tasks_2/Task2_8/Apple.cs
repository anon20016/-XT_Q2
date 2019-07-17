using System;

namespace Task2_8
{
    public class Apple : Bonus
    {
        public Apple(int x, int y, int val) : base(x, y, val)
        {

        }
        public override void Print()
        {
            Console.WriteLine("Added smth with Apple!");
        }
    }
}
