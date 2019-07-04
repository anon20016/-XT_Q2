using System;

namespace Task_1._3
{
    class Program
    {
        public static void DrawRectangle_2(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine(new string(' ', n - i) + new string('*', i * 2 - 1));
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Enter positive integer N: ");
            string input = Console.ReadLine();
            int N;
            if (Int32.TryParse(input, out N) && N > 0)
            {
                DrawRectangle_2(N);
            }
            else
            {
                Console.WriteLine("Input Error!");
            }
        }
    }
}
