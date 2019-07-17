using System;

namespace Task2_8
{
    public class Field
    {
        private int width;
        private int height;

        private Obstacle[] Obstacles;
        private Bonus[] Bonuses;

        public Field(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public int Width
        {
            get => this.width;    
            set
            {
                if (value > 0)
                {
                    width = value;
                }
                else
                {
                    throw new ArgumentException("The width of the field is not set correctly!");
                }
            }
        }

        public int Height
        {
            get => height;
            set
            {
                if (value > 0)
                {
                    height = value;
                }
                else
                {
                    throw new ArgumentException("The height of the field is not set correctly!");
                }
            }
        }

        public bool IsBonus(int x, int y)
        {
            //
            return false;
        }
        public bool IsObstacle(int x, int y)
        {
            //
            return false;
        }
    }
}
