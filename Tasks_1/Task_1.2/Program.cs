using System;

namespace Task_1._2
{
    class Program
    {
        public static void DrawRectangle(int n)
        {
            string temp = "";
            for (int i = 1; i <= n; i++)
            {
                temp += "*";
                Console.WriteLine(temp);
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Enter positive integer N: ");
            string input = Console.ReadLine();
            int N;
            if (Int32.TryParse(input, out N) && N > 0)
            {
                DrawRectangle(N);
            }
            else
            {
                Console.WriteLine("Input Error!");
            }
        }
    }
}
