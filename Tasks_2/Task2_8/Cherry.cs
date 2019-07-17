using System;

namespace Task2_8
{
    class Cherry : Bonus
    {
        public Cherry(int x, int y, int val) : base(x, y, val)
        {

        }

        public override void Print()
        {
            Console.WriteLine("Added smth with cherry");
        }
    }
}
