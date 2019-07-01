using System;

namespace problem0._1
{
    class Program
    {
        static string solution1(int N)
        {
            var result = "";
            for (int i = 0; i < N; ++i)
            {
                result += (i + 1).ToString() + (i != N - 1 ? ", " : "");
            }
            return result;
        }

        static void Main(string[] args)
        {
            Console.Write("Enter positive integer N: ");
            string input = Console.ReadLine();
            int n;
            if (Int32.TryParse(input, out n) && n > 0)
            {
                Console.WriteLine("Result string: " + solution1(n));
            }
            else
            {
                Console.WriteLine("Input error!");
            }
        }
    }
}
