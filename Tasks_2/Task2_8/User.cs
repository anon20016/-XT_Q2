using System;

namespace Task2_8
{
    public class User : IMove
    {
        private int countLive;
        public int Speed { get; set; }
        public string NickName { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public User(string nickName, int countLive, int speed, int x, int y)
        {
            X = x;
            Y = y;
            NickName = nickName;
            Speed = speed;
            CountLive = countLive;
        }

        public int CountLive
        {
            get => countLive;
            set
            {
                if (value >= 0)
                {
                    countLive = value;
                }
                else
                {
                    throw new ArgumentException("You are dead!");
                }
            }
        }

        public void Move(int dx, int dy)
        {
            X += dx;
            Y += dy;
        }
    }
}
