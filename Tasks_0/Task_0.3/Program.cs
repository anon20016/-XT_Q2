using System;

namespace problem0._1
{
    class Program
    {
        static void solution3(int N)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (i == N / 2 && j == N / 2)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("*");
                    }
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Enter positive uneven integer N > 1: ");
            string input = Console.ReadLine();
            int n;
            if (Int32.TryParse(input, out n) && n > 1 && n % 2 == 1)
            {
                solution3(n);
            }
            else
            {
                Console.WriteLine("Input error!");
            }
        }
    }
}
