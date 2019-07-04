using System;

namespace Task_1._4
{
    class Program
    {        
        public static void DrawRectangle_3(int n, int width)
        {
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine(new string(' ', width - i) + new string('*', i * 2 - 1));
            }
        }
        /// <summary>
        /// Draws XMass tree in your Console! Happy new year!
        /// </summary>
        /// <param name="n">Heigth of a tree ^_^</param>
        public static void DrawXMassTree(int n)
        {
            for (int i = 0; i < n; i++)
            {
                DrawRectangle_3(i + 1, n);
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Enter positive integer N: ");
            string input = Console.ReadLine();
            int N;
            if (Int32.TryParse(input, out N) && N > 0)
            {               
                DrawXMassTree(N);
            }
            else
            {
                Console.WriteLine("Input Error!");
            }
        }
    }
}
