using System;

namespace Task_1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("To find rectangle area enter a and b: ");
            string[] input = Console.ReadLine().Split();            
            int a, b;
            if (input.Length == 2 && Int32.TryParse(input[0], out a) && Int32.TryParse(input[1], out b) && a > 0 && b > 0)
            {                
                Console.WriteLine("Resultin area: " + (a * b).ToString());                
            }
            else
            {
                Console.WriteLine("Input error!");
            }
        }
    }
}
