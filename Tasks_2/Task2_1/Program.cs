using System;

namespace Task2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Круг с центром в точке х и у и зданным радиусом
            Circle c = new Circle(1, 4, 2);
            Console.WriteLine(c.ToString());
            Console.WriteLine("Area = {0}", c.GetArea);
            Console.WriteLine("Circumference = {0}", c.GetCircumference);
            Console.WriteLine();

            // Круг с центром в Point и заданным радиусом
            c = new Circle(new Point(4, 2), 3);
            Console.WriteLine(c.ToString());
            Console.WriteLine("Area = {0}", c.GetArea);
            Console.WriteLine("Circumference = {0}", c.GetCircumference);
            Console.WriteLine();


            // Круг с центром в начале координат и заданным радиусом
            c = new Circle(5);
            Console.WriteLine(c.ToString());
            Console.WriteLine("Area = {0}", c.GetArea);
            Console.WriteLine("Circumference = {0}", c.GetCircumference);
            Console.WriteLine();


            Console.ReadKey();
        }
    }
}
