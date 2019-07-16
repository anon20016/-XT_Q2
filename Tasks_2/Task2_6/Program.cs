using System;

namespace Task2_6
{
    class Program
    {
        static void Main(string[] args)
        {
            int x, y, externalRadius, innerRadius;
            Ring ring;

            try
            {
                Console.WriteLine("Enter x: ");
                x = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter y: ");
                y = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter inner radius: ");
                innerRadius = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter external radius: ");
                externalRadius = int.Parse(Console.ReadLine());
                ring = new Ring(x, y, externalRadius, innerRadius);

                Console.WriteLine("Area of figure = {0}", ring.Area());
                Console.WriteLine("Circumference = {0}", ring.Length());
                Console.ReadLine();

            }
            catch (ArgumentException error)
            {
                Console.WriteLine(error.Message);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }

        }
    }
}
