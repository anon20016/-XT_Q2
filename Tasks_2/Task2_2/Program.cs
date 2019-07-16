using System;

namespace Task2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Triangle t = new Triangle(10, 7, 4);                
                Console.WriteLine(t.ToString());
                Console.WriteLine("Perimetr = {0}\nArea = {1}", t.GetPerimetr, t.GetArea);
            }
            catch (ArgumentException error)
            {
                Console.WriteLine(error.Message);

            }
            Console.WriteLine();

            try
            {
                Triangle t = new Triangle(10, -1, 4);
                Console.WriteLine(t.ToString());
                Console.WriteLine("Perimetr = {0}\nArea = {1}", t.GetPerimetr, t.GetArea);
            }
            catch (ArgumentException error)
            {
                Console.WriteLine(error.Message);

            }


            Console.ReadKey();
        }
    }
}
