using System;

namespace Task2_7
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Shape[] shapes = new Shape[10];

                shapes[0] = new Circle(1, 2, 3);
                shapes[1] = new Ring(4, 4, 6, 4);
                shapes[2] = new Round(3, 4, 6);
                shapes[3] = new Line(1, 2, 5, 6);
                shapes[4] = new Rectangle(3, 4, 6, 1);
                shapes[5] = new Ring(4, 4, 6, 4);
                shapes[6] = new Rectangle(3, 4, 6, 1);
                shapes[7] = new Line(1, 2, 5, 6);
                shapes[8] = new Round(3, 4, 6);
                shapes[9] = new Circle(1, 2, 3);

                for (int i = 0; i < shapes.Length; i++)
                {
                    shapes[i].PrintInfo();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
